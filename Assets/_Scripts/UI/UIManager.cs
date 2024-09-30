using System;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIManager: MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _endGameMenu;
        [SerializeField] private GameObject _winGameMenu;

        private void Start()
        {
            EventManager.Instance.OnPauseSet += ShowHidePauseMenu;
            EventManager.Instance.OnPlayerCaptured += ShowEndGamePanel;
            EventManager.Instance.OnGameWin += ShowWinScreen;
        }
        
        private void OnDisable()
        {
            EventManager.Instance.OnPauseSet -= ShowHidePauseMenu;
            EventManager.Instance.OnPlayerCaptured -= ShowEndGamePanel;
            EventManager.Instance.OnGameWin -= ShowWinScreen;
        }

        public void ShowHidePauseMenu()
        {
            Cursor.visible = !_pauseMenu.activeSelf;
            _pauseMenu.gameObject.SetActive(!_pauseMenu.activeSelf);
        } 

        private void ShowEndGamePanel()
        {
            _endGameMenu.SetActive(true);
        }

        private void ShowWinScreen()
        {
            _winGameMenu.SetActive(true);
        }
    }
}
