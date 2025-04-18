// Führt kontinuierliche Bewegung des Spielers basierend auf Input aus, solange sich der Spieler im Bewegungszustand befindet.

using UnityEngine;

namespace Player.Movement
{
    public class MovingState : MovementState
    {
        public MovingState(Controller.PlayerController controller, StateMachine stateMachine)
            : base(controller, stateMachine)
        {
        }

        public override void FixedUpdate()
        {
            Vector3 moveDirection = new Vector3(Controller.MovementInput.x, 0, Controller.MovementInput.y);
            Controller.Move(moveDirection);
        }
    }
}
