﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BaseExchange.Logging
{
    public class Log
    {
        private List<TextWriter> writers;

        public LogVerbosity Level { get; set; } = LogVerbosity.Info;

        public Log()
        {
            writers = new List<TextWriter>();
        }

        public void UpdateWriters(List<TextWriter> textWriters)
        {
            writers = textWriters;
        }

        public void Write(LogVerbosity logType, string message)
        {
            if ((int)logType < (int)Level)
                return;

            var logMessage = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss:fff} | {logType} | {message}";
            foreach (var writer in writers.ToList())
            {
                try
                {
                    writer.WriteLine(logMessage);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Failed to write log to writer {writer.GetType()}: " + e.Message);
                }
            }
        }
    }

    public enum LogVerbosity
    {
        Debug,
        Info,
        Warning,
        Error,
        None
    }
}
