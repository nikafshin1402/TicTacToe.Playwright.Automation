using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TicTacToe.Playwright.Automation.Pages;

public class ProfilePage
{
    private readonly IPage _page;

    public ProfilePage(IPage page)
    {
        _page = page;
    }

    private ILocator ProfileNameInput
        => _page.GetByTestId("input-profile-name");

    private ILocator SaveButton
        => _page.GetByTestId("btn-save-profile");

    private ILocator ProfileMessage
        => _page.GetByTestId("profile-message");

    // ===== Actions =====

    public async Task ChangeUserName(string newName)
    {
        await ProfileNameInput.ClickAsync();
        await ProfileNameInput.FillAsync(newName);
        await SaveButton.ClickAsync();
    }

    // ===== Assertions helpers =====

    public ILocator GetProfileMessage()
    {
        return ProfileMessage;
    }

    public async Task<string> GetMessageText()
    {
        return await ProfileMessage.InnerTextAsync();
    }
}