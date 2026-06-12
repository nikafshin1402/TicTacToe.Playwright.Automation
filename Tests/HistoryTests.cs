using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.Playwright.Automation.Pages;
using TicTacToe.Playwright.Automation.Core;

namespace TicTacToe.Playwright.Automation.Tests;

[TestFixture]
public class HistoryTests : TestBase
{
    // =========================================
    // TC-H1: Empty history on first login
    // =========================================
    [Test]
    public async Task History_Should_Be_Empty_On_First_Login()
    {
        var history = new HistoryPage(Page);

        await history.OpenHistory();

        Assert.That(
            await history.GetEmptyHistory().IsVisibleAsync(),
            Is.True);
    }

    // =========================================
    // TC-H2: History should contain items after games
    // =========================================
    [Test]
    public async Task History_Should_Have_Items_After_Game_Play()
    {
        var history = new HistoryPage(Page);

        // simulate history already created (basic flow)
        await Page.GetByTestId("cell-0").ClickAsync();
        await Page.WaitForTimeoutAsync(500);

        await history.OpenHistory();

        Assert.That(
            await history.GetHistoryCount(),
            Is.GreaterThan(0));
    }
}