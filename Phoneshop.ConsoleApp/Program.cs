﻿Console.WriteLine("type productnummer\n");
// initialisation of the phone object
List<Phone> list = new()
{

    new Phone() {Id = 1, Brand ="Huawei",Type = "p30",Description="6.47\" FHD+ (2340x1080) OLED,"+
    " Kirin 980 Octa-Core(2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz +4x Cortex-A55 1.8GHz),"+
    " 8GB RAM, 128GB ROM,40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android9.0 + EMUI 9.1", Price = 697 },
    new Phone() { Id = 2,Brand = "Samsung", Type = "Galaxy A52",Description = "64 megapixel camera,"+
    " 4k videokwaliteit 6.5 inchAMOLED scherm 128 GB opslaggeheugen(Uitbreidbaar met Micro-sd)"+
    " Water- en stofbestendig(IP67", Price = 399 },
    new Phone() { Id = 3,Brand ="Apple",Type = "IPhone 11",
    Description= "Met de dubbele camera schiet je in elke situatie eenperfecte foto of video "+
    "De krachtige A13-chipset zorgtvoor razendsnelle prestaties "+
    "Met Face ID hoef je enkelen alleen naar je toestel te kijken om te ontgrendelen"+
    "Het toestel heeft een lange accuduur dankzij eenenergiezuinige processor", Price = 619 },
    new Phone() {Id = 4, Brand = "Google", Type = "Pixel 4a",
    Description= "12.2 megapixel camera, 4k videokwaliteit 5.81 inchOLED scherm "+
    "128 GB opslaggeheugen 3140 mAhaccucapaciteit", Price = 411 },
    new Phone() {Id = 5, Brand ="Xiaomi",Type = "Redmi Note 10 Pro",
      Description = "108 megapixel camera, 4k videokwaliteit 6.67 inchAMOLED scherm "+
      "128 GB opslaggeheugen(Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP53)", Price = 298 },
};

ConsoleKeyInfo input = Console.ReadKey();
string inputValue = input.KeyChar.ToString();
Console.WriteLine("\n");
Console.Clear();
//de switch statement that handels the choice of the user and prints the respons
switch (inputValue)
{
    case "1":
        Console.WriteLine($"{list[0].Brand} \n{list[0].Type}\n {list[0].Description}\n  prijs ={list[0].Price}");
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
public class Phone
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}