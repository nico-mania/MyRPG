using UnityEngine;
using Core;
using Core.Events;
using Core.Events.Types;

namespace UI
{
    public class PauseMenuHandler : MonoBehaviour, IInitializable
    {
        private IEventBus _eventBus;

        public void Initialize()
        {
            _eventBus = ServiceLocator.Get<IEventBus>();
            _eventBus.Subscribe<PauseEvent>(OnPauseEvent);
        }

        private void OnDestroy()
        {
            if (_eventBus != null)
            {
                _eventBus.Unsubscribe<PauseEvent>(OnPauseEvent);
            }
        }

        private void OnPauseEvent(PauseEvent e)
        {
            Debug.Log("PauseMenuHandler received PauseEvent");
        }
    }
}
