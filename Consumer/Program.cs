using PersonSoapService;

Console.WriteLine("Please type personId value to retrive data");

// CHECKPOINT FOR WRONG INPUTS
BEFORE_PROCESS:

var readLine = Console.ReadLine();

var isParsed = int.TryParse(readLine, out int parsedInput);

if (isParsed)
{
    // CREATE CONNECTION (Configs and EP url unnessary, just you can)
    PersonServiceClient personServiceClient = new(PersonServiceClient.EndpointConfiguration.BasicHttpBinding_IPersonService, "https://localhost:7096/Service.asmx");
    // Get Data
    var result = personServiceClient.GetPerson(parsedInput);

    // Using reflection for output's data fields.
    foreach (var property in result.GetType().GetProperties())
    {
        Console.WriteLine($"{property.Name}: {property.GetValue(result)}");
    }
}
else
{
    Console.WriteLine("Operation Failed. Please type INTEGER value");

    goto BEFORE_PROCESS;
}

Console.ReadLine();

