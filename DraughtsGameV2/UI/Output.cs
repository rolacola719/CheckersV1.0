using DraughtsGameV2;
using System;

internal static class Output
{
    public static void DisplayBoard()
    {
        Console.WriteLine(@"
+-------+-------+-------+-------+-------+-------+-------+-------+
0       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
1       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
2       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
3       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
4       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
5       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
6       |       |       |       |       |       |       |       |
+-------+-------+-------+-------+-------+-------+-------+-------+
7       |       |       |       |       |       |       |       |
+--0----+--1----+---2---+---3---+---4---+---5---+---6---+---7---+");
    }

    public static void DisplayScore(Player player1, Player player2)
    {
        Console.SetCursorPosition(70, 5);
        Console.Write($"Player 1 score is: {player1.Score}");
        Console.SetCursorPosition(70, 6);
        Console.Write($"Player 2 score is: {player2.Score}");
    }

    public static void DisplayGamePieces(Board board)
    {
        foreach (Tile tile in board.tile)
        {
            Console.SetCursorPosition(tile.ConsolePosX, tile.ConsolePosY);
            Console.Write(" ");

            foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
            {
                if ((gamepiece.posY == tile.BoardPosY) && (gamepiece.posX == tile.BoardPosX) && (gamepiece.isActive))
                {
                        Console.SetCursorPosition(tile.ConsolePosX, tile.ConsolePosY);
                        if (gamepiece.ownedBy == 1) Console.Write("O");
                        else if (gamepiece.ownedBy == 2) Console.Write("X");
                }

            }
        }
    }
}