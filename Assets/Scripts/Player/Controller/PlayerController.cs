// Steuert die physische Bewegung des Spielers über Rigidbody und verwaltet den Bewegungszustand über eine StateMachine.

using UnityEngine;
using Player.Movement;

namespace Player.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 5f;

        private StateMachine _stateMachine;
        private Rigidbody _rb;
        private GroundChecker _groundChecker;

        public Vector2 MovementInput { get; set; }
        public bool JumpPressed { get; set; }

        public bool IsGrounded => _groundChecker != null && _groundChecker.IsGrounded;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _groundChecker = GetComponent<GroundChecker>();

            _stateMachine = new StateMachine();
            var idle = new IdleState(this, _stateMachine);
            var moving = new MovingState(this, _stateMachine);
            var jumping = new JumpingState(this, _stateMachine);

            _stateMachine.AddTransition(idle, moving, () => MovementInput.magnitude > 0.1f);
            _stateMachine.AddTransition(moving, idle, () => MovementInput.magnitude <= 0.1f);
            _stateMachine.AddTransition(moving, jumping, () => JumpPressed && IsGrounded);
            _stateMachine.AddTransition(idle, jumping, () => JumpPressed && IsGrounded);
            _stateMachine.AddTransition(jumping, idle, () => IsGrounded && _rb.linearVelocity.y <= 0.01f);

            _stateMachine.SetState(idle);
        }

        private void Update()
        {
            _stateMachine.Update();
            JumpPressed = false;
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public void Move(Vector3 direction)
        {
            Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + movement);
        }

        public void Jump()
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
