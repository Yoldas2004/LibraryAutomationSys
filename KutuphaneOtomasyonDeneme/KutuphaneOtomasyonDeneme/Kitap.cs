using System;
using System.Collections.Generic;
using System.Text;

namespace KutuphaneOtomasyonDeneme
{
    public class Kitap
    {
        /*Kitap (Sınıf): ID, Ad, Yazar, Yayın Yılı, Durum (Rafta/Ödünç).
        
        */
        //Burada uye ile ilgili islemlerde yaptigimiz gibi propler olusturduk
        public  int  ID { get; set; }
        public  string  Yazar { get; set; }
        public  string  Ad { get; set; }
        public  DateTime  YayinYili { get; set; }
        public bool Durum { get; set; }


    }
    
}
