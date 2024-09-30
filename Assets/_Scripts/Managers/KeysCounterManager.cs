using System;
using TMPro;
using UnityEngine;

namespace _Scripts.Managers
{
    public class KeysCounterManager: MonoBehaviour
    {
        [SerializeField] private int _keysToOpenFinalDoor;
        [SerializeField] private int _keysPlayerHaves;
        [SerializeField] private TextMeshProUGUI _keysPanel;

        private void Awake()
        {
            _keysPanel.text = 0 + " / " + _keysToOpenFinalDoor;
        }

        public void AddKey()
        {
            _keysPlayerHaves++;
            _keysPanel.text = _keysPlayerHaves + " / " + _keysToOpenFinalDoor;
            if (_keysPlayerHaves == _keysToOpenFinalDoor)
            {
                EventManager.Instance.NotifyFinalDoorOpened();
            }
        }
    }
}