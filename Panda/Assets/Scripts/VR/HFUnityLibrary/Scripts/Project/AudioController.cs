using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//namespace HappyFinish.Project
//{
[RequireComponent(typeof(AudioSource))]
public class AudioController : Singleton<AudioController>
{
    private AudioController() { }

    [Header("Audio")]
    public AudioClip itemHover;
    public AudioClip itemSelected;
    public AudioSource m_audioAuxiliar;

    private AudioSource m_audio;
    private float m_pitchCurrentValue;
    private float m_pitchSpeedUpValue;
    private float m_pitchSlowDownValue;

	private List<AudioSource> poolableSources = new List<AudioSource>();
	private List<AudioSource> playingSources = new List<AudioSource>();

	// ================================
	// DEFAULT UNITY
	// ================================
	private void Awake()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        //m_bool_pitchSlowDown = false;
        //m_bool_pitchSpeedUp = false;
    }

	void Update()
	{
		for (int i = playingSources.Count - 1; i >= 0; i--)
		{
			if (!playingSources[i].isPlaying)
			{
				AddPoolable(playingSources[i]);
				playingSources.RemoveAt(i);
			}
		}
	}

	// ================================
	// PUBLIC FUNTIONS
	// ================================
    
    //public T GetSceneController<T>() where T : class
    //{
    //    return sceneAudioController as T;
    //}

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

	public void PlayPoolableSound(AudioClip clip, float volume)
	{
		AudioSource toUse = poolableSources.FirstOrDefault();
		if (!toUse)
		{
			toUse = gameObject.AddComponent<AudioSource>();
		}
		toUse.clip = clip;
		toUse.loop = false;
		toUse.playOnAwake = false;
		toUse.volume = volume;
		toUse.Play();
		playingSources.Add(toUse);
		poolableSources.Remove(toUse);
	}

	void AddPoolable(AudioSource s)
	{
		poolableSources.Add(s);
	}

    public void VolumeChange(float volume)
    {
        m_audio.volume = volume;
    }

    public void VolumeChange(float from, float to, float time)
    {
        Debug.LogError("VolumeChange TODO");
        //if (time <= 0)
        //{
        //    m_audio.volume = from;
        //}
        //else
        //{
        //    StartCoroutine(VolumeTransition(from, to, time));
        //}
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


    public void PlayClip(AudioClip clip, float volume = 1)
    {
        m_audio.volume = volume;
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



    // ================================
    // HELPER FUNCTIONS
    // ================================
}
//}