using NUnit.Framework;
using System.Threading.Tasks;
using TicTacToe.Playwright.Automation.Core;
using TicTacToe.Playwright.Automation.Pages;

namespace TicTacToe.Playwright.Automation.Tests;

[TestFixture]
public class ProfileTests : TestBase
{

    [Test]
    public async Task User_Should_Be_Able_To_Update_Profile_Name()
    {
        var profile = new ProfilePage(Page);

        // Act
        await profile.ChangeUserName("TestName2");

        // Assert 1: message is visible
        var message = profile.GetProfileMessage();

        Assert.That(await message.IsVisibleAsync(), Is.True);
    }
}