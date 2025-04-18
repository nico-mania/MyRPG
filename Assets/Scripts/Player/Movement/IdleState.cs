// Repräsentiert den Bewegungszustand, in dem der Spieler stillsteht und keine Bewegung ausführt.

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
