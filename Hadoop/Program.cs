﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var hadoop = Microsoft.Hadoop.MapReduce.Hadoop.Connect();
            var result = hadoop.MapReduceJob.ExecuteJob<WordCounterJob>();
            Console.ReadKey();
        }
    }
}
