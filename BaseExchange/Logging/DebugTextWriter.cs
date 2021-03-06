﻿using System.Diagnostics;
using System.IO;
using System.Text;

namespace BaseExchange.Logging
{
    public class DebugTextWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.ASCII;

        public override void WriteLine(string value)
        {
            Debug.WriteLine(value);
        }
    }
}
