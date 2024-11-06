using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameV2
{
    internal class GamePiece
    {
        public int posX;
        public int posY;
        public int ownedBy;
        bool isKing;
        public bool isActive;
        public int arrayNumber;

        public GamePiece()
        {
            isActive = true;
            isKing = false;
            AllGamePieces.Add(this);
        }

        public void Deactivate()
        {
            isActive = false;
        }

        public void SetLocation(int x, int y)
        {
            posX = x; 
            posY = y;
        }

        public static List <GamePiece> AllGamePieces = new List <GamePiece>();
        public static List<GamePiece> GetAllInstances()
        {
            return AllGamePieces;
        }
    }

  
}
