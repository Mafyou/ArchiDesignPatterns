# ArchiDesignPatterns

ArchiDesignPatterns is a .NET MAUI mobile application demonstrating various software architecture patterns and design patterns.

## Project Details
- **Project Type:** .NET MAUI (Multi-platform App UI)
- **Target Framework:** .NET 10 (Android)
- **Output Type:** APK / AAB
- **Root Namespace:** ArchiDesignPatterns.Mobile
- **App Identifier:** fr.mafyou.archidesignpatterns
- **Version:** 1.0

## Features
- Showcases multiple software architectures:
  - Clean Architecture
  - DDD (Domain-Driven Design)
  - CQRS
  - Event-Driven Architecture
  - Hexagonal Architecture
  - Layered Architecture
  - Microservices
  - MVC
  - MVVM
  - Onion Architecture
- Demonstrates classic design patterns:
  - Adapter, Bridge, Chain of Responsibility, Composite, Decorator, Facade, Flyweight, Interpreter, Iterator, Mediator, Memento, Observer, Proxy, Singleton, State, Strategy, Template Method, Visitor
- Includes a quiz page for learning reinforcement
- Integrates with Semantic Kernel for advanced AI capabilities

## Main Dependencies
- [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm)
- [CommunityToolkit.Maui](https://www.nuget.org/packages/CommunityToolkit.Maui)
- [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)
- [Microsoft.Maui.Essentials](https://www.nuget.org/packages/Microsoft.Maui.Essentials)
- [Microsoft.Maui.Controls](https://www.nuget.org/packages/Microsoft.Maui.Controls)
- [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug)
- [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel)

## Getting Started
1. Ensure you have the latest .NET 10 SDK and Android development tools installed.
2. Clone the repository:
   ```sh
   git clone https://github.com/Mafyou/ArchiDesignPatterns.git
   ```
3. Open the solution in Visual Studio 2026.
4. Set `ArchiDesignPatterns.Mobile` as the startup project.
5. Build and run the app on an Android emulator or device.

**Important:** To make the Quizz work, you must add your OpenAI API key in `src/ArchiDesignPatterns.Mobile/appsettings.json` under the `OpenAI:ApiKey` property.

## License
This project is licensed under the MIT License.