using DataAccessWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataAccessWeb.Utils
{
    public static class DataComponentFactory 
    {
        public static IDataComponent CreateComponent()
        {
            var className = ConfigurationManager.AppSettings["IDataComponent"];
            var classType = Type.GetType(className);
            IDataComponent component = (IDataComponent)Activator.CreateInstance(classType);
            return component;
        }
    }
}