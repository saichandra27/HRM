using System;

namespace HRM.Common
{
    public interface ILog
    {
        void WriteError(Exception e);
        void WriteError(string message);
        void WriteInfo(Exception e);
        void WriteInfo(string message);
        void WriteWarning(Exception e);
        void WriteWarning(string message);
    }
}
