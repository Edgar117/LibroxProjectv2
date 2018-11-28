using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.BO
{
    public class Paypal
    {
            public string Business { get; set; }
            public string ItemName { get; set; }
            public string ItemNumber { get; set; }
            public string Amount { get; set; }
            public string NoShipping { get; set; }
            public string Quantity { get; set; }
        
    }
}