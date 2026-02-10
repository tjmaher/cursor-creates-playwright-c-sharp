using Microsoft.Playwright;

namespace E2ETests.e2e.pages;

public class SecureAreaPage : BasePage
{
    private ILocator LogoutButton => Page.Locator("a[href='/logout']");

    public SecureAreaPage(IPage page) : base(page)
    {
    }

    public async Task LogoutAsync()
    {
        await LogoutButton.ClickAsync();
    }
}

