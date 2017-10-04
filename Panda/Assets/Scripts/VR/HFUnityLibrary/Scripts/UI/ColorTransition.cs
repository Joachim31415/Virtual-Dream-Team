//using UnityEngine;
//using System.Collections;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using System;

//[RequireComponent(typeof(Image))]
//public class ColorTransition : HotspotInfo
//{
//    [Header("Honeywell Colors")]
//    public HoneywellColor defaultButtonColor = HoneywellColor.BRILLIANT_WHITE;
//    public HoneywellColor selectedButtonColor = HoneywellColor.RED;

//    float fadeTime;
//    //float transitionTime = 0;

//    Button currentButton;
//    Image defaultImage;
//    Color defaultColor;

//    void Awake()
//    {
//        defaultImage = GetComponent<Image>();
//        currentButton = GetComponent<Button>();
//    }

//    void Start()
//    {
//        //fadeInTime = triggerTime;
//        //fadeTime = triggerTime;
//        Init();
//    }

//    public void Init()
//    {
//        ControlHotspotInfo();
//        SetTransitionValues();

//        hotspotRectTransform = GetComponent<RectTransform>();
//    }

//    void Update()
//    {
//        //if (!IsVisible)
//        //{
//        //    GetComponent<Button>().enabled = false;  //currentButton.transition = Selectable.Transition.None;
//        //    //GetComponent<Image>().enabled = false;
//        //}
//        //else
//        //{
//        //    GetComponent<Button>().enabled = true;
//        //    //GetComponent<Image>().enabled = true;
//        //    ControlHotspotInfo();
//        //    SetTransitionValues();
//        //}
//    }

//    void ControlHotspotInfo()
//    {
//        GetComponent<Image>().color = Color.white;

//        if (hotspotType == HotspotType.None)
//        {
//            Debug.LogError("Assign a type to the Hotspot in " + gameObject.name);
//            GetComponent<Image>().color = Color.blue;
//        }

//        if (hotspotType == HotspotType.Mission && mission == ContentType.Mission.None)
//            GetComponent<Image>().color = Color.yellow;

//        if (hotspotType == HotspotType.Persona && persona == ContentType.Persona.None)
//            GetComponent<Image>().color = Color.yellow;

//        if (hotspotType != HotspotType.Mission)
//            mission = ContentType.Mission.None;

//        if (hotspotType != HotspotType.Persona)
//            persona = ContentType.Persona.None;

//        if (hotspotType != HotspotType.ProductInformation)
//            product = DataModel.Products.None;
//    }

//    void SetTransitionValues()
//    {
//        if (currentButton)
//        {
//            // Set transition type
//            currentButton.transition = Selectable.Transition.ColorTint;

//            // Set colors
//            ColorBlock cb = currentButton.colors;
//            cb.normalColor = Toolset.HoneywellColorPalette[defaultButtonColor];
//            cb.highlightedColor = Toolset.HoneywellColorPalette[selectedButtonColor];

//            // Set fade duration
//            cb.fadeDuration = fadeTime;

//            // Apply changes
//            currentButton.colors = cb;
//        }
//    }

//    protected override void EnterTransition()
//    {
//        //transitionTime = 0;
//        //Debug.LogWarning("EnterTransition");
//        //StartCoroutine(ColorLerp());
//    }

//    protected override void ExitTransition()
//    {

//    }

//    protected override void SetEnterValues()
//    {
//        fadeTime = fadeInTime;
//    }

//    protected override void SetExitValues()
//    {
//        fadeTime = fadeOutTime;
//    }

//    protected override void CustomBehaviour()
//    {
//        // Automatic button transtition behaviour
//        //transitionTime += Time.deltaTime / triggerTime;
//        //defaultImage.color = Color.Lerp(Color.white, Color.red, transitionTime);
//    }

//    protected override void Clicked()
//    {
//        OnHotspotInfoClicked(this);
//    }

//    // Fade in
//    protected override void SetFadeInValues()
//    {
//        GetComponent<Button>().enabled = false;

//        defaultColor = defaultImage.color;
//        defaultColor.a = 0;
//        defaultImage.color = defaultColor;
//    }

//    protected override void FadeInTransition()
//    {
//        float step = 0.02f;
//        float increment = 1f / (fadeInTime / step);
//        defaultColor.a += increment; // Time.deltaTime / fadeInTime;
//        defaultImage.color = defaultColor;
//    }

//    protected override void FadeInFinished()
//    {
//        //throw new NotImplementedException();

//        defaultColor = defaultImage.color;
//        defaultColor.a = 1f;
//        defaultImage.color = defaultColor;

//        GetComponent<Button>().enabled = true;
//    }

//    // Fade out
//    protected override void SetFadeOutValues()
//    {
//        GetComponent<Button>().enabled = false;

//        defaultColor = defaultImage.color;
//        defaultColor.a = 1f;
//        defaultImage.color = defaultColor;
//    }

//    protected override void FadeOutTransition()
//    {
//        // TODO check fadeOutTime is bigger than the variable, In inspector is set to 1s and is taking 1.5s
//        float step = 0.02f;
//        float increment = 1f / (fadeInTime / step);
//        defaultColor.a -= increment; // Time.deltaTime / fadeOutTime;
//        defaultImage.color = defaultColor;
//        //Debug.LogWarning("FadeOutTransition time: " + Time.time);
//    }

//    protected override void FadeOutFinished()
//    {
//        //throw new NotImplementedException();
//        GetComponent<Button>().enabled = true;
//    }
//}
