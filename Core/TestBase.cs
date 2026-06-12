using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;


namespace TicTacToe.Playwright.Automation.Core;

public abstract class TestBase
{
    protected IPlaywright Playwright = null!;
    protected IBrowser Browser = null!;
    protected IBrowserContext Context = null!;
    protected IPage Page = null!;

    protected const string BaseUrl =
        "file:///D:/TicTacToe/index.html";

    [SetUp]
    public async Task SetUp()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 300
        });

        Context = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1280,
                Height = 720
            }
        });

        Page = await Context.NewPageAsync();

        await Page.GotoAsync(BaseUrl);
        await WaitForAppReady();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.CloseAsync();
        await Browser.CloseAsync();
        Playwright.Dispose();
    }

    /// <summary>
    /// Wait until main UI is ready
    /// </summary>
    protected virtual async Task WaitForAppReady()
    {
        await Page.WaitForSelectorAsync("[data-testid='input-name']", new()
        {
            Timeout = 5000
        });
    }

    /// <summary>
    /// Small helper for clicking cells (TicTacToe grid)
    /// </summary>
    protected async Task ClickCell(int row, int col)
    {
        await Page.ClickAsync($"[data-cell='{row}-{col}']");
    }

    /// <summary>
    /// Read cell value
    /// </summary>
    protected async Task<string> GetCell(int row, int col)
    {
        return await Page.InnerTextAsync($"[data-cell='{row}-{col}']");
    }

    /// <summary>
    /// Navigate tabs (Play/Profile/History)
    /// </summary>
    protected async Task OpenTab(string tab)
    {
        await Page.GetByTestId(tab).ClickAsync();
    }
}