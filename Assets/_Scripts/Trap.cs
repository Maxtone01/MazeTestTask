using _Scripts.Managers;
using UnityEngine;

namespace _Scripts
{
    public class Trap: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventManager.Instance.NotifyPlayerCaptured();
            }
        }
    }
}