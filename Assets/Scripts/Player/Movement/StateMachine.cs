// Eine einfache Zustandsmaschine für Spielerbewegung. Unterstützt zustandsabhängige Transitionen auf Basis von Bedingungen.

using System;
using System.Collections.Generic;

namespace Player.Movement
{
    public class StateMachine
    {
        private MovementState _currentState;
        private readonly List<Transition> _transitions = new();
        private List<Transition> _currentTransitions = new();

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);

            _currentState?.Update();
        }

        public void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }

        public void SetState(MovementState state)
        {
            if (_currentState == state)
                return;

            _currentState?.OnExit();
            _currentState = state;
            _currentTransitions = _transitions.FindAll(t => t.From == state);
            _currentState.OnEnter();
        }

        public void AddTransition(MovementState from, MovementState to, Func<bool> condition)
        {
            _transitions.Add(new Transition(from, to, condition));
        }

        private Transition GetTransition()
        {
            foreach (var t in _currentTransitions)
            {
                if (t.Condition())
                    return t;
            }

            return null;
        }

        private class Transition
        {
            public MovementState From;
            public MovementState To;
            public Func<bool> Condition;

            public Transition(MovementState from, MovementState to, Func<bool> condition)
            {
                From = from;
                To = to;
                Condition = condition;
            }
        }
    }
}
