# Repository Instructions For Gemini

## Goal
Make small, safe, reviewable changes that fit the existing project.

## General Rules
- Inspect the repository before proposing or applying changes.
- Keep diffs focused on the user's request.
- Do not refactor unrelated files.
- Preserve existing project conventions.
- Treat secrets, tokens, and credentials as sensitive. Never print them in full.
- Do not fabricate command, tool, Docker, Kubernetes, Azure, Gemini, or CI output.

## Available Agent Modes
Use the matching mode when the task fits its domain:

- `csharp-developer`: C# and .NET application code, console apps, MSAL or Microsoft Identity integration, NuGet/project file updates, tests, refactoring, debugging, nullable safety, and async code.
- `sre-engineer`: Docker, Kubernetes, Minikube, GitHub Actions, Makefiles, run scripts, Azure, deployment automation, reliability, and operational readiness.
- `ai-engineer`: Azure AI Services (formerly Cognitive Services) such as Computer Vision, OCR, Face, Custom Vision, Document Intelligence, Language, Speech, Translator, Content Safety, and Azure OpenAI, plus machine learning tooling such as Azure Machine Learning, Azure AI Foundry, ML.NET, ONNX Runtime, and MLflow.

## Agent Mode Instructions
@./.gemini/agents/csharp-developer.md
@./.gemini/agents/sre-engineer.md
@./.gemini/agents/ai-engineer.md

## Gemini CLI Skills
This repository also exposes matching workspace skills through `.agents/skills`, which Gemini CLI can discover:

- `.agents/skills/csharp-developer/SKILL.md`
- `.agents/skills/sre-engineer/SKILL.md`
- `.agents/skills/ai-engineer/SKILL.md`

Use `/skills list` to confirm discovery and `/skills reload` after editing skill files.

## Validation
- Prefer repository-specific build and test commands when they exist.
- If validation cannot run because local tooling is unavailable, say exactly what was not run and why.

## Final Response
Include:
- Summary
- Files changed
- Commands run
- Verification result
