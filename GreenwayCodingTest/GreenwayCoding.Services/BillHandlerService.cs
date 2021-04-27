using GreenwayCoding.Models;
using GreenwayCoding.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenwayCoding.Services
{
    public class BillHandlerService : IBillHandlerService
    {
        private readonly IProductInventory _productInventory;
        public BillHandlerService(IProductInventory productInventory)
        {
            _productInventory = productInventory;
        }
        public BillingInfo GenerateBillForCart(List<string> cartItems)
        {
            var billInfo = new BillingInfo();
            var billAmount = 0.0;
            if (cartItems.Any())
            {
                if (_productInventory.checkProducts(cartItems))
                {
                    var groupedCartItems = cartItems.
                        GroupBy(x => x).
                        Select(x => new CartItemInfo(x.Key, x.Count()));

                    var discountedCartItem = new List<CartItemInfo>();
                    foreach (var item in groupedCartItems)
                    {
                        var discountInfo = _productInventory.GetItemDiscountInfo(item.ProductName);
                        if (discountInfo!=null)
                        {
                            discountedCartItem.Add(_productInventory.ApplyDiscount(item, discountInfo));
                        }
                        else
                        {
                            item.BilledVolume = item.Count;
                            item.DiscountedVolume = 0;
                            discountedCartItem.Add(item);
                        }
                    }
                    var billedamount = _productInventory.GetBillAmount(discountedCartItem.ToList());
                    billInfo = new BillingInfo { BillTotal = billedamount };
                }
                else
                {
                    billInfo = new BillingInfo { HasErrors = true, Errors = new List<string> { "Your cart has invalid products" } };
                }
            }
            return billInfo;
        }
    }
}
