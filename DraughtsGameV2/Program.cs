using DraughtsGameV2.UI;

namespace DraughtsGameV2
{
    public class Program
    {
        static void Main(string[] args)
        {

            UIManager UIManager = new UIManager();

            Player player1 = new Player(1, UIManager);
            Player player2 = new Player(2, UIManager);

            Board board = new Board();

            UIManager.DisplayRules();
            UIManager.DisplayBoard();
            UIManager.DisplayScore(player1, player2);
            UIManager.DisplayGamePieces(board);
            UIManager.DisplayTitle();
            UIManager.DisplayScoreBorder();


            while (true)
            {

                if (Player.CanCaptureOpponent(1, out int notUsed))
                {
                    while (Player.CanCaptureOpponent(1, out notUsed))
                    {
                        player1.MovePlayer(board, 1);
                        UIManager.DisplayGamePieces(board);
                        UIManager.DisplayScoreBorder();
                        UIManager.DisplayScore(player1, player2);
                        if (player1.Score == 12) break;
                    }
                }
                else
                {
                    player1.MovePlayer(board, 1);
                    UIManager.DisplayGamePieces(board);
                    UIManager.DisplayScoreBorder();
                    UIManager.DisplayScore(player1, player2);
                    if (player1.Score == 12) break;
                }



                if (Player.CanCaptureOpponent(2, out notUsed))
                {
                    while (Player.CanCaptureOpponent(2, out notUsed))
                    {
                        player2.MovePlayer(board, 2);
                        UIManager.DisplayGamePieces(board);
                        UIManager.DisplayScore(player1, player2);
                        if (player2.Score == 12) break;
                    }
                }
                else
                {
                    player2.MovePlayer(board, 2);
                    UIManager.DisplayGamePieces(board);
                    UIManager.DisplayScore(player1, player2);
                    if (player2.Score == 12) break;
                }
            }

        
        }
    }
}