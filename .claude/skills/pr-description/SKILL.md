---
name: pr-description
description: Use when writing a pull request title or description for this project — e.g. "open a PR", "write the PR description". Fills in templates/pr-description.template.md.
---

# PR description

1. Read `templates/pr-description.template.md`.
2. Title: `[<JIRA-000>] <short, imperative summary>`. Type: Feature / Bug fix / Refactor / Chore / Docs.
3. Summary: what the PR does and why, in reviewer-facing terms — a reviewer should understand intent without reading the diff.
4. Changes: bullet the key changes, derived from the actual commits/diff in this PR — not from what was merely discussed.
5. Breaking changes: `None`, or a description that matches any `!` / `BREAKING CHANGE` footer in the included commits. If they disagree, that's a bug in one of them — fix it before posting, don't paper over it.
6. Use this as the PR body (e.g. for `gh pr create`). Don't open the PR without the user's go-ahead.
