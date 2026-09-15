# Test Report Template

Standard structure for every test report produced in the exercise project. Claude should follow this template when summarizing a test run.

**How to use this page:** copy the **Template** section below for each new report. The **Example** section further down shows it filled in — it's a sample only, not a real report.

## Template

| Date | *YYYY-MM-DD* |
| --- | --- |
| Trigger | *Manual / scheduled / on PR* |
| Branch / commit | *e.g. main @ abc1234* |
| Result | *Passed / Failed* |
| Run link | *Link to the CI run* |

### Summary

| Suite | Total | Passed | Failed | Skipped |
| --- | --- | --- | --- | --- |
| *e.g. Unit* | *0* | *0* | *0* | *0* |

### Failures

| Test | Expected | Actual | Notes |
| --- | --- | --- | --- |
| *Test name* | *What should have happened* | *What actually happened* | *Suspected cause, link to ticket if filed* |

### Follow-up

* [ ] Failures triaged and tickets filed for real bugs
* [ ] Flaky tests flagged separately from real failures

---

## Example EXAMPLE — NOT A REAL REPORT

Everything below is sample content to illustrate the template. Replace it entirely when creating a real report.

| Date | 2026-09-14 |
| --- | --- |
| Trigger | On PR #128 |
| Branch / commit | feature/category-filter @ a1b2c3d |
| Result | Failed |
| Run link | <https://github.com/example-org/example-repo/actions/runs/123456> |

### Summary

| Suite | Total | Passed | Failed | Skipped |
| --- | --- | --- | --- | --- |
| Unit | 84 | 84 | 0 | 0 |
| E2E | 12 | 11 | 1 | 0 |

### Failures

| Test | Expected | Actual | Notes |
| --- | --- | --- | --- |
| products.spec — filter by category updates grid | Grid shows only items in the selected category | Grid stayed unfiltered; console showed a 404 on the filter API call | Likely a route mismatch introduced in this PR — filed as PROJ-491 |

### Follow-up

* [x] Failures triaged and tickets filed for real bugs
* [x] Flaky tests flagged separately from real failures
