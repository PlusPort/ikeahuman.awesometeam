---
name: documentation
description: Use when creating or updating a documentation page for this project — e.g. "document this", "write docs for...". Fills in templates/documentation.template.md and publishes it to Confluence.
---

# Documentation

Docs live in Confluence, in the same space as the templates (`~5bffb891821157160babf0d1`, the "Paul den Hertog" personal space), as child pages under the **Documentation** page (id `3992813572`).

1. Read `templates/documentation.template.md`.
2. Check whether a doc on this topic already exists under the Documentation page first (`getConfluencePageDescendants` on `3992813572`, or `searchConfluenceUsingCql`) — if it does, update that page in place rather than creating a duplicate.
3. Fill the header table (Title, Type, Status, Last reviewed = today's date) and Purpose / Scope / Content from what's actually being documented. Write the resolved content directly — don't echo the template's own guidance text or justify the choices made.
4. Related tickets is append-only — add the current ticket if there is one; don't remove existing entries when updating an existing doc.
5. Show the filled draft in the chat and ask the user to confirm before publishing — never skip this even if an earlier doc this session was already approved.
6. Once confirmed, publish it: `createConfluencePage` with `spaceId: "~5bffb891821157160babf0d1"`, `parentId: "3992813572"`, `contentFormat: "markdown"` for a new doc; `updateConfluencePage` for an existing one.
7. Report back the page URL Confluence returns — that's the doc's source of truth from then on, not the chat draft.
