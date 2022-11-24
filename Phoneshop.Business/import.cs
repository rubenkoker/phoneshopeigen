using Phoneshop.Domain.Models;
using System.Xml;

namespace Phoneshop.Business
{
    internal class import
    {
        private List<Phone> XMLRead(string path)
        {
            //https://www.youtube.com/watch?v=4dPWkEARptI
            XmlDocument xml = new();
            xml.Load(path);
            XmlNodeList cList = xml.GetElementsByTagName("Phone");
            foreach (XmlNode c in cList)
            {
                Phone phone = new Phone();
                phone.Brand.Name = c["Brand"].Value;
                phone.Description = c["Description"].Value;
                phone.Stock = Int32.Parse(c["Stock"].Value);
                phone.Price = Int32.Parse(c["Price"].Value);
                phone.Type = c["Type"].Value;
            }
            return null;
        }
    }
}