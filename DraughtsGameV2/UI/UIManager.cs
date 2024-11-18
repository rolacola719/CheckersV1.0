using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameV2.UI
{
    public class UIManager
    {
        private readonly Input Input = new();
        private readonly Output Output = new();

        //***************OUTPUTS*******************
        public void DisplayBoard()
        {
        Output.DisplayBoard();
        }

        public void DisplayScore(Player player1, Player player2)
        {
            Output.DisplayScore(player1, player2);
        }
        public void DisplayGamePieces(Board board)
        {
            Output.DisplayGamePieces(board);
        }

        public void DisplayDialog1(int playerNumber)
        {
           Output.DisplayDialog1(playerNumber);
            
        }

        public void DisplayDialog2(int playerNumber)
        {
            Output.DisplayDialog2(playerNumber);
        }

        public void PickValidCoordinateDialog()
        {
            Output.PickValidCoordinateDialog();
        }

        public void YouMustExecuteTheOpponentsPieceDialog()
        {
            Output.YouMustExecuteTheOpponentsPieceDialog();
        }

        public void DisplayTitle()
        {
           Output.DisplayTitle();
        }

        public void DisplayScoreBorder()
        {
            Output.DisplayScoreBorder();
        }

        public bool RulesVisible = true;
        public static void DisplayRules()
        {
            Output.DisplayRules();

        }

        public static void CollapseRules()
        {
            Output.CollapseRules();

        }


        //***************INPUTS*****************
        public void GetCoordinates(out int xCord, out int yCord)
        {
            Input.GetCoordinates(out xCord, out yCord);
        }
        public int MoveToPos()
        {
            return Input.MoveToPos();
        }

        


    }
}
