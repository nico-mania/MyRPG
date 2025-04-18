// Übergibt die Input-Werte aus dem InputReader an den PlayerController zur Laufzeit.

using UnityEngine;
using Player.Input;

namespace Player.Controller
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController _controller;

        [SerializeField] private InputReader _inputReader;

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (_controller == null || _inputReader == null)
                return;

            _controller.MovementInput = _inputReader.MovementValue;
            _controller.JumpPressed = _inputReader.JumpPressed;
        }
    }
}
