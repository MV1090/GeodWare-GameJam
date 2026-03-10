using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [BankRef]
    public string musicBank = "Music";

    public EventReference musicEvent;

    private EventInstance musicInstance;

    void Awake()
    {
        // Prevent duplicates
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Load bank
        RuntimeManager.LoadBank(musicBank, true);

        // Create and start event
        musicInstance = RuntimeManager.CreateInstance(musicEvent);
        musicInstance.start();
    }

    void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();
    }
}
