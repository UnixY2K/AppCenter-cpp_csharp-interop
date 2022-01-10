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

## Loading c++ code from C#

after the dll is compiled, you can use it from the C# project.

- Copy the `c++ dll(and all the required files)` to the `C# project` binary folder.
    > This step can be automated with a build script, as it is only needed when you deploy the release of the application.
- Add the following import to the `C# code`.
  ```csharp
  // DllImport
  using System.Runtime.InteropServices;
  ```
- then add the function of the `C++ DLL` in the `C# code` like this:
  ```csharp
  // define the DLL entry point from c++ dll (void dllEntry() from myApp.dll)
    [DllImport("myApp.dll", EntryPoint = "dllEntry")]
    public static extern void dllEntry();
  ```

## Multiplatform Support

the SDK (C#) is only available for Windows, IOS and Android.

## AppCenter Callbacks

you may need to call the SDK from the C++ code, for example when you want to send a crash report or log an event.

- in the `C++ project` setup a function that saves the C# callback function pointer into c++ so it can be called from the c++ code , you can check it on `AppCenter.cpp`.
  ```c++
  // the C function pointers
  void (*trackEventCallback)(const char *str) = nullptr;
  void (*trackEventExtraCallback)(const char *str, const char *data) = nullptr;
  // this functions will be called from another method in the c++ code
  void setTrackEventCallback(void (*callback)(const char *str)) {
      trackEventCallback = callback;
  }
  void setTrackEventCallback(void (*callback)(const char *str,
                                              const char *data)) {
      trackEventExtraCallback = callback;
  }
  ```
- once you have this functions you can call them directly or wrap them like this:
  ```c++
  void trackEvent(std::string event) {
	    if (trackEventCallback) {
	        trackEventCallback(event.c_str());
	    } else {
	        std::cerr << "Interop::AppCenter::trackEventCallback is nullptr\n";
	    }
  }

  void trackEvent(std::string event, Properties properties) {
      if (trackEventExtraCallback) {
          trackEventExtraCallback(event.c_str(), toJson(properties).c_str());
      } else {
          std::cerr << "Interop::AppCenter::trackEventExtraCallback is nullptr\n";
      }
  }
  ```
- on `AppCenter.hpp` you can define them.
- finally define `setupAppCenterCallbacks` in the `C++ project` like this:
  ```c++
  extern "C"{
  // this will setup the callbacks needed by the C++ code
  // in order to call the AppCenter.trackEvent() function
  myAppAPI void setupAppCenterCallbacks(
    void (*trackEventCallback)(const char *str),
    void (*trackEventExtraCallback)(const char *str, const char *data)) {
	    Interop::AppCenter::setTrackEventCallback(trackEventCallback);
	    Interop::AppCenter::setTrackEventCallback(trackEventExtraCallback);
  }
  }
  ```
- on the `C# project` setup a class like the one on `AppCenter.cs` of this project.