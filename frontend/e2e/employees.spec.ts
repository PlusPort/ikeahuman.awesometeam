import { expect, test } from '@playwright/test'

test.describe('Add/edit employee', () => {
  test('admin can add a new employee', async ({ page }) => {
    await page.goto('/')
    await expect(page.getByRole('heading', { name: 'Employees' })).toBeVisible()

    await page.getByRole('button', { name: 'Add employee' }).click()
    await page.getByLabel('Name').fill('Alex Admin-Added')
    await page.getByLabel('Site').selectOption({ label: 'Malmo' })
    await page.getByLabel('Role').selectOption({ label: 'Site Manager' })
    await page.getByRole('button', { name: 'Add employee' }).click()

    await expect(page.getByText('Alex Admin-Added — Malmo — Site Manager')).toBeVisible()
  })

  test('admin can edit an existing employee', async ({ page }) => {
    await page.goto('/')
    await page.getByRole('button', { name: 'Add employee' }).click()
    await page.getByLabel('Name').fill('Jordan To-Edit')
    await page.getByLabel('Site').selectOption({ label: 'Amsterdam' })
    await page.getByLabel('Role').selectOption({ label: 'Warehouse Associate' })
    await page.getByRole('button', { name: 'Add employee' }).click()
    await expect(page.getByText('Jordan To-Edit — Amsterdam — Warehouse Associate')).toBeVisible()

    const row = page.locator('li', { hasText: 'Jordan To-Edit' })
    await row.getByRole('button', { name: 'Edit' }).click()
    await page.getByLabel('Site').selectOption({ label: 'Vilnius' })
    await page.getByLabel('Role').selectOption({ label: 'Forklift Operator' })
    await page.getByRole('button', { name: 'Save changes' }).click()

    await expect(page.getByText('Jordan To-Edit — Vilnius — Forklift Operator')).toBeVisible()
  })

  test('non-admin cannot see add/edit controls', async ({ page }) => {
    await page.goto('/')
    await page.getByLabel('Acting as').selectOption('User')

    await expect(page.getByRole('button', { name: 'Add employee' })).toHaveCount(0)
    await expect(page.getByRole('button', { name: 'Edit' })).toHaveCount(0)
  })

  test('empty name is rejected', async ({ page }) => {
    await page.goto('/')
    await page.getByRole('button', { name: 'Add employee' }).click()
    await page.getByRole('button', { name: 'Add employee' }).click()

    await expect(page.getByRole('alert')).toHaveText('Name is required.')
  })
})
