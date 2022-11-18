using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoneshop.Business;
using Phoneshop.Business.Extensions;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using Phoneshop.Shared;
using Phoneshop.Shared.extensions;
using System.Configuration;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
IPhoneService phoneservice;
ILogger logger;

var services = new ServiceCollection();
ConfigureServices(services);

ServiceProvider serviceProvider = services.BuildServiceProvider();
logger = serviceProvider.GetRequiredService<ILogger<Program>>();
phoneservice = serviceProvider.GetRequiredService<IPhoneService>();
List<Phone> list = phoneservice.GetAllPhones();
logger.LogInformation("starting");
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
                Console.WriteLine($"{chosen.Brand.Name} {chosen.Type}  €{chosen.Price} €\" {decimal.Round(chosen.VATFreePrice(), 2)} \"\n\n{chosen.Description}");
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
        Console.WriteLine($"{item.Id}" + " " + $"{item.Brand.Name}" + " " + $"{item.Type}");
    }
    Console.WriteLine($"druk op {count} om te stoppen");
    Console.WriteLine("type productnummer\n");
    Console.WriteLine("\n");
    Console.WriteLine("press \"s\" to search");
}
static void ConfigureServices(ServiceCollection services)
{
    services.AddScoped<IPhoneService, PhoneService>();
    services.AddScoped<IBrandservice, BrandService>();
    services.AddScoped<ILogger, CustomLogger>();
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    services.AddLogging(config => config.AddColorConsoleLogger(config =>
    {
        config.LogLevelToColorMap[LogLevel.Information] = ConsoleColor.Green;
        config.LogLevelToColorMap[LogLevel.Warning] = ConsoleColor.Yellow;
        config.LogLevelToColorMap[LogLevel.Error] = ConsoleColor.Red;
        config.LogLevelToColorMap[LogLevel.Critical] = ConsoleColor.DarkRed;
        config.LogLevelToColorMap
        [LogLevel.Debug] = ConsoleColor.Blue;
    }));


    string _connectionString = ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
    services.AddDbContext<DataContext>(
                 options => options.UseSqlServer(_connectionString));
}