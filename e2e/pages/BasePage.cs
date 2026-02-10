using Microsoft.Playwright;

namespace E2ETests.e2e.pages;

public abstract class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }

    protected ILocator Heading => Page.Locator("h2");

    protected ILocator BodyText => Page.Locator(".subheader");

    protected ILocator FlashMessage => Page.Locator("#flash");

    public async Task<string> GetHeadingAsync() => await Heading.InnerTextAsync();

    public async Task<string> GetBodyTextAsync() => await BodyText.InnerTextAsync();

    public async Task<string> GetFlashMessageAsync()
    {
        var text = await FlashMessage.InnerTextAsync();
        return text.Trim();
    }
}

