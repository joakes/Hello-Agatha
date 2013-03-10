using System;
namespace Agatha.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var welcomeControl = LoadControl("UserControls/WelcomeControl.ascx");
            ControlPlaceHolder.Controls.Add(welcomeControl);
        }
    }
}