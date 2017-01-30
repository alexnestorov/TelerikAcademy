using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloAspNet
{
    public partial class HelloWebForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisplayText_Click(object sender, EventArgs e)
        {
            this.ResultText.Text = "Hello, " + this.Text.Text;
        }
    }
}