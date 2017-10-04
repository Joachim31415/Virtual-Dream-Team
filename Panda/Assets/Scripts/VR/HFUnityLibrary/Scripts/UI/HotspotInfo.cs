//using UnityEngine;


//[ExecuteInEditMode]
//public abstract class HotspotInfo : Hotspot
//{
//    public enum HotspotType
//    {
//        None,
//        Mission,
//        Persona,
//        ProductInformation,
//        Cabin,
//        Cockpit,
//        TakeOff,
//        Landing,
//        Skip,
//        Back,
//        Home,
//        Hangar
//    }

//    [Header("Hotspot type")]
//    public HotspotType hotspotType;

//    [Header("Hotspot content")]
//    public ContentType.Mission mission;
//    public ContentType.Persona persona;

//    [Header ("Product information")]
//    public DataModel.Products product;
//    public Vector3 offsetTextWindow;
//    public RectTransform hotspotRectTransform;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        //if (hotspotType == HotspotType.None)
//        //    Debug.LogError("Assign a type to the Hotspot in " + gameObject.name);

//        //if (hotspotType != HotspotType.Mission)
//        //    mission = ContentType.Mission.None;

//        //if (hotspotType != HotspotType.Persona)
//        //    persona = ContentType.Persona.None;

//        //if (hotspotType != HotspotType.ProductInformation)
//        //    product = DataModel.Products.None;
//    }

//    public delegate void HotspotInfoClickEventHandler(HotspotInfo sender); // Instead of doing "HotspotInfoClicked(hotspotType, mission, persona);" the parameter is the class
//    public static event HotspotInfoClickEventHandler HotspotInfoClicked = delegate { }; // Doing "= delegate {};" there is no need to do "if (HotspotInfoClicked != null)"

//    protected virtual void OnHotspotInfoClicked(HotspotInfo sender)
//    {
//        // Doing "= delegate {};" there is no need to do "if (HotspotInfoClicked != null)"
//        HotspotInfoClicked(this); 
//    }
//}
