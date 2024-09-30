using System;
using UnityEngine;

namespace _Scripts.Managers
{
    public class EventManager: MonoBehaviour
    {
        public Action OnPauseSet;
        public Action OnPlayerCaptured;
        public Action OnFinalDoorOpened;
        public Action OnGameWin;
        
        public static EventManager Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this;
        }
        
        public void NotifyPauseSet()
        {
            OnPauseSet?.Invoke();
        }

        public void NotifyPlayerCaptured()
        {
            OnPlayerCaptured?.Invoke();
        }

        public void NotifyFinalDoorOpened()
        {
            OnFinalDoorOpened?.Invoke();
        }
        
        public void NotifyGameWin()
        {
            OnGameWin?.Invoke();
        }
    }
}