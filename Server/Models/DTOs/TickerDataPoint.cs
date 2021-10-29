﻿using System;

namespace Stocks.Server.Models.DTO
{
    public class TickerDataPoint
    {
        public string TickerName { get; set; }

        public DateTime Date { get; set; }

        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public decimal Volume { get; set; }
    }
}