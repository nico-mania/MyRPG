// Reagiert auf ein PauseEvent und friert das Spiel durch Setzen des TimeScale ein oder hebt es auf.

using UnityEngine;
using Core;
using Core.Events;
using Core.Events.Types;

namespace UI
{
    public class PauseMenuHandler : MonoBehaviour, IInitializable
    {
        private IEventBus _eventBus;
        private bool _isPaused = false;

        public void Initialize()
        {
            _eventBus = ServiceLocator.Get<IEventBus>();
            _eventBus.Subscribe<PauseEvent>(OnPauseEvent);
        }

        private void OnDestroy()
        {
            _eventBus?.Unsubscribe<PauseEvent>(OnPauseEvent);
        }

        private void OnPauseEvent(PauseEvent e)
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0f : 1f;
        }
    }
}
