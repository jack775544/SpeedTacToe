namespace SpeedTacToe;

public class Game
{
	private readonly IPlayer[] _players;

	public readonly GamePosition[] Board =
	[
		new GamePosition(0), new GamePosition(1), new GamePosition(2),
		new GamePosition(3), new GamePosition(4), new GamePosition(5),
		new GamePosition(6), new GamePosition(7), new GamePosition(8),
	];

	public GamePosition[][] Horizontals =>
	[
		[Board[0], Board[1], Board[2]],
		[Board[3], Board[4], Board[5]],
		[Board[6], Board[7], Board[8]],
	];

	public GamePosition[][] Verticals =>
	[
		[Board[0], Board[3], Board[6]],
		[Board[1], Board[4], Board[7]],
		[Board[2], Board[5], Board[8]],
	];

	public GamePosition[][] Diagonals =>
	[
		[Board[0], Board[4], Board[8]],
		[Board[2], Board[4], Board[6]],
	];
	
	public GamePosition[][] AllPositions => [..Horizontals, ..Verticals, ..Diagonals];

	public IGameState GameState
	{
		get
		{
			// Check for winner
			foreach (var line in AllPositions)
			{
				foreach (var group in line.GroupBy(x => x.Player))
				{
					if (group.Count() == 3 && group.Key != null)
					{
						return new WinnerState(group.Key);
					}
				}
			}

			// Check for tie
			if (Board.All(x => x.Player != null))
			{
				return new TieState();
			}

			return new InProgressState();
		}
	}

	public Game(IPlayer player1, IPlayer player2)
	{
		_players = [player1, player2];
	}

	public void Run()
	{
		var turn = 0;

		while (true)
		{
			var currentPlayer = _players[turn];
			Console.WriteLine(ToString());

			switch (GameState)
			{
				case InProgressState:
					var isActionValid = false;

					do
					{
						Console.WriteLine($"{currentPlayer.Name}, please enter your position");
						var action = currentPlayer.TakeTurn(this);
						isActionValid = Board[action].Player == null;

						if (isActionValid)
						{
							Board[action].Player = currentPlayer;
						}
						else
						{
							Console.WriteLine("Invalid turn, please enter again");
						}
					} while(!isActionValid);

					turn = (turn + 1) % 2;
					break;

				case TieState:
					Console.WriteLine("The game ends in a tie");
					return;

				case WinnerState winnerState:
					Console.WriteLine($"The winner is {winnerState.Player.Name}");
					return;

				default:
					throw new ArgumentOutOfRangeException(nameof(GameState));
			}
		}
	}

	public override string ToString()
	{
		return $"""
		       | {Board[0]} | {Board[1]} | {Board[2]} |
		       | {Board[3]} | {Board[4]} | {Board[5]} |
		       | {Board[6]} | {Board[7]} | {Board[8]} |
		       """;
	}
}