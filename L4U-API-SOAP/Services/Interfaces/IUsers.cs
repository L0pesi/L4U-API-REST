using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using L4U_API_SOAP.SoapModels;


namespace L4U_API_SOAP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsers" in both code and config file together.
    [ServiceContract]

    public interface IUsers
    {

        /// <summary>
        /// Lista todos os utilizadores
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<User> GetAllUsers();



        /// <summary>
        /// Adiciona novo Utilizador
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddNewUtilizador(User User);


    }




}
