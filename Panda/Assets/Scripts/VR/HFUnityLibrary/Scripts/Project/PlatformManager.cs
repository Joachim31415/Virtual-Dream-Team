using UnityEngine;
using System.Collections.Generic;
using HappyFinish.VR;

namespace HappyFinish.Project
{
    public class PlatformManager : MonoBehaviour
    {
        private PlatformManager() { }

        private static PlatformManager instance;
        public static PlatformManager Instance
        {
            get
            {
                //   
                if (!instance)
                {
                    instance = GameObject.FindGameObjectWithTag("PlatformManager").GetComponent<PlatformManager>();
                }

                if (!instance)
                {
                    instance = GameObject.Find("PlatformManager").GetComponent<PlatformManager>(); ;
                }

                if (!instance)
                {
                    instance = FindObjectOfType<PlatformManager>();
                }

                if (!instance)
                {
                    //    DontDestroyOnLoad(instance.gameObject);
                    //}
                    //else
                    //{
                    Debug.LogError("PlatformManager - There is no PlatformManager GameObject");
                }

                return instance;
            }
        }

        [Header("HTC Vive root")]
        //public GameObject ViveControllers;
        public GameObject MainCamera;
        public GameObject Reticle;
        public GameObject ViveRoot;
        public GameObject ViveCamera;

        [Header("Platforms")]
        public GameObject[] childsObjectsPlatforms;

        //public List<PlatformTarget> supportedPlatforms;
        public enum PlatformTarget
        {
            None = 0,
            Windows = 1,
            MacOS = 2,
            Cardboard = 4,
            Mobile = 8,
            GearVR = 16,
            Oculus = 32,
            Vive = 128
        }

        [Header("Current Platform")]
        public PlatformTarget currentPlatform;

        public VRConfiguration VRConfig;

        public bool IsVRSupported
        {
            get
            {
                return  currentPlatform == PlatformTarget.GearVR || currentPlatform == PlatformTarget.Oculus || currentPlatform == PlatformTarget.Vive;
            }
        }


        private GazeGestureVR gazeRayCaster;

        private void Awake()
        {
            DisablePlatformsInChildren();
            SetupManager();
        }

        private void DisablePlatformsInChildren()
        {
            foreach (var platform in childsObjectsPlatforms)
            {
                if (currentPlatform.ToString() == platform.name)
                {
                    platform.SetActive(true);

                    if (IsVRSupported)
                    {
                        gazeRayCaster = platform.GetComponent<GazeGestureVR>();
                    }
                }
                else
                {
                    platform.SetActive(false);
                }
            }
        }

        private void SetupManager()
        {
            if (currentPlatform == PlatformTarget.None)
            {
                Debug.LogError("Select platform in PlatformManager");
                return;
            }

            switch (currentPlatform)
            {
                case PlatformTarget.None:
                    break;
                case PlatformTarget.Windows:
                    break;
                case PlatformTarget.MacOS:
                    break;
                case PlatformTarget.Cardboard:
                    break;
                case PlatformTarget.Mobile:
                    break;
                case PlatformTarget.GearVR:
                case PlatformTarget.Oculus:
                    VRConfig.SetupVR();
                    break;
                case PlatformTarget.Vive:
                    ViveCameraSetup();
                    break;
                default:
                    break;
            }

            if (currentPlatform != PlatformTarget.Vive)
            {
                NonViveCameraSetup();
            }
        }

        public GazeGestureVR GetGazeGestureVR()
        {
            if (currentPlatform == PlatformTarget.GearVR || currentPlatform == PlatformTarget.Oculus || currentPlatform == PlatformTarget.Vive)
                return gazeRayCaster;
            else
                return null;
        }

        private void ViveCameraSetup()
        {
            //ViveControllers.SetActive(true);
            MainCamera.SetActive(false);
            ViveRoot.SetActive(true);
            Reticle.transform.SetParent(ViveCamera.transform);
        }

        private void NonViveCameraSetup()
        {
            //ViveControllers.SetActive(false);
            MainCamera.SetActive(true);
            ViveRoot.SetActive(false);
            Reticle.transform.SetParent(MainCamera.transform);
        }
    }
}