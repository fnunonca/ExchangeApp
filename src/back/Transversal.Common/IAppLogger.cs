using System;

namespace Transversal.Common
{
    public class LogTranx
    {
        public long TranxIniDate { get; set; }
        public long TranxEndDate { get; set; }
        public long Millis => TranxEndDate - TranxIniDate;
    }

    public interface IAppLogger
    {
        void LogInfo(string message, params object[] args);
        void LogWarn(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogError(Exception exception, string message, params object[] args);
    }
}
