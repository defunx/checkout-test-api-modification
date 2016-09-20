using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {

        public HttpResponse<ShoppingListItem> AddShoppingListItem(ShoppingListItem requestModel)
        {
            return new ApiHttpClient().PostRequest<ShoppingListItem>(ApiUrls.ShoppingList, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> UpdateShoppingListItem(ShoppingListItem requestModel)
        {
            var updateShoppingListUri = ApiUrls.ShoppingList;
            return new ApiHttpClient().PutRequest<OkResponse>(updateShoppingListUri, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteShoppingListItem(string itemName)
        {
            var deleteShoppingListItemUri = string.Format(ApiUrls.ShoppingListItemDelete, itemName);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteShoppingListItemUri, AppSettings.SecretKey);
        }

        public HttpResponse<ShoppingListItem> GetShoppingListItem(string itemName)
        {
            var getShoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, itemName);
            return new ApiHttpClient().GetRequest<ShoppingListItem>(getShoppingListItemUri, AppSettings.SecretKey);
        }

        public HttpResponse<Checkout.ApiServices.ShoppingList.ResponseModels.ShoppingList> GetShoppingList(ShoppingItemGetList request)
        {
            var getShoppingListUri = ApiUrls.ShoppingList;

            if (request.PageSize.HasValue)
            {
                getShoppingListUri = UrlHelper.AddParameterToUrl(getShoppingListUri, "pageSize", request.PageSize.ToString());
            }

            if (!string.IsNullOrEmpty(request.PageNumber))
            {
                getShoppingListUri = UrlHelper.AddParameterToUrl(getShoppingListUri, "pageNumber", request.PageNumber);
            }

            return new ApiHttpClient().GetRequest<Checkout.ApiServices.ShoppingList.ResponseModels.ShoppingList>(getShoppingListUri, AppSettings.SecretKey);
        }
    }
}
