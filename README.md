This is a proof of concept. You shouldn't really be using it unless you were told to :-).

## Instructions
When you clone the repo, go into PowerShell (or equivalent) and inside the `browsers` folder, run the following command:

```
$ENV:PLAYWRIGHT_BROWSERS_PATH=(Get-Location).Path
```

then, we install the browsers:

```
npx playwright-cli install
```

You should now be able to run & deploy this **with** the browsers side by side.