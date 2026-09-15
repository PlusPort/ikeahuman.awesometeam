import { defineConfig } from '@playwright/test'

export default defineConfig({
  testDir: './e2e',
  fullyParallel: true,
  reporter: 'list',
  use: {
    baseURL: 'http://localhost:5173',
  },
  // The backend keeps its Employee list in memory (no persistence, by design —
  // see the data-model ticket), so each fresh `dotnet run` starts clean.
  webServer: [
    {
      command: 'dotnet run --launch-profile http',
      cwd: '../backend',
      url: 'http://localhost:5292/sites',
      reuseExistingServer: false,
      timeout: 60_000,
    },
    {
      command: 'npm run dev',
      url: 'http://localhost:5173',
      reuseExistingServer: false,
      timeout: 30_000,
    },
  ],
})
