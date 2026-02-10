using Microsoft.Playwright;

namespace E2ETests.e2e.pages;

public class LoginPage : BasePage
{
    private ILocator UsernameInput => Page.Locator("#username");
    private ILocator PasswordInput => Page.Locator("#password");
    private ILocator LoginButton => Page.Locator("button[type='submit']");

    public LoginPage(IPage page) : base(page)
    {
    }

    public async Task GotoAsync()
    {
        var baseUrl = TestConfig.Current.BaseUrl.TrimEnd('/');
        await Page.GotoAsync($"{baseUrl}/login");
    }

    public async Task LoginAsync(string username, string password)
    {
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);
        await LoginButton.ClickAsync();
    }
}

