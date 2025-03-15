namespace SpeedTacToe;

public class AiPlayer : IPlayer
{
	public string Name { get; }
	public string Icon { get; }

	public AiPlayer(string name, string icon)
	{
		Name = name;
		Icon = icon;
	}

	public int TakeTurn(Game game)
	{
		var orderedPositions = game.AllPositions
			.OrderByDescending(x => x.Count(y => y.Player != this && y.Player != null));

		foreach (var line in orderedPositions)
		{
			if (line.Any(x => x.Player != this && x.Player != null))
			{
				var validPosition = line.FirstOrDefault(x => x.Player == null);
				if (validPosition != null)
				{
					return validPosition.Position;
				}
			}
		}

		return 0;
	}
}