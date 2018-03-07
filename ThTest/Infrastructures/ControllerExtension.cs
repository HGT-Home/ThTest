using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public static class ControllerExtension
    {
        //public static string Action<T>(this Controller controller, string actionName) where T: Controller
        //{
        //    try
        //    {
        //        return controller.Action<T>(actionName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static string Action<T>(this Controller controller, string actionName, object values) where T: Controller
        //{
        //    try
        //    {
        //        if (controller != null)
        //        {
        //            string controllerName = typeof(T).Name.Replace("Controller", string.Empty);
        //            return controller.Url.Action(actionName, controllerName, values);
        //        }

        //        return string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
