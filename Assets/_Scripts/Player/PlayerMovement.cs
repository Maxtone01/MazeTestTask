using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float walkSpeed;
        public float runSpeed;
        private float _playerSpeed;
        private bool isRunning;
        private Vector2 _currentDir = Vector2.zero;
        private Vector2 _currentDirVelocity = Vector2.zero;
        private const float MoveSmoothTime = 0.02f;

        private void Update()
        {
            if (!GameContext.Instance.IsPaused & !GameManager.Instance.IsGameEnd)
            {
                MovePlayer();
            }

            isRunning = Input.GetKey(KeyCode.LeftShift);
        }
        
        /* Method, responsible for the player movement */
        private void MovePlayer()
        {
            Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            inputDir.Normalize();

            _currentDir = Vector2.SmoothDamp(_currentDir, inputDir, ref _currentDirVelocity, MoveSmoothTime);

            _playerSpeed = isRunning ? runSpeed : walkSpeed;
            
            var velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x) * _playerSpeed;

            transform.Translate(velocity * (_playerSpeed * Time.deltaTime), Space.World);
        }
    }
}
