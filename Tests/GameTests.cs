using NUnit.Framework;
using System.Threading.Tasks;
using TicTacToe.Playwright.Automation.Core;
using TicTacToe.Playwright.Automation.Pages;

namespace TicTacToe.Playwright.Automation.Tests;

[TestFixture]
public class GameTests : TestBase
{


    [Test]
    public async Task Player_Move_And_Computer_Response_Should_Work()
    {
        var game = new GamePage(Page);

        // Player move
        await game.ClickCell("0");

        // Wait for AI
        await Page.WaitForTimeoutAsync(500);

        // Assert 1: player + AI moved (at least 2 filled cells)
        Assert.That(await game.GetFilledCellsCount(), Is.EqualTo(2));

        // Assert 2: AI has made at least one move (O exists)
        Assert.That(await game.GetOCount(), Is.EqualTo(1));
    }
}