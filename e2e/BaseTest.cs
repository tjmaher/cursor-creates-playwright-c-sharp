using Microsoft.Playwright.NUnit;
using Allure.Net.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace E2ETests.e2e;

/// <summary>
/// Base test class that provides access to Playwright's PageTest features,
/// and common test utilities such as Allure attachments.
/// </summary>
public abstract class BaseTest : PageTest
{
    [TearDown]
    public async Task CaptureScreenshotOnFailureAsync()
    {
        var outcome = TestContext.CurrentContext.Result.Outcome.Status;

        if (outcome == TestStatus.Passed)
        {
            return;
        }

        // Ensure we have a page (Playwright) and a place to store attachments.
        if (Page is null)
        {
            return;
        }

        var testId = TestContext.CurrentContext.Test.ID;
        var testName = TestContext.CurrentContext.Test.Name;
        var workDir = TestContext.CurrentContext.WorkDirectory;

        var screenshotsDir = Path.Combine(workDir, "allure-results");
        Directory.CreateDirectory(screenshotsDir);

        var fileName = $"{SanitizeFileName(testName)}_{DateTime.UtcNow:yyyyMMdd_HHmmssfff}.png";
        var filePath = Path.Combine(screenshotsDir, fileName);

        await Page.ScreenshotAsync(new()
        {
            Path = filePath,
            FullPage = true
        });

        AllureApi.AddAttachment(
            $"Last page screenshot - {testName}",
            "image/png",
            filePath);
    }

    private static string SanitizeFileName(string name)
    {
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(c, '_');
        }

        return name;
    }
}

