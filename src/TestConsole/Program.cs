﻿using SharpMarkdown;
using SharpMarkdown.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsole {
    public class Program {
        public static void Main(string[] args) {
            Regex k = new Regex(@"^\*\*.+\*\*");
            var kk = k.IsMatch("哈哈哈哈**XPY**");
            var p = Paragraph.Parse("哈哈哈哈**XPY**");
        }
    }
}
