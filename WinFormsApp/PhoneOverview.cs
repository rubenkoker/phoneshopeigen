using Phoneshop.Domain.Models;

namespace WinFormsApp
{
    public partial class PhoneOverview : Form
    {
        public event EventHandler<EventArgs> ListChanged;
        public List<Phone> Currentlist;
        Phoneshop.Business.PhoneService phoneservice = new();
        public PhoneOverview()
        {
            InitializeComponent();


            List<Phone> list = phoneservice.GetAllPhones();
            ListChanged += List_ListChanged;
            Currentlist = list;
            int count = list.Count + 1;
            foreach (var item in list)
            {
                listBox1.Items.Add($"{item.Brand}" + " " + $"{item.Type}");
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void PanelClicked(object sender, MouseEventArgs e)
        {


        }

        private void bteExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            if (SearchBar.Text.Length > 3)
            {
                Currentlist = phoneservice.SearchPhonesByString(SearchBar.Text);


                ListChanged(this, EventArgs.Empty);
            }

        }
        void List_ListChanged(object? sender, EventArgs e)
        {

            listBox1.Items.Clear();
            foreach (var item in Currentlist)
            {
                listBox1.Items.Add($"{item.Brand}" + " " + $"{item.Type}\n");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelClicked(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

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
    }
}