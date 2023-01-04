using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Utilities;
using L4U_BOL_MODEL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L4U_DAL_DATA.Services;
using L4U_DAL_DATA.Utilities;
using Microsoft.AspNetCore.Mvc;
using L4U_BAL_SERVICES.Utilities;

namespace L4U_BAL_SERVICES.Logic
{
    public class UsersLogic
    {

        
        public static async Task<ResponseFunction> AddNewUser(User user, string connectString)
        {
            //string result = await UsersService.AddNewUser(user, connectString);
            if (!user.IsValid()) throw new Exception("Propriedades não intanciadas");
            user.Password = Criptography.Encrypt(user.Password);
            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await UsersService.AddNewUser(user, connectString))
                {
                    response.StatusCode = StatusCodes.CREATED;
                    response.Message = SystemMessages.RecordAdded;
                    //response.Data = true;
                }
                else
                {
                    response.StatusCode = StatusCodes.INTERNALSERVERERROR;
                    response.Message = SystemMessages.ErrorMessage;
                }
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.BADREQUEST;
                //response.Message = SystemMessages.USEREXISTS;
                response.Message = e.Message ?? SystemMessages.BadRequestMessage;
                //response.Data = false;
                throw;
            }
            return response;
        }


        public static async Task<ResponseFunction> AuthenticateUser(UserAuth user, string connectString)
        {
            if (string.IsNullOrEmpty(user.Email))
                throw new Exception("Email não fornecido");
            if (string.IsNullOrEmpty(user.Password))
                throw new Exception("Password não fornecida");


            ResponseFunction response = new ResponseFunction();
            try
            {
                User userAuth = await UsersService.Authenticate(user, connectString);

                if (userAuth != null)
                {
                    userAuth.Password = string.Empty;

                    response.StatusCode = StatusCodes.SUCCESS;
                    response.Message = SystemMessages.USEREXISTS;
                    response.Data = userAuth;
                }
                else
                {
                    response.StatusCode = StatusCodes.INTERNALSERVERERROR;
                    response.Message = SystemMessages.ErrorMessage;
                }
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.BADREQUEST;
                //response.Message = SystemMessages.USEREXISTS;
                response.Message = e.Message ?? SystemMessages.BadRequestMessage;
                //response.Data = false;
                throw;
            }
            return response;
        }

        public static async Task<ResponseFunction> UpdateUser(User user, string connectString)
        {
            //string result = await UsersService.AddNewUser(user, connectString);
            if (!user.IsValid()) throw new Exception("Propriedades não intanciadas");

            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await UsersService.UpdateUser(user, connectString))
                {
                    response.StatusCode = StatusCodes.CREATED;
                    response.Message = SystemMessages.RecordAdded;
                    //response.Data = true;
                }
                else
                {
                    response.StatusCode = StatusCodes.INTERNALSERVERERROR;
                    response.Message = SystemMessages.ErrorMessage;
                }
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.BADREQUEST;
                //response.Message = SystemMessages.USEREXISTS;
                response.Message = e.Message ?? SystemMessages.BadRequestMessage;
                //response.Data = false;
                throw;
            }
            return response;
        }





        /// <summary>
        /// This method calls the necessary service to get all productStore and based on the response, builds up the response
        /// </summary>
        /// <param name="appPath">Application path</param>
        /// <returns>List of products</returns>
        public static async Task<ResponseFunction> GetAllUsers(string connectString)
        {
            List<User> pList = await UsersService.GetAllUsers(connectString);
            //string result = await UsersService.AddNewUser(user, connectString);

            return BuildReponseFromList(pList);
        }

        /// <summary>
        /// This is a generic method to build the response object from a response list
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="list">List of generic object</param>
        /// <returns>Response object</returns>
        private static ResponseFunction BuildReponseFromList<T>(List<T> list)
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


        public static async Task<ResponseFunction> DeleteUser(User user, string connectString)
        {
            bool b = await UsersService.DeleteUser(user, connectString);

            if (b)
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = SystemMessages.RecordDeleted,
                    Data = b
                };
            return StandardResponse.Error();
        }
        /*

        /// <summary>
        /// Metodo para Listar todos os utilizadores
        /// </summary>
        public List<User> GetUsers
        {
            get
            {
                return _usersService.GetUsers();
            }
        }

        public void UpdateUser(User user)
        {
            _usersService.UpdateUser(user);
        }



        #region Versão com erros - Stored Procedures

        /*

        /// <summary>
        /// This method adds a new User to the database
        /// </summary>
        /// <param name="User">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        public static async Task<ResponseFunction> AddNewUser(User user, string appPath)
        {
           

            string result = await UsersService.AddNewUser(user, appPath);
                
            if (result.Equals(SystemMessages.CREATED))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.CREATED,
                    Message = SystemMessages.RecordAdded,
                    Data = true
                };
            if (result.Equals(SystemMessages.ALREADYEXISTS))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.BADREQUEST,
                    Message = SystemMessages.USEREXISTS,

                    Data = false
                };
            return StandardResponse.Error();
        }





        /// <summary>
        /// This method deletes a user on the database
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        public static async Task<ResponseFunction> DeleteUser(string uid, string appPath)
        {
            bool b = await UsersService.DeleteUser(uid, appPath);

            if (b)
                return new ResponseFunction()
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = SystemMessages.RecordDeleted,
                    Data = b
                };
            return StandardResponse.Error();
        }

        /// <summary>
        /// This method performs login operation
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        public static async Task<ResponseFunction> LoginUser(UserRequestMin user, string appPath)
        {
            User authUser = await UsersService.LoginUser(user, appPath);

            if (string.IsNullOrEmpty(authUser.UserName))
                return new Response
                {
                    StatusCode = StatusCodes.BADREQUEST,
                    Message = CommonMessages.UserDontExist,
                    Data = null
                };

            if (user.Password.Equals(Criptography.Decrypt(authUser.Password)))  //checks pw
            {
                authUser.Password = "TOP SECRET";
                return new Response
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = "Login com sucesso",
                    Data = authUser
                };
            }
            return new Response
            {
                StatusCode = StatusCodes.NOCONTENT,
                Message = CommonMessages.NoContentMessage,
                Data = null
            };
        }

        
        #endregion
        */


    }
}
