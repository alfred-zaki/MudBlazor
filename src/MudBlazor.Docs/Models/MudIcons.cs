﻿
using System.Collections.Generic;

namespace MudBlazor.Docs.Models
{
    public class MudIcons
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public string Category { get; set; }

        public MudIcons(string name, string code, string category)
        {
            Name = name;
            Code = code;
            Category = category;
        }
    }

    public class MudVirtualizedIcons
    {
        public List<MudIcons> RowIcons { get; set; }

        public MudVirtualizedIcons(List<MudIcons> rowicons)
        {
            RowIcons = rowicons;
        }
    }
}
