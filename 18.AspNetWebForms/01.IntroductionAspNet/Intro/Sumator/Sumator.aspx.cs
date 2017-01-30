using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                var firstNumber = double.Parse(this.TextBoxFirstNumber.Text);
                var secondNumber = double.Parse(this.TextBoxSecondNumber.Text);
                var sum = firstNumber + secondNumber;
                this.TextBoxSum.Text = sum.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                this.TextBoxSum.Text = "Entered numbers were not valid.";
            }
        }
    }
}