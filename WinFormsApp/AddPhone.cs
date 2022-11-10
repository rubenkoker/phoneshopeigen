using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.WinForms
{
    public partial class AddPhone : Form
    {
        private IPhoneService phoneservice;

        public AddPhone()
        {
            InitializeComponent();
            var phoneservices = new ServiceCollection();
            ConfigureServices(phoneservices);
            ServiceProvider serviceProvider = phoneservices.BuildServiceProvider();
            phoneservice = serviceProvider.GetRequiredService<IPhoneService>();
        }



        private void DoneButton_Click(object sender, EventArgs e)
        {
            Phone phone = new();
            phone.Brand.Name = BrandtextBox.Text;
            decimal price;
            if (Decimal.TryParse(PricetextBox.Text, out price))
                phone.Price = price;
            else
                MessageBox.Show("price is wrongly formatted");
            phone.Description = DescriptiontextBox.Text;
            int stock;
            if (Int32.TryParse(StocktextBox.Text, out stock))
                phone.Stock = stock;
            else
            {
                MessageBox.Show("stock is wrongly formatted");
            }
            phone.Type = TypetextBox.Text;

            phoneservice.AddPhone(phone);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandservice, BrandService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneshopEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<DataContext>();
        }
    }
}