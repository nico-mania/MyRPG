using UnityEngine;

namespace Player.Controller
{
    public class PlayerLookHandler : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f;

        private PlayerInputActions _actions;
        private Animator _animator;

        private void Awake()
        {
            _actions = new PlayerInputActions();
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable()
        {
            _actions.Enable();
            _actions.Player.Enable();
        }

        private void OnDisable()
        {
            _actions.Player.Disable();
            _actions.Disable();
        }

        private void Update()
        {
            Vector2 lookDelta = _actions.Player.Look.ReadValue<Vector2>();
            float yaw = lookDelta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(0f, yaw, 0f);
        }
    }
}
