namespace DotNetLib;

// Microsoft AppCenter SDK
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


// JSON conversion
using Newtonsoft.Json;

using System;
using System.Runtime.InteropServices;
public class AppCenterAPI
{
    [UnmanagedCallersOnly(EntryPoint = "APPCENTER_API_START")]
    public static void Start(IntPtr appSecretstr)
    {
        try
        {
            string appSecret = Marshal.PtrToStringAnsi(appSecretstr) ?? "";
            AppCenter.Start(appSecret,
                   typeof(Analytics), typeof(Crashes));
        }
        catch (System.Exception ex)
        {
            TrackError(ex);
        }
    }



    [UnmanagedCallersOnly(EntryPoint = "APPCENTER_API_TRACK_EVENT")]
    public static void TrackEvent(IntPtr eventNameStr)
    {
        try
        {
            string eventName = Marshal.PtrToStringAnsi(eventNameStr) ?? "";
            Analytics.TrackEvent(eventName);
        }
        catch (System.Exception ex)
        {
            TrackError(ex);
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "APPCENTER_API_TRACK_EVENT_WITH_PROPERTIES")]
    public static void TrackEvent(IntPtr eventNameStr, IntPtr jsonPropertiesStr)
    {
        try
        {
            string eventName = Marshal.PtrToStringAnsi(eventNameStr) ?? "";
            string jsonProperties = Marshal.PtrToStringAnsi(jsonPropertiesStr) ?? "";
            var props = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonProperties);
            Analytics.TrackEvent(eventName, props);
        }
        catch (System.Exception ex)
        {
            TrackError(ex);
        }

    }

    [UnmanagedCallersOnly(EntryPoint = "APPCENTER_API_TRACK_ERROR")]
    public static void TrackError(IntPtr errorMessageStr)
    {
        try
        {
            string errorMessage = Marshal.PtrToStringAnsi(errorMessageStr) ?? "";
            Exception ex = new Exception(errorMessage);
            Crashes.TrackError(ex);
        }
        catch (System.Exception ex)
        {
            TrackError(ex);
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "APPCENTER_API_TRACK_ERROR_WITH_PROPERTIES")]
    public static void TrackError(IntPtr errorMessageStr, IntPtr jsonPropertiesStr)
    {
        try
        {
            string errorMessage = Marshal.PtrToStringAnsi(errorMessageStr) ?? "";
            string jsonProperties = Marshal.PtrToStringAnsi(jsonPropertiesStr) ?? "";
            var props = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonProperties);
            Exception ex = new Exception(errorMessage);
            Crashes.TrackError(ex, props);
        }
        catch (System.Exception ex)
        {
            TrackError(ex);
        }
    }


    // used for internal exception tracking
    public static void TrackError(System.Exception ex)
    {
        try
        {
            Console.WriteLine(ex.Message);
            Crashes.TrackError(ex);
        }
        catch (System.Exception ex2)
        {
            Console.WriteLine(ex2.Message);
        }
    }
}
