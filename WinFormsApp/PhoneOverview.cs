using Phoneshop.Business;
using Phoneshop.Domain.Models;

namespace WinFormsApp
{
    public partial class PhoneOverview : Form
    {
        public event EventHandler<EventArgs> ListChanged;

        private List<Phone> Currentlist;
        private List<Phone> Baselist;
        private PhoneService phoneservice = new();

        public PhoneOverview()
        {
            InitializeComponent();

            Baselist = phoneservice.GetAllPhones();
            ListChanged += List_ListChanged;
            Currentlist = Baselist;

            foreach (var item in Baselist)
            {
                listBox1.Items.Add($"{item.Brand} {item.Type}");
            }
            Phone SelectedPhone = Currentlist[0];
            lblBrand.Text = SelectedPhone.Brand;
            lblType.Text = SelectedPhone.Type;
            lblPrice.Text = SelectedPhone.Price.ToString();

            lblStock.Text = SelectedPhone.Stock.ToString();
            tbDescription.Text = SelectedPhone.Description;
        }

        private void bteExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void List_ListChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in Currentlist)
            {
                listBox1.Items.Add($"{item.Brand}" + " " + $"{item.Type}\n");
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            if (SearchBar.Text.Length > 3)
            {
                Currentlist = phoneservice.SearchPhonesByString(SearchBar.Text);
                if (Currentlist.Count == 0)

                {
                    lblBrand.Text = "";
                    lblType.Text = "";
                    lblPrice.Text = "";
                    lblStock.Text = "";
                    tbDescription.Text = "";
                }
                else
                {
                    Phone SelectedPhone = Currentlist[0];
                    lblBrand.Text = SelectedPhone.Brand;
                    lblType.Text = SelectedPhone.Type;
                    lblPrice.Text = SelectedPhone.Price.ToString();

                    lblStock.Text = SelectedPhone.Stock.ToString();
                    tbDescription.Text = SelectedPhone.Description;
                }
            }
            else
            {
                Currentlist = Baselist;
                Phone SelectedPhone = Currentlist[0];
                lblBrand.Text = SelectedPhone.Brand;
                lblType.Text = SelectedPhone.Type;
                lblPrice.Text = SelectedPhone.Price.ToString();

                lblStock.Text = SelectedPhone.Stock.ToString();
                tbDescription.Text = SelectedPhone.Description;
            }
            ListChanged(this, EventArgs.Empty);
        }

        private void PanelClicked(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (Currentlist.Count() > 0)
            {
                if (index < Currentlist.Count())
                {
                    Phone SelectedPhone = Currentlist[index];
                    lblBrand.Text = SelectedPhone.Brand;
                    lblType.Text = SelectedPhone.Type;
                    lblPrice.Text = SelectedPhone.Price.ToString();

                    lblStock.Text = SelectedPhone.Stock.ToString();
                    tbDescription.Text = SelectedPhone.Description;
                }
            }
            else
            {
                lblBrand.Text = "";
                lblType.Text = "";
                lblPrice.Text = "";

                lblStock.Text = "";
                tbDescription.Text = "";
            }
        }
    }
}