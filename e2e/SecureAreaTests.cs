using E2ETests.e2e.pages;

namespace E2ETests.e2e;

public class SecureAreaTests : BaseTest
{
    private async Task<SecureAreaPage> LoginAndNavigateToSecureAreaAsync()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync();
        await loginPage.LoginAsync(
            TestConfig.Current.Credentials.ValidUsername,
            TestConfig.Current.Credentials.ValidPassword);
        return new SecureAreaPage(Page);
    }

    [Test]
    [Category("smoke")]
    public async Task SecureArea_ShouldHaveExpectedHeading()
    {
        var secureArea = await LoginAndNavigateToSecureAreaAsync();

        var heading = await secureArea.GetHeadingAsync();

        Assert.That(heading, Is.EqualTo(TestConfig.Current.SecureArea.Heading));
    }

    [Test]
    public async Task SecureArea_ShouldHaveExpectedBodyText()
    {
        var secureArea = await LoginAndNavigateToSecureAreaAsync();

        var bodyText = await secureArea.GetBodyTextAsync();

        Assert.That(bodyText.Trim(), Is.EqualTo(TestConfig.Current.SecureArea.BodyText));
    }

    [Test]
    public async Task SuccessfulLogin_ShouldShowSuccessFlashMessage()
    {
        var secureArea = await LoginAndNavigateToSecureAreaAsync();

        var flash = await secureArea.GetFlashMessageAsync();

        Assert.That(flash, Does.StartWith(TestConfig.Current.SecureArea.SuccessfulLoginMessagePrefix));
    }
}

