using Phoneshop.Domain.Models;



Phoneshop.Business.PhoneService phoneservice = new();
List<Phone> list = phoneservice.GetAllPhones();
while (true)
{
    phoneservice.DisplayPhones();

    string inputchoice = Console.ReadLine();
    if (inputchoice.ToLower() == "s")
    {
        Console.WriteLine("what do you search for?");
        string SearchQuery = Console.ReadLine();
        List<Phone> answer = phoneservice.SearchPhonesByString(SearchQuery);
        int Count = 1;
        foreach (Phone phone in answer)
        {
            Console.WriteLine($"{Count} {phone}");
            Count++;
        }
        Console.WriteLine($"{Count} return");
        Console.WriteLine("type productnummer\n");
        Console.WriteLine("\n");
        ConsoleKeyInfo searchinput = Console.ReadKey();
        int SearchValue = Int32.Parse(searchinput.KeyChar.ToString());
        Console.WriteLine(answer[SearchValue - 1]);
        Console.ReadKey();
        Console.Clear();

    }
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
        if (chosen != null)
        {
            Console.WriteLine($"{chosen.Brand}\n{chosen.Type}\n prijs ={chosen.Price}\n{chosen.Description}");
        }
        Console.WriteLine(chosen);
    }
    else
    {
        Console.WriteLine("wrong number");

    }


    //de switch statement that handels the choice of the user and prints the respons

    //the class defining the "phone" object
    Console.ReadLine();
}