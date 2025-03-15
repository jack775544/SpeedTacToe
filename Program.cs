using SpeedTacToe;

Console.WriteLine("Play PvE (0) or PvP (1)");

var mode = 0;
var modeSelected = false;

do
{
	var input = Console.ReadLine();
	if (int.TryParse(input, out mode))
	{
		modeSelected = true;
	}
	else
	{
		Console.WriteLine("Please enter 0 for PvE or 1 for PvP");
	}
} while (!modeSelected);

if (mode == 0)
{
	new Game(new HumanPlayer("A", "X"), new AiPlayer("B", "O")).Run();
}
else
{
	new Game(new HumanPlayer("A", "X"), new HumanPlayer("B", "O")).Run();
}
