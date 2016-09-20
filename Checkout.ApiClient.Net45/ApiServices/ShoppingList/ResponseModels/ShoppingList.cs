using Checkout.ApiServices.ShoppingList.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.ShoppingList.ResponseModels
{
    public class ShoppingList
    {
        public List<ShoppingListItem> Data { get; set; }
    }
}
