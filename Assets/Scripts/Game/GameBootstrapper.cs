// Registriert globale Services im ServiceLocator und initialisiert alle IInitializable-Komponenten in der Szene.

using UnityEngine;
using Core;
using Core.Events;
using Core.GameState;

public class GameBootstrapper : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register<IGameStateService>(new GameStateService());
        ServiceLocator.Register<IEventBus>(new EventBus());

        var all = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach (var behaviour in all)
        {
            if (behaviour is IInitializable initializable)
            {
                initializable.Initialize();
            }
        }
    }
}