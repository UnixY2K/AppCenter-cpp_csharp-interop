// the cross platform way of this project
// it will show the console window on windows

// DllImport
using System.Runtime.InteropServices;

// Microsoft AppCenter SDK
// using Microsoft.AppCenter;
// using Microsoft.AppCenter.Analytics;
// using Microsoft.AppCenter.Crashes;


Console.WriteLine("App Center Powered.");
// AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
dllEntry();



// library entry point
[DllImport("myApp", EntryPoint = "dllEntry")]
static extern void dllEntry();