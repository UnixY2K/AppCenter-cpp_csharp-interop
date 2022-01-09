namespace csharp;

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
        // do not store the app secret on source code
        // this is only for demo purposes
        AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
    }    
}