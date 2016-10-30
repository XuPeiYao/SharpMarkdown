﻿using SharpMarkdown;
using SharpMarkdown.Area;
using SharpMarkdown.Inline;
using SharpMarkdown.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsole {
    public class Program {
        public static void Main(string[] args) {
            var text = System.IO.File.ReadAllText("test.md");
            var p = Content.Parse(text);
            var c = Section.FromContent(p);
            var all = c.GetAllSubsections();
            string text2 = p.OuterMarkdown;
            string text3 = c.OuterMarkdown;
        }
    }
}
