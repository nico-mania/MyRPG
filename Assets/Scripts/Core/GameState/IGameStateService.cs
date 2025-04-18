// Definiert den Zugriff auf den aktuellen GameState sowie die M�glichkeit, diesen zu �ndern.
// Das zugeh�rige Enum beschreibt die m�glichen globalen Zust�nde des Spiels.

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
