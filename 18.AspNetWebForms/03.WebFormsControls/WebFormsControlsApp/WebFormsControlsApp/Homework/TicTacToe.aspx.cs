using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsControlsApp.Homework
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ViewState["Board"] == null)
            {
                ViewState["Board"] = "---------";
            }

            var board = ViewState["Board"].ToString();

            this.Btn0.Text = board[0].ToString();
            this.Btn1.Text = board[1].ToString();
            this.Btn2.Text = board[2].ToString();
            this.Btn3.Text = board[3].ToString();
            this.Btn4.Text = board[4].ToString();
            this.Btn5.Text = board[5].ToString();
            this.Btn6.Text = board[6].ToString();
            this.Btn7.Text = board[7].ToString();
            this.Btn8.Text = board[8].ToString();
        }

        protected void Click_Command(object sender, CommandEventArgs e)
        {
            if (ViewState["Board"] == null)
            {
                ViewState["Board"] = "---------";
            }

            var board = ViewState["Board"].ToString().ToCharArray();

            var index = int.Parse(e.CommandArgument.ToString());
            if (board[index] != '-')
            {
                this.Result.Text = "Can not make this move!";
                return;
            }

            board[index] = 'X';
            ViewState["Board"] = new string(board);

            var logic = new GameBoardEngine();
            var resultX = logic.GetResult(board);
            if (resultX == GameResult.WinnerIsX)
            {
                this.Result.Text = "Winner ";
                this.RestartGame();
                return;
            }
            else if (resultX == GameResult.Draw)
            {
                this.Result.Text = "Draw";
                this.RestartGame();
                return;
            }


            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-')
                {
                    board[i] = 'O';
                    break;
                }
            }

            ViewState["Board"] = new string(board);

            var resultY = logic.GetResult(board);
            if (resultY == GameResult.WinnerIsO)
            {
                this.Result.Text = "GUBER! PROBVAI PAK!";
                this.RestartGame();
                return;
            }
            else if (resultY == GameResult.Draw)
            {
                this.Result.Text = "Draw";
                this.RestartGame();
                return;
            }
        }

        private void RestartGame()
        {
            ViewState["Board"] = "---------";
            this.Btn0.Text = ""; this.Btn1.Text = ""; this.Btn2.Text = "";
            this.Btn3.Text = ""; this.Btn4.Text = ""; this.Btn5.Text = "";
            this.Btn6.Text = ""; this.Btn7.Text = ""; this.Btn8.Text = "";
        }
    }
}