namespace DotNetLib;

using System;
using System.Runtime.InteropServices;
public class MyAPI
{
    [UnmanagedCallersOnly(EntryPoint = "doGreet")]
    public static void doGreet(IntPtr name)
    {
        try
        {
            Console.WriteLine("Hello, {0}!", Marshal.PtrToStringAnsi(name));
        }
        catch
        {
            Console.WriteLine("Could not marshal the string");
        }
    }
}
