using log4net;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Common
{
    //public class Logger : ILog
    //{
    //    private readonly ILog log = LogManager.GetLogger(typeof(Logger));

    //    public Logger()
    //    {
    //        log4net.Config.XmlConfigurator.Configure();
    //    }

    //    public void WriteError(string message)
    //    {
    //        Log(message, LogCategory.Exception);
    //    }

    //    public void WriteError(Exception e)
    //    {
    //        Log(e.ToString(), LogCategory.Exception);
    //    }

    //    public void WriteInfo(string message)
    //    {
    //        Log(message, LogCategory.Info);
    //    }

    //    public void WriteInfo(Exception e)
    //    {
    //        Log(e.ToString(), LogCategory.Info);
    //    }

    //    public void WriteWarning(string message)
    //    {
    //        Log(message, LogCategory.Warn);
    //    }

    //    public void WriteWarning(Exception e)
    //    {
    //        Log(e.ToString(), LogCategory.Warn);
    //    }

    //    private void Log(string message, LogCategory category)
    //    {
    //        switch (category)
    //        {
    //            case LogCategory.Debug:
    //                log.Debug(message);
    //                break;
    //            case LogCategory.Warn:
    //                log.Warn(message);
    //                break;
    //            case LogCategory.Exception:
    //                log.Error(message);
    //                break;
    //            case LogCategory.Info:
    //                log.Info(message);
    //                break;
    //        }
    //    }
    //}

    //public enum LogCategory
    //{
    //    //
    //    // Summary:
    //    //     Debug category.
    //    Debug = 0,
    //    //
    //    // Summary:
    //    //     Exception category.
    //    Exception = 1,
    //    //
    //    // Summary:
    //    //     Informational category.
    //    Info = 2,
    //    //
    //    // Summary:
    //    //     Warning category.
    //    Warn = 3
    //}
}
