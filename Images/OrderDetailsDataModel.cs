﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Images
{
    public class ChartModel
    {
        public string Model { get; set; }
        public int Amount { get; set; }
    }

    public class ChartModelPic
    {
        public string Model { get; set; }
        public int Amount { get; set; }
    }
    public class OrderDetailsDataModel
    {

        private Entities1 db = new Entities1();

        public List<ChartModel> GetOrderbyModel()
        {
            var chartDataList = new List<ChartModel>();

            var prod = db.Pictures.OrderBy(i => i.Pic_ID).ToList();
            foreach (var item in prod.GroupBy(i => i.Type))
            {
                var chartData = new ChartModel();
                chartData.Model = item.FirstOrDefault().Type;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }
        public List<ChartModelPic> GetOrderbyModelPic()
        {
            var chartDataList = new List<ChartModelPic>();

            var prod = db.Pictures.OrderBy(i => i.Pic_ID).ToList();
            foreach (var item in prod.GroupBy(i => i.Type))
            {
                var chartData = new ChartModelPic();
                chartData.Model = item.FirstOrDefault().Type;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }
    }

}