﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Service.Config
{
    public class City : ConfigurationElement
    {
        [ConfigurationProperty("key", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Key
        {
            get => ((string)(base["key"]));
            set => base["key"] = value;
        }

        [ConfigurationProperty("text", DefaultValue = "", IsRequired = true)]
        public string Text
        {
            get => ((string)(base["text"]));
            set => base["text"] = value;
        }
    }
}
