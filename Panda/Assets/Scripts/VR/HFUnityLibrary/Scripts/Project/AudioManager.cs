using UnityEngine;
using System.Collections;

namespace HappyFinish.Project
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        private AudioManager() { }
        private static AudioManager instance;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
                }

                if (instance == null)
                {
                    instance = GameObject.Find("AudioManager").GetComponent<AudioManager>(); ;
                }

                if (!instance)
                    Debug.LogError("AudioManager - There is no AudioManager GameObject");

                return instance;
            }
        }

        public AudioClip itemHover;
        public AudioClip itemSelected;
        //public AudioClip backgroundSound;

        public AudioSource m_audioAuxiliar;
        //public bool m_bool_pitchSpeedUp = false;
        //public bool m_bool_pitchSlowDown = false;

        private AudioSource m_audio;

        private float m_pitchCurrentValue;
        private float m_pitchSpeedUpValue;
        private float m_pitchSlowDownValue;

        void Awake()
        {
            m_audio = GetComponent<AudioSource>();
        }

        void Start()
        {
            //m_bool_pitchSlowDown = false;
            //m_bool_pitchSpeedUp = false;
        }

        //void Update()
        //{
        //    CheckPitchSpeedUp();
        //    CheckPitchSlowDown();
        //}

        //private void CheckPitchSpeedUp()
        //{
        //    if (m_bool_pitchSpeedUp)
        //    {
        //        var currentPitch = _audio.pitch;
        //        var newPitch = currentPitch + Time.deltaTime;

        //        if (newPitch > m_pitchSpeedUpValue)
        //        {
        //            m_bool_pitchSpeedUp = false;
        //            newPitch = m_pitchSpeedUpValue;
        //        }

        //        PitchChange(newPitch);
        //    }
        //}

        //private void CheckPitchSlowDown()
        //{
        //    if (m_bool_pitchSlowDown)
        //    {
        //        var currentPitch = _audio.pitch;
        //        var newPitch = currentPitch - Time.deltaTime * 4f;

        //        if (newPitch < m_pitchSlowDownValue)
        //        {
        //            m_bool_pitchSlowDown = false;
        //            newPitch = m_pitchSlowDownValue;
        //        }

        //        PitchChange(newPitch);
        //    }
        //}
        //public void PlayDefaultClip()
        //{
        //    m_audio.volume = 1f;
        //    m_audio.Stop();
        //    m_audio.Play();
        //}

        public void VolumeChange(float from, float to = 0, float time = 0)
        {
            if (time <= 0)
            {
                m_audio.volume = from;
            }
            else
            {
                StartCoroutine(VolumeTransition(from, to, time));
            }
        }

        private IEnumerator VolumeTransition(float from, float to, float time)
        {
            // TODO Why I need to double up the time in order to get the correct time?
            //Debug.LogWarning("1 - VolumeTransition: " + Time.time);
            time *= 2;
            m_audio.volume = from;
            while (m_audio.volume < to)
            {
                m_audio.volume += Time.deltaTime / time;
                yield return new WaitForSeconds(Time.deltaTime / time);
            }
            m_audio.volume = to;
            //Debug.LogWarning("2 - VolumeTransition: " + Time.time);
        }


        public void PlayClip(AudioClip clip)
        {
            m_audio.volume = 1f;
            m_audio.Stop();
            m_audio.clip = clip;
            m_audio.Play();
        }

        public void PlayOnce(AudioClip clip)
        {
            m_audio.volume = 1f;
            m_audio.PlayOneShot(clip);
        }

        public void PlayItemHover()
        {
            m_audio.volume = 1f;
            m_audio.PlayOneShot(itemHover);
        }

        public void PlayItemSelected()
        {
            m_audio.volume = 1f;
            m_audio.PlayOneShot(itemSelected);
        }

        public void StopAudio()
        {
            m_audio.Stop();
        }

        public void PitchChange(float pitchValue)
        {
            m_audio.volume = 1f;
            m_audio.pitch = pitchValue;
        }

        //public void PitchSlowDown(float pitchValue)
        //{
        //    m_bool_pitchSlowDown = true;
        //    m_pitchSlowDownValue = pitchValue;
        //}

        //public void PitchSpeedUp(float pitchValue)
        //{
        //    m_bool_pitchSpeedUp = true;
        //    m_pitchSpeedUpValue = pitchValue;
        //}

        public void PitchReset()
        {
            m_audio.volume = 1f;
            m_audio.pitch = 1f;
        }

        public float GetLenghtCurrentClip()
        {
            return m_audio.clip.length;
        }

        //public void PlayBackgroundStadiumAudio()
        //{
        //    m_audioAuxiliar.loop = true;
        //    m_audioAuxiliar.volume = 0.3f;
        //    m_audioAuxiliar.clip = backgroundSound;
        //    m_audioAuxiliar.Play();
        //}

        public void PlayClipInAuxiliar(AudioClip audioClip, float volume = 1f, bool loop = true)
        {
            m_audioAuxiliar.loop = loop;
            m_audioAuxiliar.volume = volume;
            m_audioAuxiliar.clip = audioClip;
            m_audioAuxiliar.Play();
        }

        public void PlayOnceInAuxiliar(AudioClip clip, float volume = 1f)
        {
            m_audioAuxiliar.volume = volume;
            m_audioAuxiliar.PlayOneShot(clip);
        }
    }
}