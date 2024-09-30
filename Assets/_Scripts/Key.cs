using _Scripts.Managers;
using UnityEngine;

namespace _Scripts
{
    public class Key: MonoBehaviour
    {
        [SerializeField] private KeysCounterManager _keysCounterManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _keysCounterManager.AddKey();
                Destroy(gameObject);
            }
        }
    }
}