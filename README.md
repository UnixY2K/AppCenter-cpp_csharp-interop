# App Center c++/c# SDK Interop

App Center Interop example for c++/c#(winforms).

## C# first Steps

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
- 
- import AppCenter SDK on program.cs
  ```csharp
  // Microsoft AppCenter SDK
  using Microsoft.AppCenter;
  using Microsoft.AppCenter.Analytics;
  using Microsoft.AppCenter.Crashes;
  ```

- init the SDK on program.cs like the example on this project
  ```csharp
  static void Main()
  {
      // you can check more about App Center SDK at
      // https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/wpf-winforms
      // do not store the app secret on source code
      // this is only for demo purposes
      System.Console.WriteLine("App Center Powered.");
      AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
  }    
  ```


## C++ Steps

Basically, you need to create a new or use an existing `C++ project`
so you can build a dll that will contain your code that get called from the `C# project`.

For demonstration purposes we will use meson/ninja to create a new `C++ project` and clang or msvc to compile it, but you can use your preferred toolchain (for example CMake) to build the dll.

in this example project it will show a dialog box for simplicity.