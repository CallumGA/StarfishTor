using System;
namespace Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServiceAttribute : Attribute
    {
        //This is being used as a custom marker for Scrutor dependency injection
        //library to find and automatically prepare and add services for dependency injection
    }
}
