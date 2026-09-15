---
name: documentation
description: Use when creating or updating a documentation page for this project — e.g. "document this", "write docs for...". Fills in templates/documentation.template.md.
---

# Documentation

1. Read `templates/documentation.template.md`.
2. Check whether a doc on this topic already exists in the repo first — if it does, update it in place rather than creating a duplicate.
3. Fill the header table (Title, Type, Status, Last reviewed = today's date) and Purpose / Scope / Content from what's actually being documented.
4. Related tickets is append-only — add the current ticket if there is one; don't remove existing entries when updating an existing doc.
5. Output the filled doc as markdown; save it into the repo once the user confirms where it should live.
