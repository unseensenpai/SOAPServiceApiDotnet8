using Api.DataContracts;
using Api.ServiceContracts;
using Api.Utilites;

namespace Api.ServiceConcretes
{
    public class PersonService : IPersonService
    {
        public PersonContract GetPerson(int personId)
        {
            var data = DataHelper.GeneratePersonData(100);
            return data.FirstOrDefault(x => x.Id == personId) ?? new() { Id = 0, Name = "Said", Surname = "Gülmez" };
        }
    }
}
