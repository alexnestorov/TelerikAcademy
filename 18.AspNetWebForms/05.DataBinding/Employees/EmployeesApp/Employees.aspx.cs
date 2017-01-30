namespace EmployeesApp
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Nortthwind;

    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new NorthwindEntities())
            {
                this.GridViewEmployees.DataSource = context.Employees.ToList();

                Page.DataBind();
            }
        }
    }
}