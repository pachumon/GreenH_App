using System;
using System.Collections.Generic;
using System.Text;

namespace GreenwayCoding.Models
{
    public class DiscountInfo
    {
        public DiscountInfo()
        {

        }
        public DiscountInfo(string name,DiscountType discount,int volume,int discountvolume)
        {
            ProductName = name;
            ProductDiscount = discount;
            GroupedVolume = volume;
            DiscountedVolume = discountvolume;
        }
        public string ProductName { get; set; }
        public DiscountType ProductDiscount { get; set; }
        public int GroupedVolume { get; set; }
        public int DiscountedVolume { get; set; }
    }

    public enum DiscountType
    {
        Count,
        Weight
    }
}
