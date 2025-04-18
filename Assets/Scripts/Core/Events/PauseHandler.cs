// Setzt den GameState auf "Paused", wenn die Escape-Taste gedr�ckt wird.

using UnityEngine;
using Core.GameState;

public class PauseHandler : MonoBehaviour
{
    private IGameStateService _gameStateService;

    private void Awake()
    {
        _gameStateService = ServiceLocator.Get<IGameStateService>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameStateService.SetState(GameState.Paused);
        }
    }
}
