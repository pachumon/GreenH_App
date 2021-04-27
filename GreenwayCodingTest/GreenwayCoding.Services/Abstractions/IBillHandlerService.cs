using GreenwayCoding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenwayCoding.Services.Abstractions
{
    public interface IBillHandlerService
    {
        BillingInfo GenerateBillForCart(List<string> cart);
    }
}
