# Ticket Template

Standard structure for every ticket created in the exercise project. Claude should follow this template when drafting new tickets.

**How to use this page:** copy the **Template** section below for each new ticket. The **Example** section further down shows it filled in — it's a sample only, not a real ticket.

## Template

### Title

*\<JIRA ticket number\>: \<short, concise description\>*

### Story

*As a \<role\>, I want \<capability\>, so that \<benefit\>.*

> *Not user-facing? Replace with one plain sentence describing what needs to happen and why.*

### Context / Background

*Why this work is needed — link to related docs, tickets, or conversations.*

### Acceptance Criteria

- *Testable condition*
- *Testable condition — including any expected-but-surprising edge-case behavior, stated directly as a criterion*

### Repo(s)

*Which repo(s) this touches — may be more than one. Leave blank if not known yet; fill in once decided.*

### DoD

* [ ] E2E
* [ ] Documentation revalidated/updated

### Access rights *(if applicable)*

*Which role(s) can access this feature — e.g. regular user, manager, admin only.*

### Links

*Related tickets, design files, PRs*

---

## Example EXAMPLE — NOT A REAL TICKET

Everything below is sample content to illustrate the template. Replace it entirely when creating a real ticket.

### Title

PROJ-510: Show friend-users in user overview and details

### Story

As a portal administrator, I want the user overview and user details to also show the friend-users linked to my portal via a training enrollment, so that I have a complete picture of everyone active within my portal, not just the users created directly in it.

### Context / Background

Currently `GET /api/v1/users` and `GET /api/v1/users/details` only return users created directly in the portal. Friend-users — users from another (consuming) organization who end up in the portal via training enrollment — are missing entirely, giving administrators an incomplete view of their user base.

### Acceptance Criteria

- Friend-users appear in both the user overview and the user details
- The friend-user data shown is the data specifically shared for this portal, not the original data from their own portal
- A friend-user always has exactly one employment record in the detail view
- The active status of a friend-user is always shown, both at user level and within that employment record
- It's recognizable per user whether it's a friend-user or an own user
- A filter in both endpoints controls whether friend-users are included in the result
- Existing filters (e.g. search by code) and pagination keep working correctly, including correct total count
- The department filter returns no result for friend-users, since they normally have no department/employment within this portal — this is expected, not a bug

### Repo(s)

portal-api (backend), portal-web (admin UI) — confirm with dev team during refinement

### Access rights *(if applicable)*

Portal administrators only — regular users and managers cannot view the user overview or user details endpoints.

### Links

*e.g. related design doc, previous discussion thread*
