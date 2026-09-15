---
name: frontend-design
description: Use whenever building or updating a frontend page or component in this project — e.g. "add a page", "build a form", "create a UI for...". Keeps every screen visually consistent by reusing shared design tokens and component styles instead of one-off inline styles.
---

# Frontend design

A generic, eye-pleasing default so every screen in this app looks like
part of the same product, without needing a design file for every
ticket. Framework-agnostic principles, backed by two real files so
they're actually applied, not just read:

- `frontend/src/index.css` — design tokens (color, type, spacing, radius) as CSS custom properties, light + dark mode
- `frontend/src/styles/components.css` — shared primitives built from those tokens: buttons, form fields, alerts, lists, page layout

## Before writing any markup

1. Read both files above. Reuse an existing token or class before adding a new one.
2. If a page needs a primitive that doesn't exist yet (e.g. a new component shape), add it to `components.css` using existing tokens — don't hardcode a one-off color, spacing value, or border-radius inline. A missing primitive is a signal to extend the shared file, not to bypass it.
3. Never fork the palette. One accent color (`--accent`), neutral grays for everything else, `--danger` only for errors. If a new page seems to need a new color, that's almost always a sign to reuse an existing semantic token instead.

## Principles

- **Spacing scale.** Use the `--space-*` tokens (4/8/12/16/24/32px) for all margin/padding/gap. No arbitrary pixel values.
- **Type scale.** Reuse the existing heading (`h1`/`h2`) and body styles from `index.css`. Add a new size only if the scale genuinely doesn't cover the case.
- **One primitive per concern.** Buttons use `.btn` (+ `.btn-primary` / `.btn-secondary`), form fields use `.field`, errors use `.alert` / `role="alert"`. Reuse these across every page rather than styling elements ad hoc per component.
- **States, always.** Every interactive element needs hover, `:focus-visible`, and disabled styling — not just the default state. `components.css` already handles this for the shared primitives; anything new must too.
- **Accessible by default.** Every input has a associated `<label htmlFor>`. Focus rings stay visible (`:focus-visible`, never `outline: none` without a replacement). Color contrast holds in both light and dark mode — check against `--text`/`--bg`, don't eyeball it.
- **Compute contrast, don't pick a shade by name.** Picking a color by how it sounds ("teal-500 seems about right") is exactly how this goes wrong — a shade can look fine and still fail. Before setting `--accent` (or any color a `<button>`/text sits on), compute the WCAG relative-luminance contrast ratio between the two actual hex values: normal text/button labels need ≥4.5:1 against their background; borders and focus rings need ≥3:1 against the page background. If choosing off a Tailwind-style numeric scale, the 700/800 end is usually what clears 4.5:1 for white text — the 400/500 end usually doesn't. Verify both the light and dark values, since they're independent checks.
- **Dark mode is not optional.** Never hardcode a hex color in a component. Everything goes through a token so it flips correctly under `prefers-color-scheme: dark`.
- **Responsive by default.** Relative units (rem/%/ch), a max-width content container (`.page`), no fixed pixel widths that break on narrow viewports.
- **Semantic HTML first.** `<button>` for actions, `<select>`/`<input>` for form controls, real `<label>`s, `<ul>/<li>` for lists — styling should never require reaching for a `<div onClick>`.

## When to extend vs. reuse

Extend `components.css` when: a genuinely new UI shape is needed (e.g. a card grid, a modal) and no existing primitive fits.

Just reuse what's there when: the need is a button, a labeled input/select, an inline error, or a simple list — these are already covered.
