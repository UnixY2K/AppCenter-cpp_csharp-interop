# App Center c++/c# SDK Interop

App Center Interop example for c++/c#(winforms).

## C# Steps

- Create a new C# project.
   ```sh
   mkdir csharp
   cd csharp
   dotnet new winforms
   ```
- add AppCenter SDK to the project.
   ```sh
   dotnet add package Microsoft.AppCenter --version 4.4.0
   dotnet add package Microsoft.AppCenter.Analytics --version 4.4.0
   dotnet add package Microsoft.AppCenter.Crashes --version 4.4.0
   ```
- init the SDK on program.cs like the example on this project
  ```csharp
  static void Main()
  {
    // do not store the app secret on source code
    // this is only for demo purposes
    AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
  }    
  ```
