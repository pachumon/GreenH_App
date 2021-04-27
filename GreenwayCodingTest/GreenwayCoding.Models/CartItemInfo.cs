using System;
using System.Collections.Generic;
using System.Text;

namespace GreenwayCoding.Models
{
    public class CartItemInfo
    {
        public CartItemInfo()
        {

        }

        public CartItemInfo(string prodName,int count)
        {
            ProductName = prodName;
            Count = count;
        }
        public string ProductName { get; set; }
        public int  Count { get; set; }
        public int BilledVolume { get; set; }
        public int DiscountedVolume { get; set; }
    }
}
