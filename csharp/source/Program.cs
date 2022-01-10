namespace csharp;

using interop;

// Microsoft AppCenter SDK
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // you can check more about App Center SDK at
        // https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/wpf-winforms
        // do not store the app secret on source code
        // this is only for demo purposes
        System.Console.WriteLine("App Center Powered.");
        // this will track exceptions on crash
        Application.ThreadException += (sender, args) =>
        {
            Crashes.TrackError(args.Exception);
        };
        // this will start the App Center SDK
        AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
        // this will setup the callbacks for C++
        AppCenterCpp.setup();
        // this will initialize the C++ app
        AppCenterCpp.initApp();
    }

}