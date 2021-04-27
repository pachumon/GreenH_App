using GreenwayCoding.Models;
using GreenwayCoding.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace GreenwayCoding.Services
{
    public class ProductInventory : IProductInventory
    {
        Dictionary<string, double> productLookUpCol = new Dictionary<string, double>
        {
            {"Apple",.25 },
            {"Avocado",.1 },
        };

        List<DiscountInfo> DiscountLookUpCol = new List<DiscountInfo>
        {
            new DiscountInfo("Apple",DiscountType.Count,2,1)
        };
        public bool checkProducts(List<string> productList)
        {
            if (productList.Count > 0)
            {
                foreach (var product in productList)
                {
                    if (!productLookUpCol.Any(x => x.Key.ToLower() == product.Trim().ToLower()))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

   

        public double GetProductPrice(string productName)
        {
            if (!productLookUpCol.Any(x => x.Key.ToLower() == productName))
            {
                return productLookUpCol[productName];
            }
            return 0.0;
        }

        public DiscountInfo GetItemDiscountInfo(string productName)
        {
            return DiscountLookUpCol.FirstOrDefault(x=>x.ProductName.Equals(productName,System.StringComparison.CurrentCultureIgnoreCase));
        }

        public CartItemInfo ApplyDiscount(CartItemInfo cartItem,DiscountInfo discountInfo)
        {            
            var billedItems = 0;
            var discountedItemCount = 0;
           if (discountInfo.ProductDiscount==DiscountType.Count)
            {
                discountedItemCount = cartItem.Count / (discountInfo.GroupedVolume+ discountInfo.DiscountedVolume);
                var NonGroupedItem= cartItem.Count % (discountInfo.GroupedVolume + discountInfo.DiscountedVolume);
                billedItems = discountedItemCount * discountInfo.GroupedVolume + NonGroupedItem;
                cartItem.BilledVolume = billedItems;
                cartItem.DiscountedVolume = discountedItemCount;
            }
            //other discounts can be applied here if more then two types implement startegy pattern
            
            return cartItem;
        }

        public double GetBillAmount(List<CartItemInfo> cartItems)
        {
            var totalcost = 0.0;
            foreach (var cartItem in cartItems)
            {

                totalcost += (cartItem.BilledVolume * productLookUpCol[cartItem.ProductName]);
            }
            return totalcost;
        }
    }
}
