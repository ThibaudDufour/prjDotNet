using Projet.Business.Auth;
using Recap.Views;

namespace Projet.Controllers
{
    public class LoginController
    {
        private readonly AuthService _auth;
		private readonly LoginView _loginView;

		public LoginController(LoginView loginView)
		{
			_auth = new AuthService();
			_loginView = loginView;
		}

		public async Task Register()
		{
			string name = string.Empty;
			string email = string.Empty;
			string password = string.Empty;

			do
			{
				name = _loginView.GetName();
				email = _loginView.GetEmail();
				password = _loginView.GetPassword();
			}
			while (!_loginView.Validate(name, email, password));
			
			int res = await _auth.Register(name, email, password);
			if (res == -1)
			{
				_loginView.ShowEmailAlreadyUsed();
			}
			else if (res == 0)
			{
				_loginView.ShowRegistrationError();
			}
			else
			{
				_loginView.ShowRegistrationSuccess();
			}
		}

		public async Task<bool> Login()
		{
			string email = _loginView.GetEmail();
			string password = _loginView.GetPassword();
			var user = await _auth.Login(email, password);

			if (user == null)
			{
				_loginView.ShowLoginError();
				return false;
			}
			else
			{
				_loginView.ShowSuccessMessage();
				_loginView.ShowWelcomeMessage(user.Name);
				return true;
			}
		}
	}
}
