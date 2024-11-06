namespace DraughtsGameV2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(2);
            Player player2 = new Player(1);

            Board board = new Board();

            Output.DisplayBoard();
            Output.DisplayScore(player1, player2);
            Output.DisplayGamePieces(board);


            while (true)
            {
                Output.DisplayScore(player1, player2);             
                player1.MovePlayer(board, 1);
                Output.DisplayGamePieces(board);
                Output.DisplayScore(player1, player2);
                player2.MovePlayer(board, 2);
                Output.DisplayGamePieces(board);
                Output.DisplayScore(player1, player2);
            }

        }
    }
}