﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nalanda.SMS.Common
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
        public bool RenderOnTop { get; set; }
    }
    public enum AlertStyles
    {
        success, info, warning, danger
    }
}
