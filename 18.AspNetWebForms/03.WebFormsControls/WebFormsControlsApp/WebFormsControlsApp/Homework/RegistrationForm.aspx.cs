using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsControlsApp.Homework
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        private const string RegistrationHeader = "<h3>Registered employee: </h3>";

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.PanelStudent.Controls.Add(new LiteralControl(RegistrationHeader));
            this.PanelStudent.Controls.Add(new LiteralControl(this.LabelFirst.Text + ": " + this.TextBoxFirstName.Text));
            this.PanelStudent.Controls.Add(new LiteralControl("<br />"));
            this.PanelStudent.Controls.Add(new LiteralControl(this.LabelMiddle.Text + ": " + this.TextBoxMiddleName.Text));
            this.PanelStudent.Controls.Add(new LiteralControl("<br />"));
            this.PanelStudent.Controls.Add(new LiteralControl(this.LabelLast.Text + ": " + this.TextBoxLastName.Text));
            this.PanelStudent.Controls.Add(new LiteralControl("<br />"));
            this.PanelStudent.Controls.Add(new LiteralControl(this.LabelGrossSalary.Text + ": " + this.TextBoxGrossSalary.Text));
            this.PanelStudent.Controls.Add(new LiteralControl("<br />"));
            this.PanelStudent.Controls.Add(new LiteralControl(this.LabelJobs.Text + ": " + this.DropDownListJobs.SelectedValue));
            this.PanelStudent.Controls.Add(new LiteralControl("<br />"));
            this.PanelStudent.Controls.Add(new LiteralControl(this.LabelCompanies.Text + ": " + this.DropDownListCompanies.SelectedValue));
        }
    }
}