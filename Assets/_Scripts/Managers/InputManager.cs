using UnityEngine;

namespace _Scripts.Managers
{
    public class InputManager: MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) & !GameManager.Instance.IsGameEnd)
            {
                EnableDisablePause();
            }
        }
        
        private static void EnableDisablePause()
        {
            GameContext.Instance.PauseManager.SetPause(!GameContext.Instance.PauseManager.IsPaused);
            GameManager.Instance.SetPause(true);
            EventManager.Instance.NotifyPauseSet();
        }
    }
}