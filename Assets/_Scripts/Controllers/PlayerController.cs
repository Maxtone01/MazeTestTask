using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        public float cameraPitch = 0f;
        public float mouseSensitivity;
    
        private void Update()
        {
            UpdateCameraLook();
        }

        /* Method, that responsible for player to look and rotate on specific position along mouse moving.
         Rotates only along x axis. */
        private void UpdateCameraLook()
        {
            if (GameManager.Instance.IsGameEnd | GameContext.Instance.IsPaused) return;
        
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            cameraPitch -= mouseDelta.y * mouseSensitivity;
            cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

            playerCamera.localEulerAngles = Vector3.right * cameraPitch;
            transform.Rotate(Vector3.up * mouseDelta.x);
        }
    }
}
