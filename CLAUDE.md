# Repository Instructions For Claude

## Goal
Make small, safe, reviewable changes that fit the existing project.

## General Rules
- Inspect the repository before proposing or applying changes.
- Keep diffs focused on the user's request.
- Do not refactor unrelated files.
- Preserve existing project conventions.
- Treat secrets, tokens, and credentials as sensitive. Never print them in full.
- Do not fabricate command, tool, Docker, Kubernetes, Azure, Claude, or CI output.

## Available Agent Modes
Use the matching mode when the task fits its domain:

- `csharp-developer`: C# and .NET application code, console apps, MSAL or Microsoft Identity integration, NuGet/project file updates, tests, refactoring, debugging, nullable safety, and async code.
- `sre-engineer`: Docker, Kubernetes, Minikube, GitHub Actions, Makefiles, run scripts, Azure, deployment automation, reliability, and operational readiness.
- `ai-engineer`: Azure AI Services (formerly Cognitive Services) such as Computer Vision, OCR, Face, Custom Vision, Document Intelligence, Language, Speech, Translator, Content Safety, and Azure OpenAI, plus machine learning tooling such as Azure Machine Learning, Azure AI Foundry, ML.NET, ONNX Runtime, and MLflow.

## Claude Code Subagents
Subagents are defined in `.claude/agents`:

- `.claude/agents/csharp-developer.md`
- `.claude/agents/sre-engineer.md`
- `.claude/agents/ai-engineer.md`

Use `/agents` to confirm they are loaded, or ask Claude to delegate to one by name (for example, "use the sre-engineer agent to add a Dockerfile").

## Claude Code Skills
Matching skills are defined in `.claude/skills`:

- `.claude/skills/csharp-developer/SKILL.md`
- `.claude/skills/sre-engineer/SKILL.md`
- `.claude/skills/ai-engineer/SKILL.md`

Invoke them with `/csharp-developer`, `/sre-engineer`, or `/ai-engineer`, or let Claude load them automatically when the task matches their description.

## Validation
- Prefer repository-specific build and test commands when they exist.
- If validation cannot run because local tooling is unavailable, say exactly what was not run and why.

## Final Response
Include:
- Summary
- Files changed
- Commands run
- Verification result
