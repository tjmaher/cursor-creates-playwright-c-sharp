README.md

_Like this project? View sample code from the last ten years of T.J. Maher's automation development work at [TJMaher.com | Programming Projects](https://www.tjmaher.com/p/programming-projects.html) and his articles about software testing at [TJMaher.com | Media](https://www.tjmaher.com/p/media.html). And be sure to check out his [LinkedIn Profile](https://www.linkedin.com/in/tjmaher1/)!_

# Introduction by T.J. Maher

It's a head-to-head matchup! Cursor AI versus VS Code + GitHub CoPilot (See the [Login-C-Sharp](https://github.com/tjmaher/login-c-sharp) repo ) to create automated test frameworks using MS Playwright + C#. Who creates the best tests? The best GitHub Actions Workflow? The best README docs? And can it be created only using prompts? 

Let the battle begin! 


# Cursor AI: Activate!

## Playwright + C# E2E Framework

End-to-end tests for `https://the-internet.herokuapp.com/login` using **Playwright for .NET**, **C#**, and **NUnit**, with **Allure** reporting and a **GitHub Actions** workflow (`Test & Report`) that can run smoke, regression, or page-specific suites and publish reports to **GitHub Pages**.

---

## What is Cursor?

**Cursor** is an AI-powered code editor and coding agent that lets you describe changes or features in natural language and have the editor plan, edit, and test code for you. It builds on a VS Code–style editing experience but adds deep AI integration: agents that can explore your codebase, modify files, run tests, and iterate until changes are correct.

- **Product evolution & releases**
  - Cursor grew rapidly throughout **2023**, shipping key features like full-codebase context and GPT‑4–powered completions (see the Cursor changelog and blog, e.g. [“Our problems” (2023)](https://www.cursor.com/blog/problems-2023)).  
  - **Cursor 2.0** and the **Composer** model (their in‑house coding model and multi‑agent interface) were announced on **October 29, 2025**, described in [“Introducing Cursor 2.0 and Composer”](https://cursor.com/blog/2-0).[1]

- **What makes Cursor different**
  - **Agentic coding**: you can ask Cursor to implement changes end‑to‑end; it plans steps, edits multiple files, and runs commands.
  - **Codebase context**: Cursor indexes your repository so the agent can reference relevant files and history when answering questions or making edits.
  - **Multi-agent workflows** (Cursor 2.0+): run multiple agents in parallel on different tasks or branches while Cursor manages conflicts.[1]

- **Official documentation**
  - Main docs: [docs.cursor.com](https://docs.cursor.com/welcome)[2] (also accessible via [`https://cursor.com/docs`](https://cursor.com/docs)[2]).
  - The docs cover:
    - Getting started, installation, and quickstart guides.[2]
    - Agent modes, planning, review, terminal & browser tools.[2]
    - Context (`@` mentions, Rules, Skills, Subagents, Semantic Search).[2]
    - Configuration (shortcuts, themes, ignore files, integrations, parallel agents).[2]

In this repository, **Cursor** was used as the AI agent to:

- Scaffold the .NET + Playwright test project.
- Design and implement page objects, tests, and configuration.
- Create the GitHub Actions workflow and this README.

## Local Development Setup

### Windows 11

- **Prerequisites**
  - Install **.NET SDK 8 or later** (this project targets `net10.0`):
    - Download from [.NET downloads](https://dotnet.microsoft.com/en-us/download).
  - Ensure **PowerShell** is available (Windows 11 ships with it by default).
  - (Optional) Install **Git** from [git-scm.com](https://git-scm.com/).

- **Clone & restore**

```bash
git clone https://github.com/<your-org-or-user>/cursor-creates-playwright-c-sharp.git
cd cursor-creates-playwright-c-sharp
dotnet restore Tests.csproj
```

- **Build & install Playwright browsers**

```bash
dotnet build Tests.csproj
pwsh bin/Debug/net10.0/playwright.ps1 install --with-deps
```

### macOS (MacBook)

- **Prerequisites**
  - Install **Homebrew** (if not already): see [brew.sh](https://brew.sh).
  - Install **.NET SDK**:

```bash
brew install dotnet-sdk
```

  - (Optional) Install **Git**:

```bash
brew install git
```

- **Clone & restore**

```bash
git clone https://github.com/<your-org-or-user>/cursor-creates-playwright-c-sharp.git
cd cursor-creates-playwright-c-sharp
dotnet restore Tests.csproj
```

- **Build & install Playwright browsers**

```bash
dotnet build Tests.csproj
pwsh bin/Debug/net10.0/playwright.ps1 install --with-deps
```

> On macOS, if `pwsh` is not installed, install PowerShell via Homebrew (`brew install powershell`) or use `dotnet tool install --global Microsoft.Playwright.CLI` and then `playwright install`.

---

## Project Structure

High-level structure from the repository root:

```text
cursor-creates-playwright-c-sharp/
  Tests.csproj                 # .NET test project
  e2e/
    BaseTest.cs                # Base NUnit/PageTest class
    Credentials.cs             # (Legacy stub) credentials wrapper
    LoginPageTests.cs          # Login page test suite
    SecureAreaTests.cs         # Secure area test suite
    TestConfig.cs              # JSON-backed configuration loader
    TestData.cs                # (Legacy stub) static test data wrapper
    testdata.json              # Externalized test data (URL, copy, credentials)
    pages/
      BasePage.cs              # Shared Playwright page base class
      LoginPage.cs             # Login page object
      SecureAreaPage.cs        # Secure area page object
  .github/
    workflows/
      playwright-tests.yml     # "Test & Report" GitHub Actions workflow
  bin/                         # Build outputs (generated)
  obj/                         # MSBuild intermediates (generated)
```

---

## Local Setup: How to Run Things

From the repo root:

1. **Restore & build**

```bash
dotnet restore Tests.csproj
dotnet build Tests.csproj
```

2. **Install Playwright browsers** (first time or after browser updates):

```bash
pwsh bin/Debug/net10.0/playwright.ps1 install --with-deps
```

3. **Run all tests**

```bash
dotnet test Tests.csproj
```

4. **Run only smoke tests**

```bash
dotnet test Tests.csproj --filter "TestCategory=smoke"
```

5. **Run only LoginPage or SecureArea tests**

```bash
dotnet test Tests.csproj --filter "FullyQualifiedName~LoginPageTests"
dotnet test Tests.csproj --filter "FullyQualifiedName~SecureAreaTests"
```

The tests use `TestConfig.Current` which reads from `e2e/testdata.json`, so you can change URLs, credentials, and expected UI text without recompiling.

---

## Tools and Technologies

### .NET

- **What it is**: A free, open-source, cross-platform developer platform for building apps (web, desktop, mobile, cloud, etc.).
- **Key release**: **.NET Core 1.0** (the first cross‑platform .NET) was released on **June 27, 2016**, announced on the official .NET Blog: [“Announcing .NET Core 1.0”](https://devblogs.microsoft.com/dotnet/announcing-net-core-1-0/).
- **Docs**: [.NET documentation](https://learn.microsoft.com/dotnet/).

### C#

- **What it is**: A modern, object‑oriented programming language for .NET, designed by Microsoft; widely used for application and test automation development.
- **Docs**: [C# documentation](https://learn.microsoft.com/dotnet/csharp/).

### NUnit

- **What it is**: A unit testing framework for all .NET languages, originally ported from JUnit.
- **Key release**: **NUnit 3.0** (major rewrite) released **November 15, 2015**; see the [NUnit releases](https://github.com/nunit/nunit/releases) and [NUnit.org](https://nunit.org/).
- **Docs**: [NUnit documentation](https://docs.nunit.org/index.html).

### Microsoft Playwright

- **What it is**: A modern browser automation / E2E testing framework supporting Chromium, Firefox, and WebKit with a unified API, including a .NET binding.
- **Key release**: Playwright was officially announced on **January 31, 2020**, as a cross‑browser automation library for modern web apps ([InfoQ summary](https://www.infoq.com/news/2020/01/playwright-browser-automation/)).
- **Docs**:
  - General: [playwright.dev](https://playwright.dev/)
  - .NET: [Playwright for .NET docs](https://playwright.dev/dotnet/docs/intro).

### Allure Report

- **What it is**: A framework‑agnostic test reporting tool that turns raw test results into an interactive HTML dashboard with timelines, history, and rich attachments.
- **Current line**: **Allure 2** is the mature, widely used line; for example, **Allure 2.36.0** was released on December 10 (see [allure2 releases](https://github.com/allure-framework/allure2/releases)).
- **Docs**: [Allure Report documentation](https://allurereport.org/docs/) and [framework integrations](https://allurereport.org/docs/frameworks/).

---

## Why NUnit? Why was it chosen?

- **Mature and widely adopted** in the .NET ecosystem, with strong tooling support (IDE integration, runners, analyzers).
- **Attribute‑driven model** (`[Test]`, `[SetUp]`, `[Category("smoke")]`) makes tests declarative and easy to organize.
- **Rich assertion library** (e.g., `Assert.That(..., Is.EqualTo(...))`, `Does.StartWith(...)`), helpful for readable tests.
- **First‑class support in .NET test tooling** via `Microsoft.NET.Test.Sdk` and `NUnit3TestAdapter`, making it straightforward to run in CI (including GitHub Actions).

For this project, NUnit provides:

- Simple **category‑based filtering** for smoke vs regression suites.
- Seamless integration with **Playwright for .NET** via the `Microsoft.Playwright.NUnit` package.

---

## Alternatives to NUnit

Other popular .NET testing frameworks include:

- **xUnit.net**
  - Convention‑based tests and strong focus on best practices.
  - Widely used in the .NET open‑source ecosystem.
  - Docs: [xunit.net](https://xunit.net/).
- **MSTest / MSTest v2**
  - Microsoft’s own test framework.
  - Deep integration with Visual Studio and Azure DevOps.
  - Docs: [MSTest documentation](https://learn.microsoft.com/visualstudio/test/mstest).
- **FluentAssertions** (assertion library, often used *with* NUnit/xUnit/MSTest)
  - Provides expressive, fluent assertion syntax.
  - Docs: [FluentAssertions docs](https://fluentassertions.com/).

NUnit was chosen primarily for its familiarity, rich assertions, and very strong integration with existing .NET test runners and tools.

---

## CI / CD with GitHub Actions

**GitHub Actions** is GitHub’s built‑in CI/CD platform that runs workflows defined in YAML files inside your repo.

- **Key history**
  - GitHub Actions CI/CD support was announced in public beta on **August 8, 2019**:  
    [“GitHub Actions now supports CI/CD”](https://github.blog/2019-08-08-github-actions-now-supports-ci-cd/).
  - GitHub Actions reached **general availability** on **November 13, 2019**:  
    [“GitHub Actions is generally available”](https://github.blog/changelog/2019-11-11-github-actions-is-generally-available).

- **Docs**
  - Overview: [GitHub Actions documentation](https://docs.github.com/actions).
  - Workflow syntax: [Workflow syntax for GitHub Actions](https://docs.github.com/actions/using-workflows/workflow-syntax-for-github-actions).

### How to run GitHub Actions

- **Automatically**:
  - On pushes or pull requests, if configured under `on: push` / `on: pull_request`.
- **Manually** (`workflow_dispatch`, which this project uses):
  - Go to the repo’s **Actions** tab.
  - Select the **“Test & Report”** workflow.
  - Click **“Run workflow”**, choose the `testSuite` input (`smoke`, `regression`, `LoginPage`, `SecureArea`), then start the run.

---

## How Cursor Created This Project

### Prompts (high‑level summary)

1. **Initial framework setup**
   - User requested: Playwright + C# automation for `https://the-internet.herokuapp.com/login`, with:
     - Tests in `e2e`, page objects in `e2e/pages`, shared `BasePage`.
     - Credentials taken from the site.
     - Tests for headings, body text, and invalid login messages.
     - Smoke tests tagged `smoke`, plus separate `LoginPage` and `SecureArea` scenarios.
2. **Project restructuring**
   - User requested moving `e2e`, `bin`, `obj`, and project file to the repository root and removing the original `E2ETests` folder.
3. **Configuration and test data refactor**
   - User asked to move strings, credentials, and URLs out of tests and into shared configuration / resource files.
4. **CI & reporting**
   - User requested a GitHub Actions workflow (`playwright-tests.yml`) and Allure report generation + GitHub Pages publishing.

### Key commands executed

Representative commands Cursor invoked (via automated shell) while constructing the project:

- Project creation and dependencies:

```bash
dotnet new nunit -n E2ETests
dotnet add E2ETests/E2ETests.csproj package Microsoft.Playwright.NUnit
dotnet build E2ETests/E2ETests.csproj
```

- Restructuring to root:

```bash
dotnet build Tests.csproj
Remove-Item -LiteralPath "d:\src\cursor-creates-playwright-c-sharp\E2ETests" -Recurse -Force
```

- Test runs during development:

```bash
dotnet test Tests.csproj
dotnet test Tests.csproj --filter "TestCategory=smoke"
```

Cursor also used file‑system operations (via the IDE’s tools) to add, update, and delete C# files, the JSON config, and the GitHub Actions workflow YAML.

---

## How Cursor Added Allure Reports

At the workflow level (see `.github/workflows/playwright-tests.yml`), Cursor:

- **Prepared for Allure results**
  - Assumed test execution would produce `allure-results` directories (via an Allure adapter added to the test project).
  - For each browser job (Chromium, Firefox, WebKit), added an **“Upload Allure results”** step:
    - Uses `actions/upload-artifact@v4` to upload any `**/allure-results` folders, named:
      - `allure-results-chromium`
      - `allure-results-firefox`
      - `allure-results-webkit`

- **Generated the aggregated report**
  - Added a `report` job that depends on all browser jobs.
  - Downloads all Allure artifacts into `./allure-results` with `actions/download-artifact@v4`.
  - Uses `simple-elf/allure-report-action@v1.7` to generate a combined HTML report into `./allure-report`.

- **Published to GitHub Pages**
  - Configures GitHub Pages with `actions/configure-pages@v4`.
  - Uploads `./allure-report` as the Pages artifact using `actions/upload-pages-artifact@v3`.
  - Deploys the artifact via `actions/deploy-pages@v4`, publishing the report under the repository’s GitHub Pages URL (e.g., `https://tjmaher.github.io/cursor-creates-playwright-c-sharp/`).

> Note: You still need to add an Allure adapter to the NUnit project (e.g., via NuGet) and configure it to output `allure-results` for the workflow’s reporting steps to have content.

---

## Workflow Command Reference

Commands used inside `.github/workflows/playwright-tests.yml`:

- **`dotnet restore Tests.csproj`**
  - Restores NuGet packages for the test project.  
  - Docs: [Restore packages](https://learn.microsoft.com/dotnet/core/tools/dotnet-restore).

- **`dotnet build Tests.csproj --configuration Release --no-restore`**
  - Builds the test project in Release configuration without restoring packages again.  
  - Docs: [Build command](https://learn.microsoft.com/dotnet/core/tools/dotnet-build).

- **`pwsh bin/Release/net10.0/playwright.ps1 install --with-deps`**
  - Runs the Playwright CLI script generated by the .NET SDK to install required browsers and OS dependencies.  
  - Docs: [Playwright CLI](https://playwright.dev/dotnet/docs/cli).

- **`dotnet test Tests.csproj --configuration Release`**
  - Runs all tests in Release configuration.  
  - Docs: [Test command](https://learn.microsoft.com/dotnet/core/tools/dotnet-test).

- **`dotnet test ... --filter "<expression>"`**
  - Runs only tests matching a filter:
    - `TestCategory=smoke` – smoke tests.
    - `FullyQualifiedName~LoginPageTests` – tests in `LoginPageTests`.
    - `FullyQualifiedName~SecureAreaTests` – tests in `SecureAreaTests`.  
  - Docs: [Filter option](https://learn.microsoft.com/dotnet/core/testing/selective-unit-tests).

- **Bash conditionals in workflow step**:

```bash
if [ "$TEST_SUITE" = "smoke" ]; then
  FILTER='TestCategory=smoke'
elif [ "$TEST_SUITE" = "LoginPage" ]; then
  FILTER='FullyQualifiedName~LoginPageTests'
...
fi
```

Used to translate the `workflow_dispatch` input into a `dotnet test --filter` expression.

---

## GitHub Actions Used in the Workflow

The `playwright-tests.yml` workflow uses these key actions:

- **`actions/checkout@v4`**
  - Checks out the repository code into the runner.  
  - Docs: <https://github.com/actions/checkout>.

- **`actions/setup-dotnet@v4`**
  - Installs and configures .NET SDK versions on the runner.  
  - Docs: <https://github.com/actions/setup-dotnet>.

- **`actions/upload-artifact@v4`**
  - Uploads build/test artifacts (here, `allure-results-*`) for later jobs to use or for download.  
  - Docs: <https://github.com/actions/upload-artifact>.

- **`actions/download-artifact@v4`**
  - Downloads previously uploaded artifacts into the current job (used to aggregate Allure results).  
  - Docs: <https://github.com/actions/download-artifact>.

- **`simple-elf/allure-report-action@v1.7`**
  - Generates an Allure HTML report from collected `allure-results` folders.  
  - Marketplace: <https://github.com/marketplace/actions/allure-report-action>.

- **`actions/configure-pages@v4`**
  - Sets up the GitHub Pages deployment environment for the workflow.  
  - Docs: <https://github.com/actions/configure-pages>.

- **`actions/upload-pages-artifact@v3`**
  - Packages the generated site (here, the Allure HTML report in `./allure-report`) as an artifact for Pages.  
  - Docs: <https://github.com/actions/upload-pages-artifact>.

- **`actions/deploy-pages@v4`**
  - Deploys the uploaded Pages artifact to GitHub Pages.  
  - Docs: <https://github.com/actions/deploy-pages>.

Together, these actions create a CI pipeline that:

1. Restores and builds the .NET Playwright test project.
2. Runs tests across Chromium, Firefox, and WebKit.
3. Collects Allure test results.
4. Generates and publishes an interactive test report to GitHub Pages.

---

## Understanding `obj/` and `Tests.csproj`

### What’s in the `obj` folder?

The `obj` folder is where MSBuild and the .NET SDK keep **intermediate build artifacts**. You normally don’t commit it to source control, but it’s helpful to know what lives there:

- **`.NETCoreApp,Version=v10.0.AssemblyAttributes.cs`**
  - Auto-generated file that adds the `[TargetFramework]` attribute to the compiled assembly based on `TargetFramework` in `Tests.csproj`.

- **`Tests.AssemblyInfo.cs` / `Tests.AssemblyInfoInputs.cache`**
  - Generated assembly-level metadata: title, version, configuration, etc.
  - The `.cache` file tracks inputs so MSBuild knows when it needs to regenerate.

- **`Tests.assets.cache` and `project.assets.json` (one level up)**
  - Represent resolved **NuGet dependencies** and their transitive closure.
  - Used by MSBuild to know which assemblies to reference when compiling.

- **`Tests.csproj.AssemblyReference.cache` / `Tests.csproj.CoreCompileInputs.cache`**
  - Caches of references and compile-time inputs so incremental builds can skip work if nothing changed.

- **`Tests.GeneratedMSBuildEditorConfig.editorconfig`**
  - Auto-generated `EditorConfig` that encodes compilation and analyzer settings derived from the project and SDK.

- **`Tests.GlobalUsings.g.cs`**
  - Contains global `using` directives generated due to `ImplicitUsings=enable` in `Tests.csproj`, so you don’t have to manually import common namespaces.

- **`Tests.dll`, `Tests.pdb`, `Tests.genruntimeconfig.cache`, `Tests.csproj.FileListAbsolute.txt`, `Tests.csproj.Up2Date`**
  - `Tests.dll` and `Tests.pdb` are the compiled test assembly and debug symbols for the **Debug** configuration.
  - `genruntimeconfig` and `Up2Date` help the build know when a rebuild is necessary.
  - `FileListAbsolute.txt` tracks which files were output by the build.

- **`ref/Tests.dll` and `refint/Tests.dll`**
  - Reference assemblies used for compile-time binding (they contain public API surface only, not full implementation) to support faster and more deterministic builds.

In short, `obj/` is MSBuild’s working directory; you almost never touch files here directly, but they explain *how* the project is compiled and why incremental builds are fast.

### What does `Tests.csproj` configure?

`Tests.csproj` is the **project file** that tells the .NET SDK how to build and run the test suite:

- **Target and language**
  - `TargetFramework` is set to `net10.0`, so the project compiles against .NET 10.
  - `LangVersion` is `latest`, enabling the newest C# language features supported by the installed SDK.
  - `ImplicitUsings` is `enable`, so common namespaces are added automatically (and emitted into `Tests.GlobalUsings.g.cs`).
  - `Nullable` is `enable`, turning on nullable reference type analysis for safer APIs.
  - `IsPackable` is `false`, because this project is intended as a **test project**, not a NuGet package.

- **Test and tooling packages**
  - `Microsoft.NET.Test.Sdk` – the test host that integrates with `dotnet test`.
  - `NUnit`, `NUnit3TestAdapter`, `NUnit.Analyzers` – the NUnit framework, Visual Studio / `dotnet test` adapter, and static analysis rules.
  - `Microsoft.Playwright.NUnit` – Playwright’s NUnit integration, providing `PageTest` and Playwright setup/teardown.
  - `coverlet.collector` – enables code coverage collection when running tests with `dotnet test --collect:"XPlat Code Coverage"`.

- **Usings and shared references**
  - A `Using` item adds `NUnit.Framework` as a **global using**, so every test file can use NUnit attributes like `[Test]`, `[SetUp]`, and assertions without adding `using NUnit.Framework;` to each file.

- **Content copied to output**
  - `e2e\testdata.json` is included as `None` with `CopyToOutputDirectory="PreserveNewest"`, ensuring the JSON config is available beside `Tests.dll` at runtime.
  - `TestConfig` then loads this file from the output directory so tests and page objects always read the latest configuration.

Together, **`Tests.csproj`** defines *what* to build and *which libraries* to use, while **`obj/`** shows *how* the SDK and MSBuild orchestrate the build under the hood.

---

## Understanding the `bin` Folder

Where `obj/` holds **intermediate build artifacts**, the `bin/` folder contains the **final, runnable outputs** for each configuration (`Debug` / `Release`) and target framework (`net10.0` in this project).

For example, under `bin/Debug/net10.0` you’ll find:

- **`Tests.dll` and `Tests.pdb`**
  - `Tests.dll` is the **compiled test assembly** that `dotnet test` executes.
  - `Tests.pdb` contains debug symbols to enable meaningful stack traces and step-through debugging in your IDE.

- **`Tests.runtimeconfig.json` and `Tests.deps.json`**
  - `Tests.runtimeconfig.json` tells the .NET host which runtime to load (e.g., `.NET 10`) and any runtime-specific options.  
  - `Tests.deps.json` describes all **runtime dependencies** (NuGet packages, assembly versions, dependency graph) for your tests and is used by the .NET host to resolve assemblies at run time.

- **Playwright and test framework assemblies**
  - `Microsoft.Playwright.dll`, `Microsoft.Playwright.NUnit.dll`, `Microsoft.Playwright.TestAdapter.dll` – the Playwright engine, NUnit integration, and test adapter used when running tests.
  - `nunit.framework.dll`, `nunit.framework.legacy.dll`, `NUnit3.TestAdapter.dll`, `nunit.engine*.dll`, `testcentric.engine.metadata.dll` – NUnit’s core framework and test engine components.
  - `Microsoft.NET.Test.Sdk`–related assemblies such as:
    - `Microsoft.TestPlatform.*.dll`, `Microsoft.VisualStudio.TestPlatform.*.dll`, `testhost.dll`, `testhost.exe` – the infrastructure that hosts and runs your tests when you invoke `dotnet test`.
  - Supporting libraries like `Microsoft.ApplicationInsights.dll`, `Microsoft.Bcl.AsyncInterfaces.dll`, and `Newtonsoft.Json.dll`.

- **Localized resource assemblies**
  - Subfolders like `cs/`, `de/`, `fr/`, `ja/`, `ko/`, `zh-Hans/`, etc. contain **satellite resource assemblies** (e.g., `*.resources.dll`) for localized messages from the test platform and tooling.

- **Playwright support files**
  - `.playwright/` – Playwright-managed assets (browsers, drivers, helper scripts) needed to run tests across Chromium, Firefox, and WebKit.
  - `playwright.ps1` – PowerShell script entry point to the Playwright CLI for this project; used in CI and local setup to install browsers:

    ```bash
    pwsh bin/Debug/net10.0/playwright.ps1 install --with-deps
    ```

- **Copied configuration / data**
  - `e2e/testdata.json` – the JSON config copied from the `e2e/` folder (as configured in `Tests.csproj`), so `TestConfig` can read it at runtime from beside the compiled assembly.

In summary:

- **`obj/`** = “how MSBuild thinks” (intermediate compilation metadata and caches).
- **`bin/`** = “what you actually run” (the compiled test assembly, dependencies, runtime configs, and Playwright tooling used by `dotnet test` and GitHub Actions.

