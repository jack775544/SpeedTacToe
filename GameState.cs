namespace SpeedTacToe;

public interface IGameState;

public record WinnerState(IPlayer Player) : IGameState;
public record TieState : IGameState;
public record InProgressState : IGameState;