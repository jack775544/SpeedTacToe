namespace SpeedTacToe;

public class HumanPlayer : IPlayer
{
	public string Name { get; }
	public string Icon { get; }

	public HumanPlayer(string name, string icon)
	{
		Name = name;
		Icon = icon;
	}

	public int TakeTurn(Game game)
	{
		do
		{
			var input = Console.ReadLine();

			if (int.TryParse(input, out var position) && position < 9)
			{
				return position;
			}

			Console.WriteLine("Please enter a number between 0 and 8");
		} while (true);
	}
}