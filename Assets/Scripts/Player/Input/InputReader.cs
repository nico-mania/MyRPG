// Liest einzelne Richtungsaktionen und kombiniert sie zu einem Bewegungsvektor.

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
        }

        private void OnEnable()
        {
            _actions.Enable();
            _actions.Player.Enable();

            _actions.Player.Jump.started += _ => JumpPressed = true;
            _actions.Player.Jump.canceled += _ => JumpPressed = false;
        }

        private void OnDisable()
        {
            _actions.Player.Disable();
            _actions.Disable();
        }

        private void Update()
        {
            float x = 0f;
            float y = 0f;

            if (_actions.Player.MoveLeft.IsPressed()) x -= 1f;
            if (_actions.Player.MoveRight.IsPressed()) x += 1f;
            if (_actions.Player.MoveBackwards.IsPressed()) y -= 1f;
            if (_actions.Player.MoveForward.IsPressed()) y += 1f;

            MovementValue = new Vector2(x, y).normalized;
        }
    }
}
