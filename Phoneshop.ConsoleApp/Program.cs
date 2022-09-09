using Phoneshop.Business;
using Phoneshop.Domain.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
PhoneService phoneservice = new();

List<Phone> list = phoneservice.GetAllPhones();

while (true)
{
    DisplayPhones();

    string inputchoice = Console.ReadLine();
    bool choiceMade = true;
    if (inputchoice.ToLower() == "s")
    {
        Console.WriteLine("Wat wil je zoeken?");
        string searchQuery = Console.ReadLine();
        List<Phone> answer = phoneservice.Search(searchQuery);

        while (true)
        {
            int count = 1;
            Console.Clear();

            foreach (Phone phone in answer)
            {
                Console.WriteLine($"{count} {phone}");
                count++;
            }
            Console.WriteLine($"{count} return");
            Console.WriteLine("type productnummer\n");
            Console.WriteLine("\n");

            ConsoleKeyInfo searchinput = Console.ReadKey();
            int searchValue = int.Parse(searchinput.KeyChar.ToString());
            Console.Clear();
            if (searchValue != count)
            {
                Console.WriteLine(answer[searchValue - 1] + "\n" + answer[searchValue - 1].Description);
                Console.ReadKey();
                Console.Clear();
            }
            if (searchValue == count)
            {
                break;
            }
            choiceMade = false;
        }
    }
    Console.Clear();

    string inputValue = inputchoice.ToString();
    if (choiceMade)
    {
        int number;
        if (int.TryParse(inputValue, out number))
        {
            Phone chosen = phoneservice.GetPhoneById(number);
            if (number < 1)
            {
                Console.WriteLine("getal kan niet onder 1 zijn");
            }
            if (number == list.Count() + 1)
            {
                break;
            }
            if (number > list.Count() + 1)
            {
                Console.WriteLine("te hoog nummer");
            }
            if (chosen != null)
            {
                Console.WriteLine($"{chosen.Brand} {chosen.Type}  €{chosen.Price} €\" {decimal.Round(chosen.VATFreePrice(), 2)} \"\n\n{chosen.Description}");
            }
        }
        else
        {
            Console.WriteLine("verkeerd nummer");
        }
    }
    //de switch statement that handels the choice of the user and prints the respons

    //the class defining the "phone" object
    Console.ReadKey();
    Console.Clear();
}
void DisplayPhones()
{
    int count = list.Count + 1;
    foreach (var item in list)
    {
        Console.WriteLine($"{item.Id}" + " " + $"{item.Brand}" + " " + $"{item.Type}");
    }
    Console.WriteLine($"druk op {count} om te stoppen");
    Console.WriteLine("type productnummer\n");
    Console.WriteLine("\n");
    Console.WriteLine("press \"s\" to search");
}