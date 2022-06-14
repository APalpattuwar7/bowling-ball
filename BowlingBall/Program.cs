namespace BowlingBall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Roll(5, 3);
            game.Roll(4, 6);
            game.Roll(5, 2);
            var score = game.GetScore();
            System.Console.WriteLine($"Score - {score}");
        }
    }
}
