﻿
namespace CoreLibrary.Logger
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, string message);
    }
}
