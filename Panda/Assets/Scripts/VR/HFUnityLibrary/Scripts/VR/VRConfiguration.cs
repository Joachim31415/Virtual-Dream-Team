using UnityEngine;
using UnityEngine.VR;

namespace HappyFinish.VR
{
    public class VRConfiguration : MonoBehaviour
    {
        [Header("VR Render scale")]
        [Tooltip("This value improves the smoothness of the edges, trades smoothness for performance, the bigger the value the worst the performance, default value 1")]
        [SerializeField]
        private float m_RenderScale = 1.4f;

        public void SetupVR()
        {
            VRSettings.enabled = true;

            //Gear VR does not currently support renderScale
            #if !UNITY_ANDROID
            VRSettings.renderScale = m_RenderScale;
            #endif

            #if UNITY_STANDALONE
            //VRSettings.loadedDevice = VRDeviceType.Oculus;
            #endif

            #if UNITY_PS4 && !UNITY_EDITOR
		    VRSettings.loadedDevice = VRDeviceType.Morpheus;
            #endif
        }
    }
}