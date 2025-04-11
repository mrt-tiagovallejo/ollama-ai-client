# 🧠 Ollama.AI.Client

**A modular AI client for C# apps using Ollama.**

This project showcases a C# example using [`Microsoft.Extensions.AI`](https://learn.microsoft.com/en-us/dotnet/ai/extensions/overview) to integrate with [Ollama](https://ollama.com/), supporting both **image analysis** and **interactive chat** via large language models (LLMs) like `llava:13b`.  

Despite using `llava:13b` by default, the solution is **model-agnostic and configurable** — allowing easy swapping of models and running in different modes without changing the code.

---

## ✨ Features

- 🔌 Seamless Ollama integration via `Microsoft.Extensions.AI`
- 🖼️ Image Analysis AI mode using `llava:13b` for image analysis
- 💬 Interactive terminal-based chat interface
- 🧱 Model and mode fully configurable via `appsettings.json`

---

## 📦 Requirements

- [.NET 8+](https://dotnet.microsoft.com/)
- [Ollama](https://ollama.com/) installed and running locally  
  (_e.g., `ollama run llava:13b`_)

---

## 🛠️ Getting Started

1. Clone the repo
2. Configure `appsettings.json` with the following setting breakdown

| Section             | Key              | Description                                                                 |
|---------------------|------------------|-----------------------------------------------------------------------------|
| `Ai`                | `ModelName`      | The AI model to use (e.g. `llava:13b`, `llama2`, `mistral`, `phi3`, etc.)   |
|                     | `BaseUri`        | URL of your local Ollama server (usually `http://localhost:11434`)          |
| `RunMode`           | *(optional)*     | Default startup mode: `"Chat"` or `"ImageAnalysis"`                         |

3. Run the app (have fun 😎)
