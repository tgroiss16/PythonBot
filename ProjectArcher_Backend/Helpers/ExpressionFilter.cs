﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Helpers {
    public class ExpressionFilter {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public Comparison Comparison { get; set; }
    }
}
