using System;

namespace Agatha.Web.UserControls
{
    using Presenters;
    using Views;
    using global::Ninject;

    public partial class WelcomeControl : BaseControl, IWelcomeView
    {
        [Inject]
        public WelcomePresenter Presenter { private get; set; }

        public string WelcomeMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Init(this, IsPostBack);
        }    
    }
}