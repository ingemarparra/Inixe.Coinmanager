// <copyright file="ITimeSeries.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

/*
namespace Inixe.CoinManagement.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPriceData
    {
        TimeSpan Interval { get; }

        TimeSpan Tag { get; }

        decimal Max { get; }

        decimal Min { get; }

        decimal Open { get; }

        decimal Close { get; }

        //IList<IPriceData> Childs { get; }
    }

    public class TimeSeriesPartition
    {
        public int ChildsCount { get; set; }

        public TimeSpan Interval { get; set; }
    }

    public class TimeSeries : IPriceData
    {
        private readonly TimeSpan interval;

        private readonly TimeSpan tag;

        private readonly IList<IPriceData> childs;

        private decimal max;
        private decimal min;

        private decimal open;

        private decimal current;
        private decimal close;

        private long volume;
        private DateTime time;

        public TimeSeries(TimeSpan interval, IEnumerator<int> partitions)
        {
            if (partitions == null)
            {
                throw new ArgumentNullException(nameof(partitions));
            }

            if (interval == TimeSpan.Zero)
            {
                throw new ArgumentException("Invalid Interval", nameof(interval));
            }

            if (!partitions.MoveNext())
            {
                throw new ArgumentException("No partitions where set");
            }

            this.interval = interval;

            var childsInterval = ComputeChildsInterval(interval, partitions.Current);
            this.childs = new List<IPriceData>();
            for (int i = 0; i < partitions.Current; i++)
            {
                this.childs.Add(new TimeSeries(childsInterval,))
            }
        }

        public TimeSpan Tag
        {
            get
            {
                return this.tag;
            }
        }

        public TimeSpan Interval
        {
            get
            {
                return this.interval;
            }
        }

        public decimal Max
        {
            get
            {
                return this.max;
            }
        }

        public decimal Min
        {
            get
            {
                return this.min;
            }
        }

        public decimal Open
        {
            get
            {
                return this.open;
            }
        }

        public decimal Close
        {
            get
            {
                return this.close;
            }
        }

        public long Volume
        {
            get
            {
                return this.volume;
            }
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }

        public IList<IPriceData> Childs
        {
            get
            {
                return this.childs;
            }
        }

        private static TimeSpan ComputeChildsInterval(TimeSpan sourceInterval, int partitionCount)
        {
            var ticks = (double)sourceInterval.Ticks;

            var partitionTicks = (long)Math.Floor(ticks / partitionCount);
            return new TimeSpan(partitionTicks);
        }
    }
}
*/