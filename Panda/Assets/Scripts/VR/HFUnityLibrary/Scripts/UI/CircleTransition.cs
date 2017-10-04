//using UnityEngine;
//using System.Collections;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using System;

//[RequireComponent(typeof(Image))]
//public class CircleTransition : HotspotInfo
//{
//    [Header("A circular perimeter")]
//    public Image circleImage;

//    [Header("Size on Pointer Enter")]
//    public float scaleFactor = 1.2f;

//    Vector3 initialScale;
//    Color defaultColor;
//    Image defaultImage;

//    void Awake()
//    {
//        initialScale = GetComponent<RectTransform>().localScale;

//        defaultImage = GetComponent<Image>();
//    }

//    void Start()
//    {
//        SetUpCircleImage();
//    }

//    void Update()
//    {

//    }

//    IEnumerator FadeInTesting()
//    {
//        defaultColor = defaultImage.color;
//        defaultColor.a = 0;
//        defaultImage.color = defaultColor;

//        float endTime = fadeInTime + Time.time;
//        float step = 0.02f;
//        float increment = 1f / (fadeInTime / step);
//        Debug.LogError("endTime: " + endTime);
//        while(Time.time < endTime)
//        {
//            defaultColor.a += increment;
//            defaultImage.color = defaultColor;
//            Debug.Log("FadeInTesting increment: " + increment + " defaultColor: " + defaultColor + " time: " + Time.time);
//            yield return new WaitForSeconds(step);
//        }

//        defaultColor = defaultImage.color;
//        defaultColor.a = 1f;
//        defaultImage.color = defaultColor;
//    }

//    protected override void Clicked()
//    {
//        circleImage.gameObject.SetActive(false);
//        OnHotspotInfoClicked(this);
//    }

//    protected override void CustomBehaviour()
//    {
//        circleImage.fillAmount += Time.deltaTime / triggerTime;
//    }

//    protected override void EnterTransition()
//    {
//        SetEnterValues();
//    }

//    protected override void ExitTransition()
//    {
//        SetExitValues();
//    }

//    protected override void SetEnterValues()
//    {
//        GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
//        circleImage.gameObject.SetActive(true);
//        circleImage.fillAmount = 0;
//    }

//    protected override void SetExitValues()
//    {
//        GetComponent<RectTransform>().localScale = initialScale;
//        circleImage.gameObject.SetActive(false);
//    }

//    void SetUpCircleImage()
//    {
//        // Set as child
//        circleImage.gameObject.transform.SetParent(transform);

//        // Image
//        circleImage.type = Image.Type.Filled;
//        circleImage.fillMethod = Image.FillMethod.Radial360;
//        circleImage.fillOrigin = (int)Image.Origin360.Top;
//        circleImage.fillAmount = 0;
//        circleImage.fillClockwise = true;

//        circleImage.gameObject.SetActive(false);
//    }

//    // Fade in
//    protected override void SetFadeInValues()
//    {
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
//        SetFadeOutValues();
//    }


//    // Fade out
//    protected override void SetFadeOutValues()
//    {
//        defaultColor = defaultImage.color;
//        defaultColor.a = 1f;
//        defaultImage.color = defaultColor;
//    }

//    protected override void FadeOutTransition()
//    {
//        float step = 0.02f;
//        float increment = 1f / (fadeInTime / step);
//        defaultColor.a -= increment;
//        defaultImage.color = defaultColor;
//    }

//    protected override void FadeOutFinished()
//    {
//        //throw new NotImplementedException();
//    }
//}
