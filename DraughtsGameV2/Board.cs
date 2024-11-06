using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameV2
{
    public class Board
    {
       public Tile[,] tile = new Tile[8, 8];

        public Board()
        { 
            InitializeTiles();
        }
        
        public void InitializeTiles()
        {
            int row = tile.GetLength(0);
            int column = tile.GetLength(1);
            int yScreenPos = 2;
            int xScreenPos = 4;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    tile[i, j] = new Tile()
                    { BoardPosX = j, BoardPosY = i, ConsolePosX = xScreenPos, ConsolePosY = yScreenPos };
                    xScreenPos += 8;
                }
                xScreenPos = 4;
                yScreenPos += 2;
            }
        }
    }
}
