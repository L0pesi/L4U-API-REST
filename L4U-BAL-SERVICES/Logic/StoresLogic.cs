using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;

namespace L4U_BAL_SERVICES.Logic
{
    public class StoresLogic
    {

        /// <summary>
        /// This method calls the necessary service to get all Stores and based on the response, builds up the response
        /// </summary>
        /// <param name="appPath">Application path</param>
        /// <returns>List of lockers</returns>
        public static async Task<ResponseFunction> GetAllStores(string appPath)
        {
            //var lockers = new List<LockersLogic>();
            List<Stores> storeList = await StoreService.GetAll(appPath);
            return BuildResponseFromList(storeList);
        }

        /// <summary>
        /// GENÉRICO
        /// This is a generic method to build the response object from a response list
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="list">List of generic object</param>
        /// <returns>Response object</returns>
        private static ResponseFunction BuildResponseFromList<T>(List<T> list)
        {
            if (list.Equals(null))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.INTERNALSERVERERROR,
                    Message = "Ocorreu um erro inesperado",
                    Data = null
                };
            if (list.Count.Equals(0))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.NOCONTENT,
                    Message = "Não existem registos",
                    Data = null
                };
            return new ResponseFunction
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = $"Foram obtidos {list.Count} resultados",
                Data = list
            };
        }
    }

    /*
    /// <summary>
    /// This method calls the necessary services to retrieve a productStore by uid
    /// </summary>
    /// <param name="uid">Unique id of the productStore</param>
    /// <param name="appPath">Application path</param>
    /// <returns>Response with data</returns>
    public static async Task<Response> GetProdByUid(string uid, string appPath)
    {
        ProductStore prod = await ProductsService.GetByUid(uid, appPath);
        return BuildResponseFromSingleObject(prod);
    }

    /// <summary>
    /// This method adds a new productStore to the database
    /// </summary>
    /// <param name="product">Product store object</param>
    /// /// <param name="appPath">Application path</param>
    /// <returns>Response</returns>
    public static async Task<Response> AddNewProd(ProductStore product, string appPath)
    {
        bool b = await ProductsService.AddProductStore(product, appPath);

        if (b)
            return new Response
            {
                StatusCode = StatusCodes.CREATED,
                Message = CommonMessages.RecordAdded,
                Data = b
            };
        return StandardResponse.Error();
    }

    /// <summary>
    /// This method updates a productstore on the database
    /// </summary>
    /// <param name="product">Product store object</param>
    /// <param name="appPath">Application path</param>
    /// <returns>Response</returns>
    public static async Task<Response> UpdateProd(ProductStore product, string appPath)
    {
        bool b = await ProductsService.UpdateProductStore(product, appPath);

        if (b)
            return new Response
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = CommonMessages.RecordUpdated,
                Data = b
            };
        return StandardResponse.Error();
    }

    /// <summary>
    /// This method deletes a productStore on the database
    /// </summary>
    /// <param name="uid">Product unique id</param>
    /// <param name="appPath">Application path</param>
    /// <returns>Response</returns>
    public static async Task<Response> DeleteProd(string uid, string appPath)
    {
        bool b = await ProductsService.DeleteProductStore(uid, appPath);

        if (b)
            return new Response
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = CommonMessages.RecordDeleted,
                Data = b
            };
        return StandardResponse.Error();
    }
    */
}

