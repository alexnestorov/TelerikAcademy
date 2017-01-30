using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsControlsApp.Homework
{
    public class GameBoardEngine
    {
        public GameResult GetResult(char[] board)
        {
            // horizontal
            if (board[0] == board[1] && board[1] == board[2] && board[0] != '-')
            {
                return board[0] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            if (board[3] == board[4] && board[4] == board[5] && board[3] != '-')
            {
                return board[3] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            if (board[6] == board[7] && board[7] == board[8] && board[6] != '-')
            {
                return board[6] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            // vertical
            if (board[0] == board[3] && board[3] == board[6] && board[0] != '-')
            {
                return board[0] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            if (board[1] == board[4] && board[4] == board[7] && board[1] != '-')
            {
                return board[1] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            if (board[2] == board[5] && board[5] == board[8] && board[2] != '-')
            {
                return board[2] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            // diagonal
            if (board[0] == board[4] && board[4] == board[8] && board[0] != '-')
            {
                return board[0] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            if (board[2] == board[4] && board[4] == board[6] && board[2] != '-')
            {
                return board[2] == 'X' ? GameResult.WinnerIsX : GameResult.WinnerIsO;
            }

            // game goes on
            if (board.Any(b => b == '-'))
            {
                return GameResult.StillGoing;
            }

            return GameResult.Draw;
        }
    }


}
