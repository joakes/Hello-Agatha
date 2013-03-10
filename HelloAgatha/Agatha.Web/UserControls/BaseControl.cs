namespace Agatha.Web.UserControls
{
    using App_Start;

    public class BaseControl : System.Web.UI.UserControl
    {
        public BaseControl()
        {
            NinjectWebCommon.Inject(this);
        }
    }
}