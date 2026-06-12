using NUnit.Framework;
using System.Threading.Tasks;
using TicTacToe.Playwright.Automation.Core;
using TicTacToe.Playwright.Automation.Pages;

namespace TicTacToe.Playwright.Automation.Tests;

[TestFixture]
public class LoginTests : TestBase
{
    [Test]
    public async Task User_Should_Register_Successfully()
    {
        // Arrange
        var loginPage = new LoginPage(Page);

        // Act
        await loginPage.RegisterUser("TestName");

        // Assert
        Assert.That(
            await loginPage.IsWelcomeMessageVisible(),
            Is.True,
            "Welcome message should be displayed after registration.");
    }

    [Test]
    public async Task User_Should_Not_Register_With_Same_User()
    {
        var loginPage = new LoginPage(Page);

        // 1. First registration
        await loginPage.RegisterUser("TestName");

        // 2. Logout
        await loginPage.Logout();

        // 3. Try register same user again
        await loginPage.RegisterUser("TestName");

        // 4. Assert error message appears
        var error = loginPage.GetError();

        Assert.That(await error.IsVisibleAsync(), Is.True);
    }
}