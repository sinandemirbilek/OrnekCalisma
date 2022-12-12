using Project.BBL.DesignerPatterns.GenericPattern.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WINUI
{
    public partial class Form1 : Form
    {
        CategoryRepository _cRep;
        public Form1()
        {
            InitializeComponent();
            _cRep = new CategoryRepository();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.CategoryName = txtName.Text;
            _cRep.Add(c);

            ListSonuc();
        }

        private void ListSonuc()
        {
            lstSonuc.DataSource = _cRep.GetActives();
        }

        Category _selected;
        private void lstSonuc_MouseClick(object sender, MouseEventArgs e)
        {
            if ( lstSonuc.SelectedIndex > -1)
            {
                _selected = lstSonuc.SelectedItem as Category;
                txtName.Text = _selected.CategoryName;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(_selected != null)
            {
                _cRep.Delete(_selected);
                _selected = null;
                ListSonuc();
            }
            
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(_selected != null)
            {
                _selected.CategoryName = txtName.Text;
                _cRep.Update(_selected);
                _selected = null;
                ListSonuc();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            
            lstSonuc.DataSource = _cRep.GetAll(); 
        }
    }
}
