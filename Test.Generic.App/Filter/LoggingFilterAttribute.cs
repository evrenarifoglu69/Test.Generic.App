using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Mvc.ActionFilterAttribute;

namespace Test.Generic.App.Filter
{
    public class LoggingFilterAttribute: ActionFilterAttribute
    {
        #region Logging
        /// <summary>
        /// Access to the log4Net logging object
        /// </summary>
        protected static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string StopwatchKey = "DebugLoggingStopWatch";

        #endregion

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (log.IsDebugEnabled)
            {
                var loggingWatch = Stopwatch.StartNew();
                filterContext.HttpContext.Items.Add(StopwatchKey, loggingWatch);

                var message = new StringBuilder();
                message.Append(string.Format("Executing controller {0}, action {1}",
                    filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    filterContext.ActionDescriptor.ActionName));

                log.Debug(message);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (log.IsDebugEnabled)
            {
                if (filterContext.HttpContext.Items[StopwatchKey] != null)
                {
                    var loggingWatch = (Stopwatch)filterContext.HttpContext.Items[StopwatchKey];
                    loggingWatch.Stop();

                    long timeSpent = loggingWatch.ElapsedMilliseconds;

                    var message = new StringBuilder();
                    //message.Append(string.Format("Finished executing controller {0}, action { 1} -time spent { 2}",filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,filterContext.ActionDescriptor.ActionName,timeSpent));

                    message.Append($"Finished executing controller {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}, action { filterContext.ActionDescriptor.ActionName} -time spent { timeSpent}");

                    log.Debug(message);
                    filterContext.HttpContext.Items.Remove(StopwatchKey);
                }
            }
        }
    }
}