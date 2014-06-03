﻿using System;
using System.Collections.Generic;
using System.Linq;
using MediaBrowser.Model.Extensions;

namespace MediaBrowser.Model.Dlna
{
    public class Filter
    {
        private readonly List<string> _fields;
        private readonly bool _all;

        public Filter()
            : this("*")
        {

        }

        public Filter(string filter)
        {
            _all = StringHelper.EqualsIgnoreCase(filter, "*");

            List<string> list = new List<string>();
            foreach (string s in (filter ?? string.Empty).Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                list.Add(s);
            _fields = list;
        }

        public bool Contains(string field)
        {
            return _all || _fields.Contains(field, StringComparer.OrdinalIgnoreCase);
        }
    }
}