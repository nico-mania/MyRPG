// Bewegt den Spieler im Sprung mit begrenzter Luftkontrolle. Führt einen einmaligen Jump beim Eintritt in den Zustand aus.

using UnityEngine;

namespace Player.Movement
{
    public class JumpingState : MovementState
    {
        private bool _hasJumped = false;

        public JumpingState(Controller.PlayerController controller, StateMachine stateMachine)
            : base(controller, stateMachine)
        {
        }

        public override void OnEnter()
        {
            _hasJumped = false;
        }

        public override void FixedUpdate()
        {
            if (!_hasJumped)
            {
                Controller.Jump();
                _hasJumped = true;
            }

            Vector3 moveDir = new Vector3(Controller.MovementInput.x, 0, Controller.MovementInput.y);
            Controller.Move(moveDir * 0.5f);
        }
    }
}
