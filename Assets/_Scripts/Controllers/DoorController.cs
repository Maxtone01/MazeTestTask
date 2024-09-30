using System;
using _Scripts.Managers;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private bool _isFinalDoor;

    [SerializeField] private Animator _animator;
    private void Start()
    {
        EventManager.Instance.OnPlayerCaptured += CloseDoor;
        EventManager.Instance.OnFinalDoorOpened += OpenDoor;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerCaptured -= CloseDoor;
        EventManager.Instance.OnFinalDoorOpened -= OpenDoor;
    }

    private void CloseDoor()
    {
        _animator.SetBool("Close Door", true);
    }

    private void OpenDoor()
    {
        if (_isFinalDoor)
        {
            _animator.SetBool("Open Door", true);
        }
    }
}
