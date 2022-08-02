namespace Phoneshop.Business
{
    using Phoneshop.Domain.Models;
    public class PhoneService
    {


        private List<Phone> list = new()
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
        public Phone GetPhoneById(int input)
        {
            foreach (var item in list)
            {
                if (input == item.Id)
                {
                    return item;
                }


            }

            return null;

        }
        public List<Phone> GetAllPhones()
        {
            return list;
        }
        public void DisplayPhones()
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}" + " " + $"{item.Brand}" + " " + $"{item.Type}");
            }
            Console.WriteLine("type productnummer\n");
            // initialisation of the phone object



            // initialisation of the phone object
            Console.WriteLine("\n");
        }
        public Phone SelectPhone()
        {
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


            //de switch statement that handels the choice of the user and prints the respons
            switch (inputValue)
            {
                case "1":
                    return list[0];
                //Console.WriteLine($"{list[0].Brand} \n{list[0].Type}\n {list[0].Description}\n  prijs ={list[0].Price}");

                case "2":
                    return list[1];


                case "3":
                    return list[2];

                case "4":
                    return list[3];


                case "5":
                    return list[4];

                default:
                    return null;

            }
        }
    }
}