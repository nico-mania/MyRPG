// Reagiert auf die Pause-Aktion aus dem InputSystem und veröffentlicht ein entsprechendes Event über den EventBus.

using UnityEngine;
using Core;
using Core.Events;
using Core.Events.Types;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PauseInput : MonoBehaviour, IInitializable
    {
        private IEventBus _eventBus;
        private PlayerInputActions _actions;

        public void Initialize()
        {
            _eventBus = ServiceLocator.Get<IEventBus>();
            _actions = new PlayerInputActions();

            _actions.Enable();
            _actions.Player.Enable();

            _actions.Player.Pause.started += _ =>
            {
                _eventBus?.Publish(new PauseEvent());
            };
        }

        private void OnEnable()
        {
            _actions?.Enable();
            _actions?.Player.Enable();
        }

        private void OnDisable()
        {
            _actions?.Player.Disable();
            _actions?.Disable();
        }
    }
}
