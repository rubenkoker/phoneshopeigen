Console.WriteLine("type productnummer\n");
// initialisation of hte phone object
List<Phone> List = new()
{
new Phone() {Id = 1, Brand ="Huawei",Type = "p30",Description="6.47\" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core(2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz +4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM,40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android9.0 + EMUI 9.1", Price = 697 },
new Phone() { Id = 2,Brand = "Samsung", Type = "Galaxy A52",Description = "64 megapixel camera, 4k videokwaliteit 6.5 inchAMOLED scherm 128 GB opslaggeheugen(Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP67", Price = 399 },
new Phone() { Id = 3,Brand ="Apple",Type = "IPhone 11",Description= "Met de dubbele camera schiet je in elke situatie eenperfecte foto of video De krachtige A13-chipset zorgtvoor razendsnelle prestaties Met Face ID hoef je enkelen alleen naar je toestel te kijken om te ontgrendelenHet toestel heeft een lange accuduur dankzij eenenergiezuinige processor", Price = 619 },
new Phone() {Id = 4, Brand = "Google", Type = "Pixel 4a",Description= "12.2 megapixel camera, 4k videokwaliteit 5.81 inchOLED scherm 128 GB opslaggeheugen 3140 mAhaccucapaciteit", Price = 411 },
new Phone() {Id = 5, Brand ="Xiaomi",Type = "Redmi Note 10 Pro",Description = "108 megapixel camera, 4k videokwaliteit 6.67 inchAMOLED scherm 128 GB opslaggeheugen(Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP53)", Price = 298 },
};

ConsoleKeyInfo input = Console.ReadKey();
string InputValue = input.KeyChar.ToString();
Console.WriteLine("\n");
Console.Clear();
//de switch statement that handels the choice of the user and prints the respons
switch (InputValue)
{
    case "1":
        Console.WriteLine($"{List[0].Brand}" + " " + $"{List[0].Type}" + " " + $"{List[0].Description}" + " prijs =" + $"{List[0].Price}");
        break;
    case "2":
        Console.WriteLine($"{List[1].Brand}" + " " + $"{List[1].Type}" + " " + $"{List[1].Description}" + " prijs =" + $"{List[1].Price}");
        break;
    case "3":
        Console.WriteLine($"{List[2].Brand}" + " " + $"{List[2].Type}" + " " + $"{List[2].Description}" + " prijs =" + $"{List[2].Price}");
        break;
    case "4":
        Console.WriteLine($"{List[3].Brand}" + " " + $"{List[3].Type}" + " " + $"{List[3].Description}" + " prijs =" + $"{List[3].Price}");
        break;
    case "5":
        Console.WriteLine($"{List[4].Brand}" + " " + $"{List[4].Type}" + " " + $"{List[4].Description}" + " prijs =" + $"{List[4].Price}");
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