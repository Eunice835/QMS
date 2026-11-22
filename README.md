# QMS: Queue Management System

A Windows desktop queue management system (an older school project) for managing queues and registering people, built with C# and Windows Forms.

## Tech stack

- C# on .NET 8 (`net8.0-windows`)
- Windows Forms
- [Bunifu UI WinForms](https://bunifuframework.com/) and Bunifu Charts for the interface (NuGet packages)

## Repository contents

| Path | What it is |
|------|------------|
| `Register.sln` | Visual Studio solution |
| `Register/` | The main Windows Forms application |
| `dlls/` | Supporting libraries |
| `emonet-quantize.ipynb` | Jupyter notebook for EmoNet model quantization |

## Getting started

Requirements: Windows, Visual Studio 2022 with the ".NET desktop development" workload, and the .NET 8 SDK.

1. Clone the repository.
2. Open `Register.sln` in Visual Studio.
3. Restore NuGet packages (Visual Studio does this automatically on build).
4. Set `Register` as the startup project and press **F5**.

From a terminal:

~~~bash
dotnet build Register.sln
dotnet run --project Register
~~~
