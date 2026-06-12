using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TicTacToe.Playwright.Automation.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }



    private ILocator NameInput =>
        _page.GetByTestId("input-name");

    private ILocator RegisterButton =>
        _page.GetByTestId("btn-register");

    private ILocator HelloUserLabel =>
        _page.GetByTestId("hello-user");
    private ILocator LogoutButton => _page.GetByTestId("btn-logout");
    private ILocator AuthError => _page.GetByTestId("auth-error");

    public async Task RegisterUser(string userName)
    {
        await NameInput.FillAsync(userName);
        await RegisterButton.ClickAsync();
    }
    public async Task Logout()
    {
        await LogoutButton.ClickAsync();
    }

    public ILocator GetError()
    {
        return AuthError;
    }


    public async Task<string> GetWelcomeMessage()
    {
        return await HelloUserLabel.InnerTextAsync();
    }

    public async Task<bool> IsWelcomeMessageVisible()
    {
        return await HelloUserLabel.IsVisibleAsync();
    }
}