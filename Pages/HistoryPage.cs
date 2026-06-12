using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TicTacToe.Playwright.Automation.Pages;

public class HistoryPage
{
    private readonly IPage _page;

    public HistoryPage(IPage page)
    {
        _page = page;
    }

    private ILocator HistoryTab
        => _page.GetByTestId("nav-history");

    private ILocator EmptyHistory
        => _page.GetByTestId("history-empty");

    private ILocator HistoryItems
        => _page.GetByTestId("view-history");

    // ===== Actions =====

    public async Task OpenHistory()
    {
        await HistoryTab.ClickAsync();
    }

    // ===== Reads =====

    public ILocator GetEmptyHistory()
    {
        return EmptyHistory;
    }

    public async Task<int> GetHistoryCount()
    {
        var items = await HistoryItems.AllAsync();
        return items.Count;
    }
}