using Phoneshop.Business;
using Phoneshop.Domain.Models;

namespace Phoneshop.WinForms
{
    public partial class AddPhone : Form
    {
        public AddPhone()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                phone.Price = stock;
            else
            {
                MessageBox.Show("stock is wrongly formatted");
            }
            phone.Type = TypetextBox.Text;
            PhoneService phoneservice = new();
            phoneservice.AddPhone(phone);
        }

    }
}

