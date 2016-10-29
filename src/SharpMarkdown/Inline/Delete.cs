﻿using SharpMarkdown.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpMarkdown.Inline {
    [Match(Regex = @"^~~.+~~")]
    public class Delete : Content {
        public override string OuterMarkdown {
            get {
                return "~~" + string.Join("", Children.Select(x => x.OuterMarkdown))
                    + "~~";
            }
            set {
                Children = ContentBase.AreaParse(value.Trim());
            }
        }


        public static Delete Parse(string text, out int length) {
            var attrs = MatchAttribute.GetMatchAttributes<Delete>()
                .Select(x => new {
                    match = x.GetRegex().IsMatch(text),
                    attr = x
                });

            if (!attrs.Any(x => x.match)) throw new FormatException();
            var match = attrs.Where(x => x.match).FirstOrDefault().attr.GetRegex()
                .Match(text);

            length = match.Index + match.Length;
            text = match.Value.Substring(2, match.Value.Length - 4);
            return new Delete() { Children = ContentBase.AreaParse(text) };
        }
    }
}
