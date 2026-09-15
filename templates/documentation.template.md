# Documentation Template

Standard structure for every documentation page created in the exercise project. Claude should follow this template when drafting docs.

**How to use this page:** copy the **Template** section below for each new doc. The **Example** section further down shows it filled in — it's a sample only, not a real doc.

## Template

| Title | *Short, descriptive name of what this documents* |
| --- | --- |
| Type | *Architecture / How-to / Test cases / Reference* |
| Status | *Up to date/ Outdated / Deprecated* |
| Last reviewed | *YYYY-MM-DD* |

### Purpose

*Why this doc exists and what question it answers.*

### Scope

*What is and isn't covered here.*

### Content

*The main body — overview, steps, diagrams, or reference details as needed.*

### Related tickets

*Append-only list — every ticket that touches the part of the application this doc describes gets added here.*

- *\<JIRA-000\> — what it changed*

### Related Links

*Repo, other docs, design files*

---

## Example EXAMPLE — NOT A REAL DOC

Everything below is sample content to illustrate the template. Replace it entirely when creating a real doc.

| Title | Running the app locally |
| --- | --- |
| Type | How-to |
| Status | Up do date |
| Last reviewed | 2026-09-01 |

### Purpose

Explains how to get the frontend and backend running on a local machine so a new contributor can start developing without asking around.

### Scope

Covers local setup and running the app. Does not cover deployment or CI configuration — see the deployment runbook for that.

### Content

1. Clone the repo and install dependencies with `npm install`
2. Copy `.env.example` to `.env` and fill in the local API keys
3. Start the backend with `npm run dev:api`
4. Start the frontend with `npm run dev:web`
5. Open `http://localhost:3000` — you should see the app home page

### Related tickets

- PROJ-495 — added the category filter step to local setup verification

### Related Links

<https://github.com/example-org/example-repo>
