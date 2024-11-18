using DraughtsGameV2;
using DraughtsGameV2.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameV2
{
    public class Player
    {
        public int Score = 0;
        public int PlayerNumber;
        public GamePiece[] Piece = new GamePiece[12];
        public UIManager UIManager;
        //
        public Player(int playerNumber, UIManager uIManager)
        {
            UIManager = uIManager;

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
            
            
                while (!isValidMove)
                {
                    bool mustExecute = CanCaptureOpponent(playerNumber, out int playerThatMustMove);
                    Debug.WriteLine($"Can Capture opponent has returned as {CanCaptureOpponent(playerNumber, out playerThatMustMove)} with the player being {playerThatMustMove}");


                    do
                    {
                        if (mustExecute)
                        {
                            do
                            {
                                UIManager.DisplayDialog1(playerNumber);
                                UIManager.GetCoordinates(out xCord, out yCord);
                                if (ThisPieceCanCapture(xCord, yCord, playerNumber))
                                    break;
                                UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                Debug.WriteLine($"xCord is: {xCord}. must moves xCord is {this.Piece[playerThatMustMove].posX}. yCord is: {yCord}. must moves yCord is {Piece[playerThatMustMove].posY}.  ");
                            }
                            while (ThisPieceCanCapture(xCord, yCord, playerNumber) == false);
                        }
                        else
                        {
                            UIManager.DisplayDialog1(playerNumber);
                            UIManager.GetCoordinates(out xCord, out yCord);
                        }


                    } while (!(IsOccupied(xCord, yCord) && ReturnPlayerNumber(xCord, yCord) == playerNumber));

                    CheckIfAdjacentToOpponent(playerNumber, xCord, yCord, out bool enemyTL, out bool enemyTR, out bool enemyBL, out bool enemyBR);

                    UIManager.DisplayDialog2(playerNumber);
                    int direction = UIManager.MoveToPos();

                    foreach (GamePiece piece in GamePiece.AllGamePieces)
                    {
                        // NON KING MOVES
                                //Player 1
                        if ((piece.posX == xCord) && (piece.posY == yCord) && (piece.isKing == false) & (mustExecute == true) && playerNumber == 1)
                        {
                            switch (direction)
                            {
                                case 7:
                                    if (enemyTL)
                                    {
                                        if (!IsOccupied(xCord - 2, yCord - 2) && IsOccupied(xCord - 1, yCord - 1))
                                        {
                                            ExecuteMove(xCord, yCord, -1, -1, out xDest, out yDest);
                                            DeactivateGamePiece(xCord - 1, yCord - 1);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }

                                    break;

                                case 9:
                                    if (enemyTR)
                                    {
                                        if (!IsOccupied(xCord + 2, yCord - 2) && IsOccupied(xCord + 1, yCord - 1))
                                        {
                                            ExecuteMove(xCord, yCord, 1, -1, out xDest, out yDest);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }
                                    break;

                                default:
                                    xDest = xCord;
                                    yDest = yCord;
                                    break;
                            }
                        }
                        else if ((piece.posX == xCord) && (piece.posY == yCord) && (piece.isKing == false) & (mustExecute == false && playerNumber == 1))
                        {
                            switch (direction)
                            {
                            case 7:
                                if (!IsOccupied(xCord - 1, yCord - 1))
                                {
                                    xDest = xCord - 1;
                                    yDest = yCord - 1;
                                }
                                break;

                            case 9:
                                if (!IsOccupied(xCord + 1, yCord - 1))
                                {
                                    xDest = xCord + 1;
                                    yDest = yCord - 1;
                                }
                                break;
                        }
                    }
                                //Player 2
                        if ((piece.posX == xCord) && (piece.posY == yCord) && (piece.isKing == false) & (mustExecute == true) && playerNumber == 2)
                        {
                            switch (direction)
                            {
                                case 1:
                                    if (enemyBL)
                                    {
                                        if (!IsOccupied(xCord - 2, yCord + 2) && IsOccupied(xCord - 1, yCord + 1))
                                        {
                                            ExecuteMove(xCord, yCord, -1, +1, out xDest, out yDest);
                                            DeactivateGamePiece(xCord - 1, yCord + 1);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }

                                    break;

                                case 3:
                                    if (enemyBR)
                                    {
                                        if (!IsOccupied(xCord + 2, yCord + 2) && IsOccupied(xCord + 1, yCord + 1))
                                        {
                                            ExecuteMove(xCord, yCord, 1, 1, out xDest, out yDest);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }
                                    break;

                                default:
                                    xDest = xCord;
                                    yDest = yCord;
                                    break;
                            }
                        }
                        else if ((piece.posX == xCord) && (piece.posY == yCord) && (piece.isKing == false) & (mustExecute == false && playerNumber == 2))
                            {
                                switch (direction)
                                {
                                    case 1:
                                        if (!IsOccupied(xCord - 1, yCord + 1))
                                        {
                                            xDest = xCord - 1;
                                            yDest = yCord + 1;

                                        }
                                        break;
                                    case 3:
                                        if (!IsOccupied(xCord + 1, yCord + 1))
                                        {
                                            xDest = xCord + 1;
                                            yDest = yCord + 1;
                                        }
                                        break;
                                }
                            }

                        // KING MOVES
                        if ((piece.posX == xCord) && (piece.posY == yCord) && (piece.isKing == true) & (mustExecute == true))
                        {
                            switch (direction)
                            {
                                case 1:
                                    if (enemyBL)
                                    {
                                        if (!IsOccupied(xCord - 2, yCord + 2) && IsOccupied(xCord - 1, yCord + 1))
                                        {
                                            ExecuteMove(xCord, yCord, -1, 1, out xDest, out yDest);
                                        }
                                    }
                                    else
                                        UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    break;

                                case 3:
                                    if (enemyBR)
                                    {
                                        if (!IsOccupied(xCord + 2, yCord + 2) && IsOccupied(xCord + 1, yCord + 1))
                                        {
                                            ExecuteMove(xCord, yCord, 1, 1, out xDest, out yDest);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }

                                    break;

                                case 7:
                                    if (enemyTL)
                                    {
                                        if (!IsOccupied(xCord - 2, yCord - 2) && IsOccupied(xCord - 1, yCord - 1))
                                        {
                                            ExecuteMove(xCord, yCord, -1, -1, out xDest, out yDest);
                                            DeactivateGamePiece(xCord - 1, yCord - 1);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }

                                    break;

                                case 9:
                                    if (enemyTR)
                                    {
                                        if (!IsOccupied(xCord + 2, yCord - 2) && IsOccupied(xCord + 1, yCord - 1))
                                        {
                                            ExecuteMove(xCord, yCord, 1, -1, out xDest, out yDest);
                                        }
                                        else
                                            UIManager.YouMustExecuteTheOpponentsPieceDialog();
                                    }
                                    break;

                                default:
                                    xDest = xCord;
                                    yDest = yCord;
                                    break;
                            }
                        }
                        else if ((piece.posX == xCord) && (piece.posY == yCord) && (piece.isKing == true) & (mustExecute == false))
                        {
                            switch (direction)
                            {
                                case 1:
                                    if (!IsOccupied(xCord - 1, yCord + 1))
                                    {
                                        xDest = xCord - 1;
                                        yDest = yCord + 1;

                                    }
                                    break;
                                case 3:
                                    if (!IsOccupied(xCord + 1, yCord + 1))
                                    {
                                        xDest = xCord + 1;
                                        yDest = yCord + 1;
                                    }
                                    break;

                                case 7:
                                    if (!IsOccupied(xCord - 1, yCord - 1))
                                    {
                                        xDest = xCord - 1;
                                        yDest = yCord - 1;
                                    }
                                    break;

                                case 9:
                                    if (!IsOccupied(xCord + 1, yCord - 1))
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
                        }
                        //Checking to see if the move was valid (if destination coordinates are still set to default (-1, -1) then move not valid
                        if (xDest != -1 && yDest != -1)
                        {
                            piece.posX = xDest;
                            piece.posY = yDest;
                            isValidMove = true;
                            piece.CheckKing();
                            break;
                        }
                    }
                    

                    if (!isValidMove)
                    {
                        UIManager.PickValidCoordinateDialog();
                    }
                }
           
        }    
        
        //
        private static int ReturnPlayerNumber(int xCord, int yCord)
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

        private static void DeactivateGamePiece(int xCord, int yCord)
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

        private static bool IsOccupied(int xCord, int yCord)
        {
            foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
            {
                if ((gamepiece.posY == yCord) && (gamepiece.posX == xCord) && (gamepiece.isActive))
                {
                    return true;

                }
            }
            return false;
        }

        private void ExecuteMove(int xCord, int yCord, int xMod, int yMod, out int xDest, out int yDest)
        {
            int xModifier = 2;
            int yModifier = 2;
            xModifier *= xMod;
            yModifier *= yMod;

            xDest = xCord + xModifier;
            yDest = yCord + yModifier;
            Debug.WriteLine($"piece Cords is {xCord} {yCord} and its destination is {xDest} {yDest}");

            DeactivateGamePiece(xCord + (xModifier / 2), yCord + (yModifier / 2));
            Score += 1;
        }

        private static void CheckIfAdjacentToOpponent(int playerNumber, int xCord, int yCord, out bool enemyTL, out bool enemyTR, out bool enemyBL, out bool enemyBR)
        {
            enemyBL = false;
            enemyBR = false;
            enemyTL = false;
            enemyTR = false;
            {
                foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                {
                    if (gamepiece.ownedBy != playerNumber)
                    {
                        if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord - 1, yCord + 1)) enemyBL = true;

                        if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord + 1, yCord + 1)) enemyBR = true;

                        if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord - 1, yCord - 1)) enemyTL = true;

                        if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord + 1, yCord - 1)) enemyTR = true;
                    }
                }
                Debug.WriteLine($"BL = {enemyBL} ; BR = {enemyBR} ; TL = {enemyTL} ; TR = {enemyTR} ");
            }

        }

        public static bool CanCaptureOpponent(int playerNumber, out int playerArrayNumber)
        {
            playerArrayNumber = 0;
            foreach (GamePiece playerGamePiece in GamePiece.AllGamePieces)
            {
                if (playerGamePiece.ownedBy == playerNumber && playerGamePiece.isActive)
                {
                    playerArrayNumber = playerGamePiece.arrayNumber;
                    int xCord = playerGamePiece.posX;
                    int yCord = playerGamePiece.posY;

                    //IF NOT KING
                    //Player 1
                    if (playerGamePiece.isKing == false && playerGamePiece.ownedBy == 1)
                    {
                        foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                        {
                            if (gamepiece.ownedBy != playerNumber && gamepiece.isActive)
                            {

                                if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord - 1, yCord - 1) && (xCord >= 2) && (yCord >= 2) && (!IsOccupied(xCord - 2, yCord - 2)))
                                    return true;
                                if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord + 1, yCord - 1) && (xCord <= 5) && (yCord >= 2) && (!IsOccupied(xCord + 2, yCord - 2)))
                                    return true;
                            }
                        }
                    }
                    //Player 2
                    else if (playerGamePiece.isKing == false && playerGamePiece.ownedBy == 2)
                    {
                        foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                        {
                            if (gamepiece.ownedBy != playerNumber && gamepiece.isActive)
                            {

                                if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord - 1, yCord + 1) && (xCord >= 2) && (yCord <= 5) && (!IsOccupied(xCord - 2, yCord + 2)))
                                    return true;
                                if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord + 1, yCord + 1) && (xCord <= 5) && (yCord <= 5) && (!IsOccupied(xCord + 2, yCord + 2)))
                                    return true;
                            }
                        }
                    }

                    //IF KING
                    else if (playerGamePiece.isKing)
                    {
                        foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                        {
                            if (gamepiece.ownedBy != playerNumber && gamepiece.isActive)
                            {
                                if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord - 1, yCord + 1) && (xCord >= 2) && (yCord <= 5) && (!IsOccupied(xCord - 2, yCord + 2)))
                                    return true;
                                if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord + 1, yCord + 1) && (xCord <= 5) && (yCord <= 5) && (!IsOccupied(xCord + 2, yCord + 2)))
                                    return true;
                                if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord - 1, yCord - 1) && (xCord >= 2) && (yCord >= 2) && (!IsOccupied(xCord - 2, yCord - 2)))
                                    return true;
                                if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord + 1, yCord - 1) && (xCord <= 5) && (yCord >= 2) && (!IsOccupied(xCord + 2, yCord - 2)))
                                    return true;
                            }
                        }
                    }
                }
                else continue;
            }
            return false;
        }

        public bool ThisPieceCanCapture(int xCord, int yCord, int playerNumber)
        {
            foreach (GamePiece playerGamePiece in GamePiece.AllGamePieces)
            {
                // IF NON KINGS
                    //player 1
                if ((playerGamePiece.posX == xCord) && (playerGamePiece.posY == yCord) && (playerGamePiece.isKing == false) && (playerGamePiece.ownedBy == 1))
                {
                    foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                    {
                        if (gamepiece.ownedBy != playerNumber)
                        {

                            if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord - 1, yCord - 1) && (xCord >= 2) && (yCord >= 2) && (!IsOccupied(xCord - 2, yCord - 2)))
                                return true;
                            if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord + 1, yCord - 1) && (xCord <= 5) && (yCord >= 2) && (!IsOccupied(xCord + 2, yCord - 2)))
                                return true;
                        }
                    }
                }
                    //player 2
                else if ((playerGamePiece.posX == xCord) && (playerGamePiece.posY == yCord) && (playerGamePiece.isKing == false) && (playerGamePiece.ownedBy == 2))
                {
                    foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                    {
                        if (gamepiece.ownedBy != playerNumber)
                        {
                            if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord - 1, yCord + 1) && (xCord >= 2) && (yCord <= 5) && (!IsOccupied(xCord - 2, yCord + 2)))
                                return true;
                            if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord + 1, yCord + 1) && (xCord <= 5) && (yCord <= 5) && (!IsOccupied(xCord + 2, yCord + 2)))
                                return true;
                        }
                    }
                    }
                // IF KINGS
                if ((playerGamePiece.posX == xCord) && (playerGamePiece.posY == yCord) && (playerGamePiece.isKing == true))
                {
                    foreach (GamePiece gamepiece in GamePiece.AllGamePieces)
                    {
                        if (gamepiece.ownedBy != playerNumber)
                        {

                            if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord - 1, yCord - 1) && (xCord >= 2) && (yCord >= 2) && (!IsOccupied(xCord - 2, yCord - 2)))
                                return true;
                            if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord - 1) && IsOccupied(xCord + 1, yCord - 1) && (xCord <= 5) && (yCord >= 2) && (!IsOccupied(xCord + 2, yCord - 2)))
                                return true;
                            if ((gamepiece.posX == xCord - 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord - 1, yCord + 1) && (xCord >= 2) && (yCord <= 5) && (!IsOccupied(xCord - 2, yCord + 2)))
                                return true;
                            if ((gamepiece.posX == xCord + 1) && (gamepiece.posY == yCord + 1) && IsOccupied(xCord + 1, yCord + 1) && (xCord <= 5) && (yCord <= 5) && (!IsOccupied(xCord + 2, yCord + 2)))
                                return true;
                        }
                    }
                }

                else continue;
            }
            return false;
        }
    }
}



