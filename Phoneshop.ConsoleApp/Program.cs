using Phoneshop.Domain.Models;



Phoneshop.Business.PhoneService phoneservice = new();
List<Phone> list = phoneservice.GetAllPhones();
while (true)
{
    phoneservice.DisplayPhones();


    ConsoleKeyInfo input = Console.ReadKey();
    string inputValue = input.KeyChar.ToString();
    Console.Clear();
    int number;
    if (int.TryParse(inputValue, out number))
    {
        Console.WriteLine(number);
        Phone chosen = phoneservice.GetPhoneById(number);
        if (number == 6)
        {
            break;
        }
        Console.WriteLine($"{chosen.Brand}\n{chosen.Type}\n prijs ={chosen.Price}\n{chosen.Description}");
    }
    else
    {
        Console.WriteLine("wrong number");

    }


    //de switch statement that handels the choice of the user and prints the respons

    //the class defining the "phone" object
    Console.ReadLine();
}