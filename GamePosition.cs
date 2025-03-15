namespace SpeedTacToe;

public record GamePosition(int Position)
{
	public IPlayer? Player { get; set; }

	public override string ToString() => Player?.Icon ?? " ";
}