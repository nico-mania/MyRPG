using UnityEngine;

namespace Core.GameState
{
    public class GameStateService : IGameStateService
    {
        public GameState CurrentState { get; private set; } = GameState.MainMenu;

        public void SetState(GameState newState)
        {
            if (CurrentState != newState)
            {
                CurrentState = newState;
                Debug.Log($"GameState changed to: {CurrentState}");
            }
        }
    }
}
