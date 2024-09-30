using _Scripts.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private TimerController _timerController;
        public bool IsGameEnd { get; private set; }

        private void Awake()
        {
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnPlayerCaptured -= SetEndGameState;
            EventManager.Instance.OnGameWin -= SetEndGameState;
        }

        private void SetEndGameState()
        {
            IsGameEnd = true;
        }

        public void Start()
        {
            EventManager.Instance.OnPlayerCaptured += SetEndGameState;
            EventManager.Instance.OnGameWin += SetEndGameState;
            
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
            _timerController.StartTimer();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        
        public void ActivateFirstScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }

        public void SetPause(bool isPaused)
        {
            GameContext.Instance.PauseManagerObject.SetPause(isPaused);
            EventManager.Instance.NotifyPauseSet();
        }
    }
}
