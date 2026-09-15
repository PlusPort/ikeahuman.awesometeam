# Commit Message Template

Standard structure for every commit made in the exercise project. Claude should follow this template when drafting commit messages.

**How to use this page:** follow the **Template** format below for every commit. The **Example** section further down shows it filled in — it's a sample only, not a real commit.

## Template

Format:

```text
[<JIRA-000>] <type>[!]: <subject>

<body>

<footer>
```

| JIRA ticket | *Required, first in the message — e.g. \[PROJ-123\]* |
| --- | --- |
| Type | *feat / fix / build / chore / ci / docs / refactor / test / style / perf* |
| Subject | *Imperative mood, under 50 characters, no trailing period* |
| Breaking change | *Append ! right after the type, e.g. \[PROJ-123\] feat!: change token expiry format* |

### Body

*Explain what changed and why — not how, the diff already shows how. Wrap at ~72 characters. One logical change per commit — split unrelated changes into separate commits.*

### Footer

- `BREAKING CHANGE: <description>` — required if the header used `!`
- `Co-authored-by: Claude Code <noreply@anthropic.com>` — required whenever Claude drafted or assisted with the commit

### Avoid

`fix bug`, `wip`, `update stuff` — no ticket ref, no explanation of why. Not greppable, not reviewable.

---

## Example EXAMPLE — NOT A REAL COMMIT

Everything below is sample content to illustrate the template. Replace it entirely when creating a real commit.

```text
[PROJ-482] fix: stop dropping session on token refresh

The refresh handler cleared the local session before the new
token had been persisted, so a slow response could leave the
user logged out even though the refresh succeeded.

Co-authored-by: Claude Code <noreply@anthropic.com>
```
