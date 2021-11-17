using System;

namespace MiddlewareEIT.API.Authorization
{        
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { 
    }
}
