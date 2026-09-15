---
name: test-report
description: Use when summarizing a test run or writing a test report for this project — e.g. "summarize this test run", "write a test report". Fills in templates/test-report.template.md.
---

# Test report

1. Read `templates/test-report.template.md`.
2. Fill the header table (Date, Trigger, Branch/commit, Result, Run link) and the Summary table from the actual test run output you were given — never fabricate pass/fail counts you haven't seen.
3. List every failure in the Failures table with expected vs. actual behaviour; leave "Notes" blank rather than guessing at a suspected cause you can't support.
4. Check a Follow-up box only for something that's actually been done.
5. Output the filled report as markdown in the chat, or save it to a file if the user tells you where.
