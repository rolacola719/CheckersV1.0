using DraughtsGameV2;
using System;

internal class Output
{
    //
    public void DisplayBoard()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(@"
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
    //
    public void DisplayScore(Player player1, Player player2)
    {
        Console.SetCursorPosition(33, 23);
        Console.Write($"Player 1 score is: {player1.Score}");
        Console.SetCursorPosition(33, 24);
        Console.Write($"Player 2 score is: {player2.Score}");
    }
    //
    public void DisplayScoreBorder()
    {
        Console.SetCursorPosition(31, 21);
        Console.Write("------------------------");
        Console.SetCursorPosition(31, 26);
        Console.Write("------------------------");
        Console.SetCursorPosition(31, 22);
        Console.Write("|");
        Console.SetCursorPosition(31, 23);
        Console.Write("|");
        Console.SetCursorPosition(31, 24);
        Console.Write("|");
        Console.SetCursorPosition(31, 25);
        Console.Write("|");
        Console.SetCursorPosition(54, 22);
        Console.Write("|");
        Console.SetCursorPosition(54, 23);
        Console.Write("|");
        Console.SetCursorPosition(54, 24);
        Console.Write("|");
        Console.SetCursorPosition(54, 25);
        Console.Write("|");
    }

   // 
    public void DisplayGamePieces(Board board)
    {
        foreach (Tile tile in board.tile)
        {
            Console.SetCursorPosition(tile.ConsolePosX-1, tile.ConsolePosY);
            Console.Write("   ");

            foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
            {
                if ((gamepiece.posY == tile.BoardPosY) && (gamepiece.posX == tile.BoardPosX) && (gamepiece.isActive))
                {
                        Console.SetCursorPosition(tile.ConsolePosX, tile.ConsolePosY);
                        if (gamepiece.ownedBy == 1 && !gamepiece.isKing) Console.Write(" O ");
                        else if (gamepiece.ownedBy == 1 && gamepiece.isKing) 
                            { Console.SetCursorPosition(tile.ConsolePosX - 1, tile.ConsolePosY); Console.Write("(O)"); }
                        else if (gamepiece.ownedBy == 2 && !gamepiece.isKing) Console.Write(" X ");
                        else if (gamepiece.ownedBy == 2 && gamepiece.isKing)
                            { Console.SetCursorPosition(tile.ConsolePosX - 1, tile.ConsolePosY); Console.Write("(X)"); }
                }

            }
        }
    }

    
    public void DisplayDialog1(int playerNumber)
    {
        Console.SetCursorPosition(1, 19);
        Console.Write($"PLAYER {playerNumber}: What piece would you like to move:         ");
    }
    
    public void DisplayDialog2(int playerNumber)
    {
        Console.SetCursorPosition(1, 19);
        Console.Write($"PLAYER {playerNumber}: Where would you like to move to:          ");
    }

    public void PickValidCoordinateDialog()
    {
        Console.SetCursorPosition(1, 21);
        Console.WriteLine("Pick a valid coordinate");
        Thread.Sleep(1000);
        Console.SetCursorPosition(1, 21);
        Console.WriteLine("                              -");
        Console.SetCursorPosition(1, 20);
    }

    public void YouMustExecuteTheOpponentsPieceDialog()
    {
        Console.SetCursorPosition(1, 21);
        Console.WriteLine("You must execute the opponent");
        Thread.Sleep(1000);
        Console.SetCursorPosition(1, 21);
        Console.WriteLine("                                                 ");
        Console.SetCursorPosition(1, 20);
    }

    public void DisplayTitle()
    {
        Console.SetCursorPosition(66, 0);
        Console.WriteLine(@"  _____ _    _ ______ _____ _  ________ _____   _____");
        Console.SetCursorPosition(66, 1);
        Console.WriteLine(@" / ____| |  | |  ____/ ____| |/ /  ____|  __ \ / ____|");
        Console.SetCursorPosition(66, 2);
        Console.WriteLine(@"| |    | |__| | |__ | |    | ' /| |__  | |__) | (___  ");
        Console.SetCursorPosition(66, 3);
        Console.WriteLine(@"| |    |  __  |  __|| |    |  < |  __| |  _  / \___ \ ");
        Console.SetCursorPosition(66, 4);
        Console.WriteLine(@"| |____| |  | | |___| |____| . \| |____| | \ \ ____) |");
        Console.SetCursorPosition(66, 5);
        Console.WriteLine(@" \_____|_|  |_|______\_____|_|\_\______|_|  \_\_____/");
        Console.SetCursorPosition(68, 7);
        Console.WriteLine(@" by EEJIT Software");
    }

    public static void DisplayRules()
    {


        Console.SetCursorPosition(68, 9);
        Console.WriteLine("Enter 'R' to view/hide the rules:");
        Console.SetCursorPosition(68, 10);
        Console.WriteLine("Capture all opponent pieces.");
        Console.SetCursorPosition(68, 11);
        Console.WriteLine(" Regular pieces: Move one space diagonal forward.");
        Console.SetCursorPosition(68, 12);
        Console.WriteLine(" Kings: Move one space diagonal forward and backward.");
        Console.SetCursorPosition(68, 13);
        Console.WriteLine("Select piece by X, Y coordinates.");
        Console.SetCursorPosition(68, 14);
        Console.WriteLine(" 1: Back-left (kings only)");
        Console.SetCursorPosition(68, 15);
        Console.WriteLine(" 3: Back-right (kings only)");
        Console.SetCursorPosition(68, 16);
        Console.WriteLine(" 7: Up-left");
        Console.SetCursorPosition(68, 17);
        Console.WriteLine(" 9: Up-right");
        Console.SetCursorPosition(68, 18);
        Console.WriteLine("Captures");
        Console.SetCursorPosition(68, 19);
        Console.WriteLine(" Jump over opponent pieces.");
        Console.SetCursorPosition(68, 20);
        Console.WriteLine(" Regular pieces capture forward."); 
        Console.SetCursorPosition(68, 21);
        Console.WriteLine(" Kings capture forward and backward.");
        Console.SetCursorPosition(68, 22);
        Console.WriteLine(" Must capture if possible.");
        Console.SetCursorPosition(68, 23);
        Console.WriteLine(" Must Continue capturing if possible.");
        Console.SetCursorPosition(68, 24);
        Console.WriteLine("Capture all opponent pieces to win");
                   
        Console.SetCursorPosition(1, 21);
    }

    public static void CollapseRules()
    {
        int yPos = 10;
        Console.SetCursorPosition(68, yPos);

        for (int i = 0; i < 19; i++)
        {
            Console.SetCursorPosition(66, yPos);
            Console.WriteLine("                                                      ");
            yPos++;
        }
        Console.SetCursorPosition(1, 21);
    }
}
