// Abstrakte Basisklasse für Bewegungszustände des Spielers. Bietet optionale Lifecycle-Hooks wie Enter, Update und Exit.

namespace Player.Movement
{
    public abstract class MovementState
    {
        protected readonly Controller.PlayerController Controller;
        protected readonly StateMachine StateMachine;

        protected MovementState(Controller.PlayerController controller, StateMachine stateMachine)
        {
            Controller = controller;
            StateMachine = stateMachine;
        }

        public virtual void OnEnter() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void OnExit() { }
    }
}
