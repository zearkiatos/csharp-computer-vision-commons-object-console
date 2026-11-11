# Gemini Configuration

This folder configures Gemini-related behavior for this repository.

## Files
- `../GEMINI.md`: Root Gemini CLI context file. It imports the agent mode files in this folder.
- `agents/csharp-developer.md`: C# Developer mode for C#/.NET application code, MSAL integration, tests, and project configuration.
- `agents/sre-engineer.md`: SRE Engineer mode for Docker, Kubernetes, GitHub Actions, Azure, and deployment work.
- `agents/ai-engineer.md`: AI Engineer mode for Azure AI Services (Computer Vision, OCR, Language, Speech, Azure OpenAI) and machine learning tooling (Azure Machine Learning, ML.NET, ONNX Runtime, MLflow).
- `config.yaml`: Gemini Code Assist for GitHub repository configuration.
- `styleguide.md`: Gemini Code Assist review style guide.

## Gemini CLI
- Run `/memory show` to inspect loaded context.
- Run `/memory reload` after changing `GEMINI.md` or imported context files.
- Run `/skills list` to confirm the shared workspace skills from `.agents/skills`.
- Run `/skills reload` after changing skill files.

## Notes
- Gemini CLI supports `GEMINI.md` context files and `@file.md` imports.
- Gemini CLI also discovers skills from `.agents/skills`, so the existing workspace skills are shared with Codex.
