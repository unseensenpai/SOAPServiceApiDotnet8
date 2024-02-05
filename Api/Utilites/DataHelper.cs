using Api.DataContracts;
using Bogus;

namespace Api.Utilites
{
    public static class DataHelper
    {
        public static Faker GetFakerInstance(string langIso2)
        {
            Faker faker = new(langIso2);
            return faker;
        }

        public static IList<PersonContract> GeneratePersonData(int count)
        {
            var faker = GetFakerInstance("tr");
            List<PersonContract> personContracts = [];
            for (int i = 0; i < count; i++)
            {
                personContracts.Add(new()
                {
                    Id = faker.IndexFaker + i,
                    Name = faker.Person.FirstName,
                    Surname = faker.Person.LastName
                });
            }

            return personContracts;
        }
    }
}
