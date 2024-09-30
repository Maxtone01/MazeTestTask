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
            GameManager.Instance.SetPause(!GameContext.Instance.PauseManagerObject.IsPaused);
        }
    }
}