using Microsoft.Playwright;
using SpecFlowOctopusPMI.Drivers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OctopusPMI.Pages;

public class LoginPage
{

    private readonly ILocator _Username;
    private readonly ILocator _password;
    private readonly ILocator _btnLogin;
    private readonly ILocator _btnLogout;
    private readonly ILocator _Logout_button;
    private readonly ILocator _Confirmpopup;



    public LoginPage(IPage page)
    {
        _Username = page.GetByPlaceholder("Enter your username/email here");
        _password = page.GetByPlaceholder("Enter your password here");
        _btnLogin = page.GetByRole(AriaRole.Button, new() { Name = "Login", Exact = true });
        _btnLogout = page.GetByText("TU");
        _Logout_button = page.GetByRole(AriaRole.Menuitem, new() { Name = "Logout" });
        _Confirmpopup = page.GetByRole(AriaRole.Button, new() { Name = "Yes" });

    }

    public async Task LoginwithCrediantals(string UserName, string Password)
    {

        await _Username.FillAsync(UserName);
        await _password.ClickAsync();
        await _password.FillAsync(Password);
        await _btnLogin.ClickAsync();

    }



    public async Task User_Logout_successfully()
    {
        await _btnLogout.ClickAsync();
        await _Logout_button.ClickAsync();
        await _Confirmpopup.ClickAsync();

    }

}

