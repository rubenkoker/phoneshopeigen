// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<phone> list = new List<phone>()
{
    new phone() {Id = 1, Brand ="Huawei",Type = "p30" },
new phone() { Id = 2,Brand = "Samsung", Type = "Galaxy A52" },
new phone() { Id = 3,Brand ="Apple",Type = "IPhone 11" },
new phone() {Id = 4, Brand = "Google", Type = "Pixel 4a" },
new phone() {Id = 5, Brand ="Xiaomi",Type = "Redmi Note 10 Pro" },


};
ConsoleKeyInfo input = Console.ReadKey();
string InputValue = input.KeyChar.ToString();   
Console.WriteLine("/n");
Console.WriteLine(InputValue);  
switch (InputValue)
{
    case "1":
        Console.WriteLine(@"{list.get(0)}");
        break;
     case "2":     
         Console.WriteLine(@"{list.get(1)}");
        break;
    case "3":
        Console.WriteLine(@"{list.get(2)}");
        break;
    case "4":
        Console.WriteLine(@"{list.get(3)}");
        break;
    case "5":
        Console.WriteLine(@"{list.get(4)}");
        break;
    default:
        Console.WriteLine("geen geldige knop");
        break;
}
public class phone
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}