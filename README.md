# ArchiDesignPatterns

ArchiDesignPatterns is a .NET MAUI mobile application demonstrating various software architecture patterns and design patterns.

## Project Details
- **Project Type:** .NET MAUI (Multi-platform App UI)
- **Target Framework:** .NET 10 (Android)
- **Output Type:** APK / AAB
- **Root Namespace:** ArchiDesignPatterns.Mobile
- **App Identifier:** fr.mafyou.codepatterns
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
- Demonstrates SOLID principles:
  - Single Responsibility Principle
  - Open/Closed Principle
  - Liskov Substitution Principle
  - Interface Segregation Principle
  - Dependency Inversion Principle
- Demonstrates classic design patterns:
  - Adapter, Bridge, Chain of Responsibility, Composite, Decorator, Facade, Flyweight, Interpreter, Iterator, Mediator, Memento, Observer, Proxy, Singleton, State, Strategy, Template Method, Visitor
- Includes a quiz page for learning reinforcement
- Integrates with Semantic Kernel for advanced AI capabilities

## Main Dependencies
- [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm) (v8.4.0)
- [CommunityToolkit.Maui](https://www.nuget.org/packages/CommunityToolkit.Maui) (v13.0.0)
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json) (v10.0.0)
- [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http) (v10.0.0)
- [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug) (v10.0.0)
- [Microsoft.Maui.Controls](https://www.nuget.org/packages/Microsoft.Maui.Controls) (v10.0.10)
- [Microsoft.Maui.Essentials](https://www.nuget.org/packages/Microsoft.Maui.Essentials) (v10.0.10)
- [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel) (v1.67.1)

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