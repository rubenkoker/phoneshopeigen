using Phoneshop.Domain.Models;



Phoneshop.Business.PhoneService phoneservice = new();
List<Phone> list = phoneservice.GetAllPhones();
foreach (var item in list)
{
    Console.WriteLine($"{item.Id}{item.Brand}{item.Type}");
}
Console.WriteLine("type productnummer\n");
// initialisation of the phone object



// initialisation of the phone object
Console.WriteLine("\n");


ConsoleKeyInfo input = Console.ReadKey();
string inputValue = input.KeyChar.ToString();
Console.Clear();

//de switch statement that handels the choice of the user and prints the respons
switch (inputValue)
{
    case "1":
        Console.WriteLine(list[0]);
        //Console.WriteLine($"{list[0].Brand} \n{list[0].Type}\n {list[0].Description}\n  prijs ={list[0].Price}");
        break;
    case "2":
        Console.WriteLine($"{list[1].Brand}\n{list[1].Type}\n{list[1].Description}\n prijs ={list[1].Price}");
        break;
    case "3":
        Console.WriteLine($"{list[2].Brand}\n{list[2].Type}\n{list[2].Description}\n prijs ={list[2].Price}");
        break;
    case "4":
        Console.WriteLine($"{list[3].Brand}\n{list[3].Type}\n{list[3].Description}\n prijs ={list[3].Price}");
        break;
    case "5":
        Console.WriteLine($"{list[4].Brand}\n{list[4].Type}\n{list[4].Description}\n prijs ={list[4].Price}");
        break;
    default:
        Console.WriteLine("geen geldige knop");
        break;
}

//the class defining the "phone" object
