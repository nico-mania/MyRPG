// Repr�sentiert den Bewegungszustand, in dem der Spieler stillsteht und keine Bewegung ausf�hrt.

namespace Player.Movement
{
    public class IdleState : MovementState
    {
        public IdleState(Controller.PlayerController controller, StateMachine stateMachine)
            : base(controller, stateMachine)
        {
        }

        public override void Update()
        {
        }
    }
}
