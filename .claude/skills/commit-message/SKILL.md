---
name: commit-message
description: Use when writing a git commit message for this project. Fills in templates/commit-message.template.md format so commits stay consistent and greppable.
---

# Commit message

1. Read `templates/commit-message.template.md`.
2. Build the header as `[<JIRA-000>] <type>[!]: <subject>` — ask for the JIRA ticket ref if it isn't known; pick `type` (feat / fix / build / chore / ci / docs / refactor / test / style / perf) from what the actual diff does, not what the user says it does.
3. Body: explain what changed and why, based on the real diff — not "how" (the diff shows that), not invented rationale. Wrap at ~72 characters. One logical change per commit.
4. Footer: always include `Co-authored-by: Claude Code <noreply@anthropic.com>` when Claude drafted or assisted with the commit. Add `BREAKING CHANGE: <description>` if the header used `!`.
5. Avoid the patterns the template calls out: `fix bug`, `wip`, `update stuff` — no ticket ref, no reason.
6. Use this message directly for `git commit`.
