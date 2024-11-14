# Common Playwright Commands 

Note: The following commands are for the Playwright CLI.

Some commands require the application to be running in the background.

## Start Codegen

This command starts the codegen tool for the specified URL.

```shell
pwsh bin\\Debug\\net9.0\\playwright.ps1 codegen https://localhost:7002
```

## Install Playwright

PowerShell 7.x required.

Install Playwright browsers.

```shell
pwsh bin\\Debug\\net9.0\\playwright.ps1 install
```

## Run Playwright Tests

Run all tests 

```shell
dotnet test 
```

## Debug 

**Run in debug mode**

Start tests in debug mode, this will launch a headed test with player.

```shell
$env:PWDEBUG=1
dotnet test
```

**View Playwright Trace Files**

This command initializes the trace file viewer. After running tests a trace file can be viewed with step-by-step snapshots of the test process.

```shell
pwsh bin\\Debug\\net9.0\\playwright.ps1 show-trace ClasName.TestName.zip
```

## Launch Configurations

Run tests on different browsers: launch configuration

Specify which browser you would like to run your tests on by adjusting the launch configuration options:

```shell
dotnet test -- Playwright.BrowserName=webkit
```

To run your test on multiple browsers or configurations, you need to invoke the dotnet test command multiple times. There you can then either specify the BROWSER environment variable or set the Playwright.BrowserName via the runsettings file:

```shell
dotnet test --settings \\runsettings\\chrome.runsettings
dotnet test --settings \\runsettings\\firefox.runsettings
dotnet test --settings \\runsettings\\webkit.runsettings
```

## Running in CI

See: https://playwright.dev/dotnet/docs/ci-intro
