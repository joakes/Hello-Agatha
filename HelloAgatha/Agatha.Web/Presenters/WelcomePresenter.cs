namespace Agatha.Web.Presenters
{
    using Common;
    using Model;
    using Views;

    public class WelcomePresenter
    {
        private IWelcomeView _welcomeView;
        private readonly IRequestDispatcher _requestDispatcher;

        public WelcomePresenter(IRequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }

        public void Init(IWelcomeView view, bool isPostBack) // todo fix this hack for setting the view
        {
            _welcomeView = view;
            var response = _requestDispatcher.Get<WelcomeMessageResponse>(new WelcomeMessageRequest());
            _welcomeView.WelcomeMessage = response.WelcomeMessage;
        }
    }
}