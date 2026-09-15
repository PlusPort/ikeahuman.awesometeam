# PR Description Template

Standard structure for every pull request opened in the exercise project. Claude should follow this template when drafting PR descriptions.

**How to use this page:** copy the **Template** section below for each new PR. The **Example** section further down shows it filled in — it's a sample only, not a real PR.

## Template

| Title | *\[\<JIRA-000\>\] Short, imperative summary of the change* |
| --- | --- |
| Type | *Feature / Bug fix / Refactor / Chore / Docs* |

### Summary

*What does this PR do, and why? A reviewer should understand the intent without reading the diff.*

### Changes

- *Key change 1*
- *Key change 2*

### Breaking changes

*None — or describe what breaks and how consumers should adapt. Should match any ! or BREAKING CHANGE footers in the commits included in this PR — if they disagree, one of them is wrong.*

---

## Example EXAMPLE — NOT A REAL PR

Everything below is sample content to illustrate the template. Replace it entirely when creating a real PR.

| Title | \[PROJ-495\] Add category filter to products page |
| --- | --- |
| Type | Feature |

### Summary

Users struggled to find products in long unfiltered lists. This PR adds a category filter dropdown above the product grid so users can narrow results without a full page reload.

### Changes

- Added `CategoryFilter` component and wired it to the product grid query
- Selected category is synced to the URL query string
- Added loading state while filtered results are fetched

### Breaking changes

None.
