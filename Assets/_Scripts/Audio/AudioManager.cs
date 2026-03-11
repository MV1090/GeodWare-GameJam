using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    
    public static AudioManager Instance { get; private set; }

    [Header("Persistent looping audio")]
    [SerializeField] private EventReference musicEvent;
    [SerializeField] private EventReference ambienceEvent;

    [Header("One-shot SFX")]
    [SerializeField] private EventReference leverPullEvent;

    private EventInstance musicInstance;
    private EventInstance ambienceInstance;

    private bool musicCreated = false;
    private bool ambienceCreated = false;
    private bool musicPlaying = false;
    private bool ambiencePlaying = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CreatePersistentAudio();
        StartPersistentAudio();
    }

    private void CreatePersistentAudio()
    {
        if (!musicEvent.IsNull && !musicCreated)
        {
            musicInstance = RuntimeManager.CreateInstance(musicEvent);
            musicCreated = true;
        }

        if (!ambienceEvent.IsNull && !ambienceCreated)
        {
            ambienceInstance = RuntimeManager.CreateInstance(ambienceEvent);
            ambienceCreated = true;
        }
    }

    public void PlayOneShot(EventReference eventRef)
    {
        if (!eventRef.IsNull)
        {
            RuntimeManager.PlayOneShot(eventRef);
        }
    }

    public void PlayOneShot(EventReference eventRef, Vector3 worldPosition)
    {
        if (!eventRef.IsNull)
        {
            RuntimeManager.PlayOneShot(eventRef, worldPosition);
        }
    }

    public void StartPersistentAudio()
    {
        if (musicCreated && !musicPlaying)
        {
            musicInstance.start();
            musicPlaying = true;
        }

        if (ambienceCreated && !ambiencePlaying)
        {
            ambienceInstance.start();
            ambiencePlaying = true;
        }
    }

    public void SetMusicParameter(string parameterName, float value)
{
    if (musicCreated)
    {
        musicInstance.setParameterByName(parameterName, value);
    }
}

public void PlayLeverPull()
{
    if (!leverPullEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(leverPullEvent);
    }
}

    public void StopPersistentAudio()
    {
        if (musicCreated && musicPlaying)
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicPlaying = false;
        }

        if (ambienceCreated && ambiencePlaying)
        {
            ambienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            ambiencePlaying = false;
        }
    }

    private void OnDestroy()
    {
        if (Instance != this) return;

        if (musicCreated)
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }

        if (ambienceCreated)
        {
            ambienceInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            ambienceInstance.release();
        }
    }
}
