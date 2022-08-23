using Phoneshop.Domain.Models;

namespace WinFormsApp
{
    public partial class PhoneOverview : Form
    {
        public event EventHandler<EventArgs> UserChanged;
        public List<Phone> Currentlist;
        Phoneshop.Business.PhoneService phoneservice = new();
        public PhoneOverview()
        {
            InitializeComponent();


            List<Phone> list = phoneservice.GetAllPhones();
            UserChanged += List_ListChanged;
            Currentlist = list;
            int count = list.Count + 1;
            foreach (var item in list)
            {
                SearchResultPanel.Text += $"{item.Brand}" + " " + $"{item.Type}\n";
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
            int index = SearchResultPanel.SelectionStart;
            int line = SearchResultPanel.GetLineFromCharIndex(index);
            if (line < Currentlist.Count())
            {
                Phone SelectedPhone = Currentlist[line];
                lblBrand.Text = SelectedPhone.Brand;
                lblType.Text = SelectedPhone.Type;
                lblPrice.Text = SelectedPhone.Price.ToString();

                lblStock.Text = SelectedPhone.Stock.ToString();
                tbDescription.Text = SelectedPhone.Description;

            }

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


                UserChanged(this, EventArgs.Empty);
            }

        }
        void List_ListChanged(object? sender, EventArgs e)
        {

            SearchResultPanel.Text = string.Empty;
            foreach (var item in Currentlist)
            {
                SearchResultPanel.Text += $"{item.Brand}" + " " + $"{item.Type}\n";
            }

        }
    }
}