using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsControlsApp.Homework
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        private readonly Random random = new Random();

        protected void Btn_Generate_Random_Click(object sender, EventArgs e)
        {
            try
            {
                var min = int.Parse(this.Min.Text);
                var max = int.Parse(this.Max.Text);
                this.randomNumber.Text = "Random Number: " + this.random.Next(min, max).ToString();
            }
            catch (Exception)
            {
                this.randomNumber.Text = "Not a valid input";
            }
        }
    }
}