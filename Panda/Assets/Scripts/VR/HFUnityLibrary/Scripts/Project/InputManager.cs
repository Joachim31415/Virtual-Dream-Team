using UnityEngine;
using System;

namespace HappyFinish.Project
{
    public class InputManager : MonoBehaviour
    {
        // Events to suscribe to
        public static Action OnClickEvent1;
        public static Action OnClickEvent2;
        public static Action OnClickEvent3;
        public static Action OnClickEvent4;
        public static Action OnClickEventBack;

        public static Action OnClickEventRight;
        public static Action OnClickEventLeft;
        public static Action OnClickEventUp;
        public static Action OnClickEventDown;



        private InputManager() { }

        private static InputManager instance;
        public static InputManager Instance
        {
            get
            {
                //   
                if (!instance)
                {
                    instance = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
                }

                if (!instance)
                {
                    instance = GameObject.Find("InputManager").GetComponent<InputManager>();
                }

                if (!instance)
                {
                    instance = FindObjectOfType<InputManager>();
                }

                if (!instance)
                {
                    Debug.LogError("PlatformManager - There is no PlatformManager GameObject");
                }

                return instance;
            }
        }

        [HideInInspector]
        public bool Input1 = false;
        [HideInInspector]
        public bool Input2 = false;
        [HideInInspector]
        public bool Input3 = false;
        [HideInInspector]
        public bool Input4 = false;

        [HideInInspector]
        public bool InputBack = false;


        // Use this for initialization
        void Start()
        {
            if (PlatformManager.Instance.currentPlatform == PlatformManager.PlatformTarget.None)
            {
                Debug.LogError("Select a platform target in Platform Manager");
                return;
            }
        }

        // Update is called once per frame
        void Update()
        {
            switch (PlatformManager.Instance.currentPlatform)
            {
                case PlatformManager.PlatformTarget.None:
                    break;
                case PlatformManager.PlatformTarget.Windows:
                    CheckInputWindows();
                    break;
                case PlatformManager.PlatformTarget.MacOS:
                    break;
                case PlatformManager.PlatformTarget.Cardboard:
                    break;
                case PlatformManager.PlatformTarget.Mobile:
                    break;
                case PlatformManager.PlatformTarget.GearVR:
                    CheckInputGearVR();
                    break;
                case PlatformManager.PlatformTarget.Oculus:
                    CheckInputOculus();
                    break;
                case PlatformManager.PlatformTarget.Vive:
                    //CheckInputVive();
                    break;
                default:
                    break;
            }
        }

        void LateUpdate()
        {
            Input1 = false;
            Input2 = false;
            Input3 = false;
            Input4 = false;

            InputBack = false;
        }

        // Windows
        private void CheckInputWindows()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Input1 = true;

                if (OnClickEvent1 != null)
                {
                    OnClickEvent1();
                }
            }

            if (Input.GetMouseButtonUp(1))
            {
                Input2 = true;

                if (OnClickEvent2 != null)
                {
                    OnClickEvent2();
                }
            }

            if (Input.GetMouseButtonUp(2))
            {
                Input3 = true;

                if (OnClickEvent3 != null)
                {
                    OnClickEvent3();
                }
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                InputBack = true;

                if (OnClickEventBack != null)
                {
                    OnClickEventBack();
                }
            }
        }

        // GearVR
        private void CheckInputGearVR()
        {
#if UNITY_EDITOR
            // Tap
            if (Input.GetMouseButtonUp(2))
            {
                Input1 = true;

                if (OnClickEvent1 != null)
                {
                    OnClickEvent1();
                }
            }
#else
            if (Input.GetMouseButtonUp(0))
            {
                Input1 = true;

                if (OnClickEvent1 != null)
                {
                    OnClickEvent1();
                }
            }
#endif

            // Back button
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                InputBack = true;

                if (OnClickEventBack != null)
                {
                    OnClickEventBack();
                }
            }
        }

        // Oculus
        private void CheckInputOculus()
        {
            //if (OVRInput.GetActiveController() == OVRInput.Controller.Gamepad)
            //{
            //    OculusGamepadInput();
            //}
            //else if (OVRInput.GetActiveController() == OVRInput.Controller.Remote)
            //{
            //    OculusRemoteInput();
            //}
            //else
            //{
            //    Debug.LogError("Input - Oculus, there is no input manager for " + OVRInput.GetActiveController() + " oculus controller");
            //}

            //OculusGamepadInput();
            //OculusRemoteInput();
        }

        //private void OculusGamepadInput()
        //{
        //    // One
        //    if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.Gamepad))
        //    {
        //        Input1 = true;

        //        if (OnClickEvent1 != null)
        //        {
        //            OnClickEvent1();
        //        }
        //    }

        //    // Two
        //    if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.Gamepad))
        //    {
        //        Input2 = true;

        //        if (OnClickEvent2 != null)
        //        {
        //            OnClickEvent2();
        //        }
        //    }

        //    // Three
        //    if (OVRInput.GetUp(OVRInput.Button.Three, OVRInput.Controller.Gamepad))
        //    {
        //        Input3 = true;

        //        if (OnClickEvent3 != null)
        //        {
        //            OnClickEvent3();
        //        }
        //    }

        //    // Four
        //    if (OVRInput.GetUp(OVRInput.Button.Four, OVRInput.Controller.Gamepad))
        //    {
        //        Input4 = true;

        //        if (OnClickEvent4 != null)
        //        {
        //            OnClickEvent4();
        //        }
        //    }

        //    // Back
        //    if (OVRInput.GetUp(OVRInput.Button.Back, OVRInput.Controller.Gamepad))
        //    {
        //        InputBack = true;

        //        if (OnClickEventBack != null)
        //        {
        //            OnClickEventBack();
        //        }
        //    }
        //}

        //private void OculusRemoteInput()
        //{
        //    // One
        //    if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.Remote))
        //    {
        //        Input1 = true;

        //        if (OnClickEvent1 != null)
        //        {
        //            OnClickEvent1();
        //        }
        //    }

        //    // Back
        //    if (OVRInput.GetUp(OVRInput.Button.Back, OVRInput.Controller.Remote))
        //    {
        //        InputBack = true;

        //        if (OnClickEventBack != null)
        //        {
        //            OnClickEventBack();
        //        }
        //    }

        //    // Left
        //    if (OVRInput.GetUp(OVRInput.Button.DpadLeft, OVRInput.Controller.Remote))
        //    {
        //        //InputBack = true;

        //        if (OnClickEventLeft != null)
        //        {
        //            OnClickEventLeft();
        //        }
        //    }

        //    // Right 
        //    if (OVRInput.GetUp(OVRInput.Button.DpadRight, OVRInput.Controller.Remote))
        //    {
        //        //InputBack = true;

        //        if (OnClickEventRight != null)
        //        {
        //            OnClickEventRight();
        //        }
        //    }

        //    // Up 
        //    if (OVRInput.GetUp(OVRInput.Button.DpadUp, OVRInput.Controller.Remote))
        //    {
        //        //InputBack = true;

        //        if (OnClickEventUp != null)
        //        {
        //            OnClickEventUp();
        //        }
        //    }

        //    // Down 
        //    if (OVRInput.GetUp(OVRInput.Button.DpadDown, OVRInput.Controller.Remote))
        //    {
        //        //InputBack = true;

        //        if (OnClickEventDown != null)
        //        {
        //            OnClickEventDown();
        //        }
        //    }
        //}

        private void ManageTouchpadDirection(Vector2 touchpadAxis)
        {
            float threshold = 0.31f;
            if (touchpadAxis.x < threshold && Mathf.Abs(touchpadAxis.y) < threshold)
            {
                if (OnClickEventLeft != null)
                {
                    OnClickEventLeft();
                }
            }

            // Right
            else if (touchpadAxis.x > (1.0f - threshold) && Mathf.Abs(touchpadAxis.y) < threshold)
            {
                if (OnClickEventRight != null)
                {
                    OnClickEventRight();
                }
            }

            // Up
            else if (touchpadAxis.y > (1.0f - threshold) && Mathf.Abs(touchpadAxis.x) < threshold)
            {
                if (OnClickEventUp != null)
                {
                    OnClickEventUp();
                }
            }

            // Down
            else if (touchpadAxis.y < threshold && Mathf.Abs(touchpadAxis.x) < threshold)
            {
                if (OnClickEventDown != null)
                {
                    OnClickEventDown();
                }
            }
        }
    }

}