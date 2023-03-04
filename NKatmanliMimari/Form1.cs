using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiyLayer;
using DataAccessLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntitiyPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntitiyPersonel ent = new EntitiyPersonel();
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Sehir = txtSehir.Text;
            ent.Gorev = txtGorev.Text;
            ent.Maas = short.Parse(txtMaas.Text);
            LogicPersonel.LLPersonelEkle(ent);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EntitiyPersonel ent = new EntitiyPersonel();
            ent.Id = Convert.ToInt32(txtid.Text);
            LogicPersonel.LLPersonelSil(ent.Id);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntitiyPersonel ent = new EntitiyPersonel();
            ent.Id = Convert.ToInt32(txtid.Text);
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Sehir = txtSehir.Text;
            ent.Gorev = txtGorev.Text;
            ent.Maas = short.Parse(txtMaas.Text);
            LogicPersonel.LLPersonelGuncelle(ent);

        }
    }
}
