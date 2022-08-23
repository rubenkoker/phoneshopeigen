﻿using Phoneshop.Domain.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
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

        while (true)
        {
            int Count = 1;
            Console.Clear();
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
            if (SearchValue != Count)
            {
                Console.WriteLine(answer[SearchValue - 1] + "\n" + answer[SearchValue - 1].Description);
                Console.ReadKey();
                Console.Clear();
            }
            if (SearchValue == Count)
            {
                break;
            }
        }
    }
    Console.Clear();
    string inputValue = inputchoice.ToString();

    int number;
    if (int.TryParse(inputValue, out number))
    {

        Phone chosen = phoneservice.GetPhoneById(number);
        if (number == 6)
        {
            break;
        }
        if (chosen != null)
        {
            Console.WriteLine($"{chosen.Brand} {chosen.Type}  € {chosen.Price}€\" {Decimal.Round(chosen.VATFreePrice(), 2)} \"\n\n{chosen.Description}");
        }


    }
    else
    {
        Console.WriteLine("wrong number");

    }


    //de switch statement that handels the choice of the user and prints the respons

    //the class defining the "phone" object
    Console.ReadLine();
}