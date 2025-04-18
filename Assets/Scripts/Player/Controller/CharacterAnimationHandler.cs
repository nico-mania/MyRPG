// Schaltet zwischen Idle und Running Animation basierend auf Tastendruck (nur W).

using UnityEngine;
using UnityEngine.InputSystem;
using Player.Controller;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        bool forwardPressed = Keyboard.current.wKey.isPressed;
        _animator.SetBool("IsRunningForward", forwardPressed);
    }
}
