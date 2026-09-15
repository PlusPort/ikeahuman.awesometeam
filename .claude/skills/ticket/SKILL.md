---
name: ticket
description: Use when drafting a ticket, user story, or backlog item for this project — e.g. "write a ticket for...", "create a user story for...". Fills in templates/ticket.template.md so every ticket has the same structure.
---

# Ticket

1. Read `templates/ticket.template.md`.
2. Fill in the **Template** section only — Title, Story, Context / Background, Acceptance Criteria, Repo(s), DoD, Access rights, Links — using details from the conversation. The **Example** section further down is reference only; never copy it into the output.
3. Leave a field as its placeholder text (e.g. *"confirm with dev team"*) if the conversation doesn't answer it — don't invent a JIRA number, repo name, or acceptance criteria that weren't discussed.
4. Ask the user for anything required that's still missing (at minimum: Story, Acceptance Criteria) rather than guessing.
5. Show the filled draft in the chat and ask the user to confirm before creating anything — creating a ticket is visible to the whole team, so never skip this even if an earlier ticket this session was already approved.
6. Once confirmed, create the issue on GitHub with `gh issue create`:
   - Title: the short description from Title (drop the "\<JIRA ticket number\>:" placeholder — GitHub assigns its own issue number).
   - Body: everything from Story through Links, as markdown.
   - Ask which repo it belongs to if it isn't already clear from the conversation (`gh issue create -R <owner>/<repo> ...`).
7. Report back the issue number and URL `gh` returns — that's the ticket's source of truth from then on, not the chat draft.
