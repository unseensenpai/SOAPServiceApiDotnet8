using Api.DataContracts;
using System.ServiceModel;

namespace Api.ServiceContracts
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        PersonContract GetPerson(int personId);
    }
}
