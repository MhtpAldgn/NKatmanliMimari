using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiyLayer;
using DataAccessLayer;
using System.Security.Cryptography.X509Certificates;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntitiyPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonelEkle(EntitiyPersonel p)
        {
            if (p.Ad != "" && p.Soyad != "" && p.Maas >= 3500 && p.Ad.Length >= 3)
            {
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                return -1;
            }
        }
        public static bool LLPersonelSil(int per)
        {
            if (per >= 1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }
        public static bool LLPersonelGuncelle(EntitiyPersonel ent)
        {
            if (ent.Ad.Length >= 3 && ent.Ad!="" && ent.Maas>=4500)
            {
                return DALPersonel.PersonelGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
    }
    
}
