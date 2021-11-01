using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum TimeSeries 
    {
        DAILY,
        DAILY_ADJUSTED,
        WEEKLY,
        WEEKLY_ADJUSTED,
        MONTHLY,
        MONTHLY_ADJUSTED
    }

    public static class SeriesNameExtensions
    {
        public static string SeriesStringName(this TimeSeries series)
            => series switch
            {
                TimeSeries.DAILY            => "TIME_SERIES_DAILY",
                TimeSeries.DAILY_ADJUSTED   => "TIME_SERIES_DAILY_ADJUSTED",
                TimeSeries.WEEKLY           => "TIME_SERIES_WEEKLY",
                TimeSeries.WEEKLY_ADJUSTED  => "TIME_SERIES_WEEKLY_ADJUSTED",
                TimeSeries.MONTHLY          => "TIME_SERIES_MONTHLY",
                TimeSeries.MONTHLY_ADJUSTED => "TIME_SERIES_MONTHLY_ADJUSTED",
                _ => ""
            };
    }
}
