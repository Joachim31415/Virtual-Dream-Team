using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using HappyFinish.Project;
using System;

namespace HappyFinish.VR
{
    [RequireComponent(typeof(EventTrigger))]
    public abstract class Hotspot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public static Action OnPointerEnterEvent = delegate { };
        public static Action OnPointerExitEvent = delegate { };

        public enum InteractionType
        {
            Timer,
            Click,
            None
        }
        [Header("Hotspot type")]
        public InteractionType interactionType;


        [Header("Hotspot timer")]
        public float triggerTime = 1.5f;
        private float currentTriggerTime = 0;
        
        public bool IsVisible { get; private set; }

        private bool pointerIn;

        protected void Awake()
        {
            IsVisible = true;
        }

        protected void Start()
        {
            pointerIn = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!IsVisible)
                return;

            Enter(eventData);

            // Event
            OnPointerEnterEvent();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsVisible)
                return;

            Exit(eventData);

            // Event
            OnPointerExitEvent();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsVisible)
                return;

            ClickBehaviour();
        }

        void Enter(PointerEventData eventData)
        {
            pointerIn = true;

            if (interactionType == InteractionType.Timer)
            {
                //StopCoroutine(OnPointerStay(eventData));
                StartCoroutine(OnPointerStay(eventData));
            }
            else if (interactionType == InteractionType.Click)
            {
                //StopCoroutine(UpdatePointerStay());
                StartCoroutine(UpdatePointerStay());
            }

            EnterBehaviour();
        }

        void Exit(PointerEventData eventData)
        {
            pointerIn = false;
            currentTriggerTime = 0;

            StopAllCoroutines();
            ExitBehaviour();
        }

        private IEnumerator OnPointerStay(PointerEventData eventData)
        {
            currentTriggerTime = 0;
            while (currentTriggerTime < triggerTime)
            {
                currentTriggerTime += Time.deltaTime;
                StayBehaviour(currentTriggerTime);
                yield return new WaitForSeconds(Time.deltaTime / triggerTime);
            }

            // Timer ended simulates a click and the OnClick UI Button event is called
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            ClickBehaviour();
        }

        private IEnumerator UpdatePointerStay()
        {
            while (pointerIn)
            {
                //Waiting for input
                if (InputManager.Instance.Input1)
                {
                    pointerIn = false;
                    ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    yield break;
                }

                yield return null;
            }
        }

        //
        protected abstract void EnterBehaviour();
        protected abstract void ExitBehaviour();
        protected abstract void StayBehaviour(float deltaTime);
        protected abstract void ClickBehaviour();
    }
}