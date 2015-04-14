using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp01.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]
namespace TestApp01.App_Start
{
    public static class PreStartApp
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Start()
        {
            logger.Info("Application PreStart");
        }
    }
}