﻿using SharpMarkdown.Area;
using SharpMarkdown.Attributes;
using SharpMarkdown.Inline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpMarkdown {
    [Match(Regex = ".+")]
    public class Content : ContentBase{
        public List<ContentBase> Children { get; set; } = new List<ContentBase>();

        internal bool IsSingleLine {
            get {
                return Children.All(x => {
                    var NS = x.GetType().Namespace.Split('.').Last();
                    return NS != nameof(Area) && NS != nameof(Line);
                });
            }
        }

        public override string OuterMarkdown {
            get {
                return ToMarkdown(Children, IsSingleLine);
            }
            set {
                Children = ContentBase.Parse(value.Trim()).Children;
            }
        }
        public override string OuterText {
            get {
                return ToText(Children, IsSingleLine);
            }
        }

        /// <summary>
        /// 轉換為Section
        /// </summary>
        /// <returns>Section</returns>
        public Section ToSection() {
            return Section.FromContent(this);
        }
        public static Content Parse(string text, out int length) {
            var lines = text.Split('\n');
            var temp = lines.FirstOrDefault() ?? "";
            length = temp.Length + 1;
            Content result = new Content();
            result.Children = ContentBase.Parse(temp,true).Children;
            return result;
        }
    }
}
