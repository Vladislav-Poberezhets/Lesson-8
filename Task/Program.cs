using System.Text.RegularExpressions;

var appPath = "D:\\C#\\Lesson8\\Task\\Book.csv";
var phonebook = ReadFile(appPath);
AddPerson(appPath);
phonebook = ReadFile(appPath);
Console.WriteLine("Search person");
var person = SearchPerson(Console.ReadLine(), phonebook);
Console.WriteLine(person);

List<(string FirstName, string SecondName, string PhoneNumber)> ReadFile(string path)
{
    if(!File.Exists(path)) return null;
    var book = new List<(string FirstName, string SecondName, string PhoneNumber)>();
    var lines = File.ReadAllLines(path);
    foreach (var line in lines)
    {
        var split = line.Split(",");
        book.Add((split[0], split[1], split[2]));
    }
    book.Sort();
    return book;

} 

(string,string,string) SearchPerson (
    string input,
    List<(string,string,string)> collection)
{ 
    return collection.FirstOrDefault(person=>
    person.Item1.Contains(input, StringComparison.OrdinalIgnoreCase)||
    person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
    person.Item3.Contains(input, StringComparison.OrdinalIgnoreCase));
}

void AddPerson(string path)
{
    InputValue(out var FirstName, "FirstName");
    InputValue(out var SecondName, "SecondName");
    InputValue(out var PhoneNumber, "PhoneNumber");
    File.AppendAllLines(
        path,
        new[] {$"{FirstName},{SecondName},{PhoneNumber}"});
}
void InputValue(out string result, string fieldName)
{
    Console.WriteLine($"Enter {fieldName}:");
    result = Console.ReadLine();
    Console.WriteLine($"{fieldName} submitted: {result}");
}