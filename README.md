# **.Net Core 8 SOAP Service Implementation**

## It uses SoapCore v1.1.0.41 and Bogus v35.4.0 for faker.

### References
```
 <ItemGroup>
   <PackageReference Include="Bogus" Version="35.4.0" />
   <PackageReference Include="SoapCore" Version="1.1.0.41" />
 </ItemGroup>
```
### Data Contracts : Models
```
[DataContract]
public class PersonContract
{
    [DataMember] public int Id { get; set; }
    [DataMember] public Guid UUId { get; set; } = Guid.NewGuid();
    [DataMember] public string Name { get; set; } = string.Empty;
    [DataMember] public string Surname { get; set; } = string.Empty;
}
```
### Service Contracts : Interfaces
```
[ServiceContract]
public interface IPersonService
{
    [OperationContract]
    PersonContract GetPerson(int personId);
}
```
### Service Concretes : Implementation Logics
```
public PersonContract GetPerson(int personId)
{
    var data = DataHelper.GeneratePersonData(100);
    return data.FirstOrDefault(x => x.Id == personId);
}
```

### Utilities : Faker data generator implementation.

```
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
```

### **Project Root: https://github.com/unseensenpai/SOAPServiceApiDotnet8**

### All rights reserved. Unseen Company.
