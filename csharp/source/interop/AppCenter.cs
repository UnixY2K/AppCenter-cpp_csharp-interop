namespace csharp.interop;

// DllImport
using System.Runtime.InteropServices;

// Microsoft AppCenter SDK
using Microsoft.AppCenter.Analytics;

// JSON conversion
using Newtonsoft.Json;

static class AppCenterCpp
{

    // setup the required data and callbacks for C++
    // it is require that the AppCenter SDK is initialized before calling this function
    public static void setup()
    {
        setupAppCenterCallbacks(trackEvent, trackEventFunc);
    }
    // initialize the C++ dll entry point
    // it is required that the setup is called before calling this function
    public static void initApp()
    {
        dllEntry();
    }

    public static string getAppSecret()
    {
        var result = getAppCenterAppSecret();
        var strResult = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(result);
        return strResult ?? "";
    }

    [DllImport("myApp")]
    private static extern IntPtr getAppCenterAppSecret();

    // the C++ dll entry point
    [DllImport("myApp", EntryPoint = "dllEntry")]
    private static extern void dllEntry();
    [DllImport("myApp")]
    private static extern void setupAppCenterCallbacks(TrackEventDelegate normal, TrackEventExtraDelegate extra);

    private static void trackEventFunc(string eventName)
    {
        Analytics.TrackEvent(eventName);
    }
    private static void trackEventFunc(string eventName, string properties)
    {
        // convert the properties string(json) to a dictionary
        var props = JsonConvert.DeserializeObject<Dictionary<string, string>>(properties);
        Analytics.TrackEvent(eventName, props);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void TrackEventDelegate(string eventName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void TrackEventExtraDelegate(string eventName, string eventProperties);
    private static TrackEventDelegate trackEvent = trackEventFunc;
    private static TrackEventExtraDelegate trackEventExtra = trackEventFunc;
}