using GreenwayCoding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenwayCoding.Services.Abstractions
{
    public interface IProductInventory
    {
        bool checkProducts(List<string> productList);
        double GetProductPrice(string productName);
        CartItemInfo ApplyDiscount(CartItemInfo cartItem, DiscountInfo discountInfo);
        double GetBillAmount(List<CartItemInfo> cartItems);
        DiscountInfo GetItemDiscountInfo(string productName);
    }
}
