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
