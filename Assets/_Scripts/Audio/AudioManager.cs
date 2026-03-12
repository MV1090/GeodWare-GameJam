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
    [SerializeField] private EventReference spritesFallEvent;
    [SerializeField] private EventReference jumpEvent;
    [SerializeField] private EventReference landingEvent;
    [SerializeField] private EventReference spriteCollectEvent;
    [SerializeField] private EventReference waterDropEvent;
    [SerializeField] private EventReference buildPlatformEvent;
    [SerializeField] private EventReference createWhirlwindEvent;
    [SerializeField] private EventReference startFireEvent;
    [SerializeField] private EventReference impaleEvent;

    [Header("Looping SFX")]
    [SerializeField] private EventReference footstepLoopEvent;
    [SerializeField] private EventReference fireLoopEvent;

    private EventInstance musicInstance;
    private EventInstance ambienceInstance;
    private EventInstance footstepInstance;
    private EventInstance fireLoopInstance;
    
    private bool fireLoopPlaying = false;
    private bool musicCreated = false;
    private bool ambienceCreated = false;
    private bool musicPlaying = false;
    private bool ambiencePlaying = false;
    private bool footstepPlaying = false;

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
        StartMusic();
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

    public void StartMusic()
{
    if (musicCreated && !musicPlaying)
    {
        musicInstance.start();
        musicPlaying = true;
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

    public void StartAmbience()
{
    if (ambienceCreated && !ambiencePlaying)
    {
        ambienceInstance.start();
        ambiencePlaying = true;
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

    public void SetMusicState(float state)
{
    if (musicCreated)
    {
        musicInstance.setParameterByName("Music State", state);
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

    public void PlaySpriteCollect(Vector3 worldPosition)
{
    if (!spriteCollectEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(spriteCollectEvent, worldPosition);
    }
}

public void PlayWaterDrop(Vector3 worldPosition)
{
    if (!waterDropEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(waterDropEvent, worldPosition);
    }
}

public void PlayBuildPlatform(Vector3 worldPosition)
{
    if (!buildPlatformEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(buildPlatformEvent, worldPosition);
    }
}

public void PlayCreateWhirlwind(Vector3 worldPosition)
{
    if (!createWhirlwindEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(createWhirlwindEvent, worldPosition);
    }
}

public void PlayStartFire(Vector3 worldPosition)
{
    if (!startFireEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(startFireEvent, worldPosition);
    }
}

    public void PlaySpritesFall()
    {
        if (!spritesFallEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(spritesFallEvent);
        }
    }

    public void PlayJump()
    {
        if (!jumpEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(jumpEvent);
        }
    }

    public void PlayLanding(Vector3 worldPosition)
{
    if (!landingEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(landingEvent, worldPosition);
    }
}

public void PlayImpale(Vector3 worldPosition)
{
    if (!impaleEvent.IsNull)
    {
        RuntimeManager.PlayOneShot(impaleEvent, worldPosition);
    }
}

    public void StartFootsteps(GameObject playerObject)
{
    if (!footstepPlaying && !footstepLoopEvent.IsNull)
    {
        footstepInstance = RuntimeManager.CreateInstance(footstepLoopEvent);

        RuntimeManager.AttachInstanceToGameObject(
            footstepInstance,
            playerObject.transform,
            playerObject.GetComponent<Rigidbody2D>()
        );

        footstepInstance.start();
        footstepPlaying = true;
    }
}

    public void StopFootsteps()
    {
        if (footstepPlaying)
        {
            footstepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            footstepInstance.release();
            footstepPlaying = false;
        }
    }

    public void StartFireLoop(GameObject fireObject)
{
    if (!fireLoopPlaying && !fireLoopEvent.IsNull)
    {
        fireLoopInstance = RuntimeManager.CreateInstance(fireLoopEvent);

        Rigidbody2D rb2D = fireObject.GetComponent<Rigidbody2D>();

        RuntimeManager.AttachInstanceToGameObject(
            fireLoopInstance,
            fireObject.transform,
            rb2D
        );

        fireLoopInstance.start();
        fireLoopPlaying = true;
    }
}

public void StopFireLoop()
{
    if (fireLoopPlaying)
    {
        fireLoopInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        fireLoopInstance.release();
        fireLoopPlaying = false;
    }
}

    private void OnDestroy()
    {
        if (Instance != this) return;

        if (footstepPlaying)
        {
            footstepInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            footstepInstance.release();
        }

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
