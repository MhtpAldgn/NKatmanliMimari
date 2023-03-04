using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiyLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntitiyPersonel> PersonelListesi()
        {
            List<EntitiyPersonel> degerler= new List<EntitiyPersonel>();
            SqlCommand komut1 = new SqlCommand("select * from TBLBILGI", Baglanti.bgl);
            if(komut1.Connection.State!= ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader rd = komut1.ExecuteReader();
            while (rd.Read())
            {
                EntitiyPersonel ent = new EntitiyPersonel();
                ent.Id = int.Parse(rd["ID"].ToString());
                ent.Ad = rd["AD"].ToString();
                ent.Soyad = rd["SOYAD"].ToString();
                ent.Sehir = rd["SEHİR"].ToString();
                ent.Gorev = rd["GOREV"].ToString();
                ent.Maas = short.Parse(rd["MAAS"].ToString());
                degerler.Add(ent);
            }
            rd.Close();
            return degerler;
        } 
        public static int PersonelEkle(EntitiyPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,SEHİR,GOREV,MAAS) values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Sehir);
            komut2.Parameters.AddWithValue("@p4", p.Gorev);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery();
        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("delete from TBLBILGI where ID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery() > 0;

        }
        public static bool PersonelGuncelle(EntitiyPersonel ent) 
        {
            SqlCommand komut4 = new SqlCommand("update TBLBILGI set AD=@G2,SOYAD=@G3,SEHİR=@G4,GOREV=@G5,MAAS=@G6 where ID=@G1", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@G1", ent.Id);
            komut4.Parameters.AddWithValue("@G2", ent.Ad);
            komut4.Parameters.AddWithValue("@G3", ent.Soyad);
            komut4.Parameters.AddWithValue("@G4", ent.Sehir);
            komut4.Parameters.AddWithValue("@G5", ent.Gorev);
            komut4.Parameters.AddWithValue("@G6", ent.Maas);
            return komut4.ExecuteNonQuery() > 0;
        }
    }
}
