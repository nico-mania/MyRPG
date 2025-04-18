// Liest die Eingaben aus dem InputSystem und speichert sie für den Zugriff durch andere Komponenten wie den PlayerController.

using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class InputReader : MonoBehaviour
    {
        private PlayerInputActions _actions;

        public Vector2 MovementValue { get; private set; }
        public bool JumpPressed { get; private set; }

        private void Awake()
        {
            _actions = new PlayerInputActions();

            _actions.Player.Move.performed += ctx => MovementValue = ctx.ReadValue<Vector2>();
            _actions.Player.Move.canceled += _ => MovementValue = Vector2.zero;

            _actions.Player.Jump.started += _ => JumpPressed = true;
            _actions.Player.Jump.canceled += _ => JumpPressed = false;

            _actions.Player.Pause.started += _ =>
            {
                // Optional: Hier könnte ein PauseEvent über EventBus ausgelöst werden
            };
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
    }
}
