# Gemini Code Assist Style Guide

## General Review Guidance
- Prefer small, focused, reviewable changes.
- Flag unrelated refactors when they increase risk.
- Do not suggest exposing secrets, tokens, or credentials.
- Prefer existing project conventions over new patterns.
- When command or CI output is not available, do not invent it.

## C# Developer Review Guidance
- For C# changes, review nullable safety, async/await usage, exception handling, input validation, and whether behavior changes have tests when a test project exists.
- For .NET project changes, review target framework compatibility, package versions, unnecessary dependencies, and restore/build impact.
- For MSAL or identity changes, review token handling, scopes, redirect URIs, tenant/client configuration, and avoid hardcoded secrets or identifiers.
- For console app changes, review user-facing messages, missing configuration errors, and safe behavior when authentication or external services are unavailable.

## SRE Engineer Review Guidance
- For Docker changes, review image size, runtime user, exposed ports, dependency installation, cache behavior, and secret handling.
- For Kubernetes changes, review resource names, environment variables, probes, ports, labels, selectors, image references, and namespace assumptions.
- For GitHub Actions changes, review triggers, permissions, secret usage, cache keys, job dependencies, and status badge references.
- For Azure-related changes, review configuration boundaries, environment variables, managed identity or secret handling, and deployment assumptions.

## AI Engineer Review Guidance
- For Azure AI Services changes, review endpoint and key handling, authentication method (prefer Microsoft Entra ID), API version, SDK currency, and region or tier assumptions.
- Review error handling for throttling (HTTP 429), timeouts, invalid input (image size, format, text length), and unavailable AI services.
- Flag hardcoded keys, endpoints, deployment names, or model names; they should come from environment variables.
- For Azure OpenAI or prompt changes, review prompt injection risks, content filtering, token limits, and cost impact.
- For machine learning changes, review data handling, reproducibility (seeds, versions, MLflow tracking), evaluation metrics, and Responsible AI considerations.
- Unit tests should mock AI service clients instead of calling live endpoints.
