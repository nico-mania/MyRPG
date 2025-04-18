// Definiert den Zugriff auf den aktuellen GameState sowie die Möglichkeit, diesen zu ändern.
// Das zugehörige Enum beschreibt die möglichen globalen Zustände des Spiels.

namespace Core.GameState
{
    public interface IGameStateService
    {
        GameState CurrentState { get; }
        void SetState(GameState newState);
    }

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        Inventory
    }
}
