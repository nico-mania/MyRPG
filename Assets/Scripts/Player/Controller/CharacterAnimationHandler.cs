using UnityEngine;
using Player.Controller;
using Player.Movement;

namespace Player.Input
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private PlayerInputActions _actions;
        private GroundChecker _groundChecker;

        [SerializeField] private float turnThreshold = 0.5f;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _groundChecker = GetComponent<GroundChecker>();
            _actions = new PlayerInputActions();
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
            _animator.SetBool("IsRunningForward", _actions.Player.MoveForward.IsPressed());
            _animator.SetBool("IsRunningBackwards", _actions.Player.MoveBackwards.IsPressed());
            _animator.SetBool("IsStrafingLeft", _actions.Player.MoveLeft.IsPressed());
            _animator.SetBool("IsStrafingRight", _actions.Player.MoveRight.IsPressed());
          
            bool isJumping = !_groundChecker.IsGrounded;
            _animator.SetBool("IsRunJumping", isJumping);
            _animator.SetBool("IsStandJumping", isJumping);

            // Mausbewegung horizontal (für Drehung)
            Vector2 lookDelta = _actions.Player.Look.ReadValue<Vector2>();
            float horizontalLook = lookDelta.x;

            // Turn nur wenn Charakter stillsteht
            bool turnLeft = horizontalLook < -turnThreshold;
            bool turnRight = horizontalLook > turnThreshold;

            _animator.SetBool("IsTurningLeft", turnLeft);
            _animator.SetBool("IsTurningRight", turnRight);
        }
    }
}
