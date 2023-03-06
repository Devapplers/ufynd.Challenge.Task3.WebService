
## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 3.0 or later](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* EF Core 3.0 or later

### Installing
Follow these steps to get your development environment set up:
1. Clone the repository
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Next, within the Task3.WebService directory, launch the back end by running:
```csharp
dotnet run
```
5. Launch https://localhost:7013/swagger/index.html in your browser to view the Web UI.

If you have **Visual Studio** after cloning Open solution with your IDE, Task3.WebService should be the start-up project. Directly run this project on Visual Studio with **F5 or Ctrl+F5**. You will see swagger index page of project and you can test the Get HotelRate web api and you.
