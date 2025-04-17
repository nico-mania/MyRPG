using UnityEngine;
using Core;
using Core.Events;
using Core.Events.Types;

namespace Player.Input
{
    public class PauseInput : MonoBehaviour, IInitializable
    {
        private IEventBus _myEventBus;

        public void Initialize()
        {
            _myEventBus = ServiceLocator.Get<IEventBus>();
        }

        private void Update()
        {
            if (_myEventBus == null) return;

            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                _myEventBus.Publish(new PauseEvent());
                Debug.Log("PauseEvent published");
            }
        }
    }
}
