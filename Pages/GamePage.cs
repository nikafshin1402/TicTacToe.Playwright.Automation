using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Linq;

namespace TicTacToe.Playwright.Automation.Pages;

public class GamePage
{
    private readonly IPage _page;

    public GamePage(IPage page)
    {
        _page = page;
    }

    private ILocator Cell(string id)
        => _page.GetByTestId($"cell-{id}");

    private ILocator AllCells
        => _page.Locator("[data-testid^='cell-']");

    public async Task ClickCell(string id)
    {
        await Cell(id).ClickAsync();
    }

    public async Task<string> GetCellText(string id)
    {
        return await Cell(id).InnerTextAsync();
    }

    public async Task<int> GetFilledCellsCount()
    {
        var cells = await AllCells.AllAsync();

        int count = 0;

        foreach (var cell in cells)
        {
            var text = await cell.InnerTextAsync();

            if (!string.IsNullOrEmpty(text))
                count++;
        }

        return count;
    }

    public async Task<int> GetOCount()
    {
        var cells = await AllCells.AllInnerTextsAsync();
        return cells.Count(x => x == "O");
    }
}