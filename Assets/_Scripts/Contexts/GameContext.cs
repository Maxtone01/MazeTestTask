using Assets.Scripts.Interfaces;
using UnityEngine;

public class GameContext : MonoBehaviour, IPauseHandler
{
    public PauseManager PauseManagerObject { get; private set; }

    public static GameContext Instance { get; private set; }

    public bool IsPaused => PauseManagerObject.IsPaused;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        Initialize();
        PauseManagerObject.Register(this);
    }

    private void Initialize()
    {
        PauseManagerObject = new PauseManager();
    }

    public void SetPause(bool isPaused)
    {
        
    }
}
