﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseExchange.TestImplementations
{
    public class TestObject
    {
        [JsonProperty("other")]
        public string StringData { get; set; }
        public int IntData { get; set; }
        public decimal DecimalData { get; set; }
    }
}
