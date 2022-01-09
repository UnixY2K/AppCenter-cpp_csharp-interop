namespace csharp;

// DllImport
using System.Runtime.InteropServices;

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
        AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
        dllEntry();
    }

    // define the DLL entry point from c++ dll (void dllEntry() from myApp.dll)
    [DllImport("myApp.dll", EntryPoint = "dllEntry")]
    public static extern void dllEntry();
}