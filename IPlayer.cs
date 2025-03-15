namespace SpeedTacToe;

public interface IPlayer
{
	public string Name { get; }
	public string Icon { get; }
	public int TakeTurn(Game game);
}