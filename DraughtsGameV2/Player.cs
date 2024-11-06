using DraughtsGameV2.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameV2
{
    class Player
    {
        public int Score = 0;
        public int PlayerNumber;
        public GamePiece[] Piece = new GamePiece[12];

        public Player(int playerNumber) 
        {
            if (playerNumber == 1)
            {
                int posX = 0;
                int posY = 7;
                for (int i = 0; i < Piece.Length; i++)
                {
                    Piece[i] = new GamePiece();
                    Piece[i].SetLocation(posX, posY);
                    Piece[i].ownedBy = 1;
                    Piece[i].arrayNumber = i;


                    posX += 2;

                    if (posX >= 8)
                    {
                        posY -= 1;

                        if (posY % 2 != 0)
                        {
                            posX = 0;
                        }
                        else if (posY % 2 == 0)
                        {
                            posX = 1;
                        }
                        continue;
                    }
                }
            }
            else if (playerNumber == 2) 
            {
                int posX = 1;
                int posY = 0;
                for (int i = 0; i < Piece.Length; i++)
                {
                    Piece[i] = new GamePiece();
                    Piece[i].SetLocation(posX, posY);
                    Piece[i].ownedBy = 2;
                    Piece[i].arrayNumber = i;
                    posX += 2;

                    if (posX >= 8)
                    {
                        posY += 1;

                        if (posY % 2 != 0)
                        {
                            posX = 0;
                        }
                        else if (posY % 2 == 0)
                        {
                            posX = 1;
                        }
                        continue;
                    }
                }
            }
        }

        public void MovePlayer(Board board, int playerNumber)
        {
            int xCord;
            int yCord;
            int xDest = -1;
            int yDest = -1;
            bool isValidMove = false;
            int direction = 0;

            while (!isValidMove)
            {
                do
                {
                    Console.SetCursorPosition(1, 20);
                    Console.Write($"PLAYER {playerNumber}: What piece would you like to move:         ");
                    Input.GetCoordinates(out xCord, out yCord);

                } while (!(isOccupied(xCord, yCord) && ReturnPlayerNumber(xCord, yCord) == playerNumber));


                Console.SetCursorPosition(1, 20);
                Console.Write($"PLAYER {playerNumber}: Where would you like to move to:          ");
                direction = Input.MoveToPos();


                foreach (GamePiece piece in GamePiece.AllGamePieces)
                {
                    if ((piece.posX == xCord) && (piece.posY == yCord))
                    {
                        switch (direction)
                        {
                            case 1:
                                if ((isOccupied(xCord - 1, yCord + 1)) && (ReturnPlayerNumber(xCord - 1, yCord + 1) != PlayerNumber))
                                {
                                    if (!isOccupied(xCord - 2, yCord + 2))
                                    {
                                        ExecuteMove(xCord, yCord, -1, 1, out xDest, out yDest);
                                    }
                                }
                                else if (!isOccupied(xCord - 1, yCord + 1))
                                {
                                    xDest = xCord - 1;
                                    yDest = yCord + 1;
                                }
                                break;
                            case 3:
                                if ((isOccupied(xCord + 1, yCord + 1)) && (ReturnPlayerNumber(xCord + 1, yCord + 1) != PlayerNumber))
                                {
                                    if (!isOccupied(xCord + 2, yCord + 2))
                                    {
                                        ExecuteMove(xCord, yCord, 1, 1, out xDest, out yDest);
                                    }
                                }
                                else if (!isOccupied(xCord + 1, yCord + 1))
                                {
                                    xDest = xCord + 1;
                                    yDest = yCord + 1;
                                }
                                break;
                            case 7:
                                if ((isOccupied(xCord - 1, yCord - 1)) && (ReturnPlayerNumber(xCord - 1, yCord - 1) != PlayerNumber))
                                {
                                    if (!isOccupied(xCord - 2, yCord - 2))
                                    {
                                        ExecuteMove(xCord, yCord, -1, -1, out xDest, out yDest);

                                    }
                                }
                                else if (!isOccupied(xCord - 1, yCord - 1))
                                {
                                    xDest = xCord - 1;
                                    yDest = yCord - 1;
                                }
                                break;
                            case 9:
                                if ((isOccupied(xCord + 1, yCord - 1)) && (ReturnPlayerNumber(xCord + 1, yCord - 1) != PlayerNumber))
                                {
                                    if (!isOccupied(xCord + 2, yCord - 2))
                                    {
                                        ExecuteMove(xCord, yCord, 1, -1, out xDest, out yDest);

                                    }
                                }
                                else if (!isOccupied(xCord + 1, yCord - 1))
                                {
                                    xDest = xCord + 1;
                                    yDest = yCord - 1;
                                }
                                break;
                            default:
                                xDest = xCord;
                                yDest = yCord;
                                break;
                        }

                        //Checking to see if the move was valid (if destination coordinates are still set to default (-1, -1) then move not valid
                        if (xDest != -1 && yDest != -1)
                        {
                            piece.posX = xDest;
                            piece.posY = yDest;
                            isValidMove = true;
                            break;
                        }
                    }
                }
                if (!isValidMove)
                {
                    Console.SetCursorPosition(1, 22);
                    Console.WriteLine("Please pick a valid coordinate");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(1, 22);
                    Console.WriteLine("                                                 ");
                    Console.SetCursorPosition(1, 21);
                }
            }
        }

        public int ReturnPlayerNumber(int xCord, int yCord)
        {
            foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
            {
                if ((gamepiece.posY == yCord) && (gamepiece.posX == xCord))
                {
                    return gamepiece.ownedBy;

                }
            }
            return -1;
        }

        public int ReturnGamePieceNumber(int xCord, int yCord)
        {
            {
                foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                {
                    if ((gamepiece.posY == yCord) && (gamepiece.posX == xCord))
                    {
                        return gamepiece.arrayNumber;

                    }
                }
                return -1;
            }

        }

        public void DeactivateGamePiece(int xCord, int yCord)
        {
            {
                foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                {
                    if ((gamepiece.posY == yCord) && (gamepiece.posX == xCord))
                    {
                         gamepiece.isActive = false;

                    }
                }
            }

        }

        public bool isOccupied(int xCord, int yCord)
        {
            foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
            {
                if ((gamepiece.posY == yCord) && (gamepiece.posX == xCord))
                {
                    return true;

                }
            }
            return false;
        }

        public void ExecuteMove(int xCord, int yCord, int xMod, int yMod, out int xDest, out int yDest)
        {
            int xModifier = 2;
            int yModifier = 2;
            xModifier *= xMod;
            yModifier *= yMod;

            xDest = xCord + xModifier;
            yDest = yCord + yModifier;
            Debug.WriteLine($"piece Cords is {xCord} {yCord} and its destination is {xDest} {yDest}");
            DeactivateGamePiece(xCord + xModifier / 2, yCord + yModifier / 2);

            Score += 1;
        }

    }
}

