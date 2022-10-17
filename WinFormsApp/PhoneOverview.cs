using Phoneshop.Business;
using Phoneshop.Domain.Models;
using Phoneshop.WinForms;

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
                listBox1.Items.Add($"{item.Brand.Name} {item.Type}");
            }
            Phone SelectedPhone = Currentlist[0];
            lblBrand.Text = SelectedPhone.Brand.Name;
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
                Currentlist = phoneservice.Search(SearchBar.Text);
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
                    lblBrand.Text = SelectedPhone.Brand.Name;
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
                lblBrand.Text = SelectedPhone.Brand.Name;
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
                    lblBrand.Text = SelectedPhone.Brand.Name;
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

        private void MinusButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                MessageBox.Show("You have clicked Ok Button");
                if (listBox1.SelectedIndex > 0)
                {
                    int index = listBox1.SelectedIndex;
                    Phone SelectedPhone = Currentlist[index];
                    phoneservice.RemovePhone(SelectedPhone.Id);
                    Currentlist = phoneservice.GetAllPhones();
                    ListChanged(this, EventArgs.Empty);
                    MessageBox.Show(SelectedPhone.Id.ToString());
                }
                else
                {
                    MessageBox.Show("selecteer een telefoon");
                }

            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("You have clicked Cancel Button");
                //Some task…
            }
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            AddPhone addPhone = new AddPhone();
            addPhone.Show();

        }
    }
}