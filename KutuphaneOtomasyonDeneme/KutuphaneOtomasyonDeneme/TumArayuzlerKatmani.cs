using System;
using System.Collections.Generic;
using System.Text;

namespace KutuphaneOtomasyonDeneme
{
    //interfacelar olusturduk vekulolanima hazilr hale getirdik
    internal interface TumArayuzlerKatmani
    {
        /*IKitapServisi (Arayüz): KitapEkle(), KitapSil(), KitaplariGetir()

IUyeServisi (Arayüz): UyeEkle(), UyeSil(), UyeleriGetir()

IDosyaServisi (Arayüz): TxtYaz(), TxtOku()*/
    }

    public interface IDosyaServis
    {
       public void TxtYaz(string dosya ,string icerik);
        string[] TxtOku(string dosyaAdi);
        public void KitaplariYenidenYaz(string dosyaYolu, List<string> satirlar);


    }

    public interface IUyeServis
    {
       public void UyeEkle(Uye uye);
       public void UyeSil(int id);
        public void YenidenYaz(string dosyaAdi, List<string> satirlar);
       public void UyeleriGoster();
    }

    public interface IKitapServis
    {
        void KitapEkle(int id,string ad,string yazar);
        void KitapSil(int id);
        void KitaplariGoster();
    
        
    }
}

