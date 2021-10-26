﻿using System;

namespace Stocks.Shared.Models
{
    public class TickerDataPoint
    {

        public DateTime Date { get; set; }

        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public decimal Volume { get; set; }

    }
}
