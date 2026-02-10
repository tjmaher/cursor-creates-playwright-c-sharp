using E2ETests.e2e.pages;

namespace E2ETests.e2e;

public class LoginPageTests : BaseTest
{
    [Test]
    [Category("smoke")]
    public async Task LoginPage_ShouldHaveExpectedHeading()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GotoAsync();

        var heading = await loginPage.GetHeadingAsync();

        Assert.That(heading, Is.EqualTo(TestConfig.Current.LoginPage.Heading));
    }

    [Test]
    public async Task LoginPage_ShouldHaveExpectedBodyText()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GotoAsync();

        var bodyText = await loginPage.GetBodyTextAsync();

        Assert.That(bodyText.Trim(), Is.EqualTo(TestConfig.Current.LoginPage.BodyText));
    }

    [Test]
    [Category("smoke")]
    public async Task InvalidLogin_ShouldShowFailureMessage()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GotoAsync();
        await loginPage.LoginAsync("invalidUser", TestConfig.Current.Credentials.ValidPassword);

        var flash = await loginPage.GetFlashMessageAsync();

        Assert.That(flash, Does.StartWith(TestConfig.Current.LoginPage.InvalidUsernameMessagePrefix));
    }
}

