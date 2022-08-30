using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business
{


    public class PhoneService : IPhoneServicecs
    {
        private List<Phone> list = new()
        {
            new Phone() {Id = 1, Brand ="Huawei",Type = "P30",Description="6.47\" FHD+ (2340x1080) OLED,"+
            " Kirin 980 Octo-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz +4x Cortex-A55 1.8GHz),"+
            " 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android9.0 + EMUI 9.1", Price = 697 ,Stock =32},
            new Phone() { Id = 2,Brand = "Samsung", Type = "Galaxy A52",Description = "64 megapixel camera,"+
            " 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd)"+
            " Water- en stofbestendig(IP67)", Price = 399,Stock = 42 },
            new Phone() { Id = 3,Brand ="Apple",Type = "IPhone 11",
            Description= "Met de dubbele camera schiet je in elke situatie een perfecte foto of video "+
            "De krachtige A13-chipset zorgt voor razendsnelle prestaties "+
            "Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen "+
            "Het toestel heeft een lange accuduur dankzij een energiezuinige processor", Price = 619,Stock =54 },
            new Phone() {Id = 4, Brand = "Google", Type = "Pixel 4a",
            Description= "12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm "+
            "128 GB opslaggeheugen 3140 mAh accucapaciteit", Price = 411,Stock =58 },
            new Phone() {Id = 5, Brand ="Xiaomi",Type = "Redmi Note 10 Pro",
              Description = "108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm "+
              "128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP53)", Price = 298,Stock =91 },
        };
        /// <summary>
        /// returns the phone corresponding to the ID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Phone GetPhoneById(int input)
        {

            return list.Where(s => s.Id == input).FirstOrDefault();

        }
        /// <summary>
        /// public getter for the phone list
        /// </summary>
        /// <returns></returns>
        public List<Phone> GetAllPhones()
        {
            return list;
        }
        /// <summary>
        ///search function fot hte phone list (non case sensitive) 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Phone> SearchPhonesByString(string input)
        {
            if (input == "")
            {
                return new List<Phone>();
            }
            IEnumerable<Phone> results = list;
            IEnumerable<Phone> sorted = results.OrderBy(s => s.Id).ToList();

            var Output = (from t in list

                          where
                          t.Brand.Contains(input, StringComparison.CurrentCultureIgnoreCase) ||
                          t.Description.Contains(input, StringComparison.CurrentCultureIgnoreCase) ||
                          t.Type.Contains(input, StringComparison.CurrentCultureIgnoreCase)
                          select t).ToList();
            return Output;
        }

    }
}

