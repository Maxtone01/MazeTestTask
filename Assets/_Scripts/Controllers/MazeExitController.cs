using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class MazeExitController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventManager.Instance.NotifyGameWin();
            }
        }
    }
}
