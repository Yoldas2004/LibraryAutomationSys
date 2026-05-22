using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KutuphaneOtomasyonDeneme
{
    internal class IsYonetimKatmani
    {/*KitapYonetici (Sınıf): IKitapServisini kullanır.
      * Yeni bir Kitap nesnesi oluşturur ve bunu listeye/dosyaya ekler.
UyeYonetici (Sınıf): IUyeServisini kullanır. Üye işlemlerini yapar.
DosyaYonetici (Sınıf): Sadece .txt dosyasına veri yazma ve oradan veri okuma işini üstlenir.
        Diğer sınıflar dosyaya bir şey yazmak istediğinde bu sınıfı çağırır. 
        (Bu, kodun tek bir sorumluluğa sahip olması açısından önemlidir).*/
    }
    public class KitapYoneticiC : IKitapServis
    {
        /*public interface IKitapServis
    {
        void KitapEkle(string ad,string yazar);
        void KitapSil();
        void KitaplariGoster();
        kitap arayuzu burada neler olduguna bakip burayi duzenleyecegiz   
    }*/
        // private List<string> kitapListesi = new List<string>();
        private IDosyaServis dosyaServis = new DosyaYoneticisi();
        string dosyaYolu = "Kitaplar.txt";
        public void KitapEkle(int id,string ad, string yazar)
        {
            string yeniKitap = $"{id}|{ad}|{yazar}";
            dosyaServis.TxtYaz(dosyaYolu,yeniKitap);
            Console.WriteLine($"{ad} Kitapliga Eklendi");
            

        }

        public void KitaplariGoster()
        {
            string[] kitaplariGoster = dosyaServis.TxtOku(dosyaYolu);
            if (kitaplariGoster.Length == 0)
            {
                Console.WriteLine("Kayitli Kitap Yok");
                return;
            }

            foreach (string kitaps in kitaplariGoster)
            {
                if (string.IsNullOrWhiteSpace(kitaps)) continue;

                // split on the '|' character and trim parts
                string[] bilgiler = kitaps.Split('|');
                for (int i = 0; i < bilgiler.Length; i++) bilgiler[i] = bilgiler[i].Trim();

                if (bilgiler.Length >= 3)
                {
                    //Console.WriteLine($"Invalid record (skipped): {kitaps}");
                    //continue;
                    Console.WriteLine($"Kitap ID :{bilgiler[0]}  Kitap Adi: {bilgiler[1]} Yazar Adi: {bilgiler[2]}");
                }

                
            }
        }

        public void KitaplariYenidenYaz(string dosyaYolu, List<string> satirlar)
        {
            File.WriteAllLines(dosyaYolu,satirlar);
        }

        public void KitapSil(int silId)
        {
            string[] tumSatirlar = dosyaServis.TxtOku(dosyaYolu);
            List<string> guncelSatirlar = new List<string>();
            bool uyeBulundu = false;
            foreach (string s in tumSatirlar)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    continue;
                }

                string [] bilgiler = s.Split('|');

                if (int.TryParse(bilgiler[0],out int okunanId))
                {
                    if (okunanId != silId)
                    {
                        guncelSatirlar.Add(s);
                    }
                    else
                    { 
                        uyeBulundu=true;
                    }
                    
                }
                if (uyeBulundu)
                {
                    dosyaServis.KitaplariYenidenYaz(dosyaYolu,guncelSatirlar);
                }

            
            
            }
            
        }
    }
    public class UyeYoneticiC : IUyeServis
    {
        /*public interface IUyeServis
    {
       public void UyeEkle(Uye uye);
       public void UyeSil(int id);
       public void UyeleriGoster();
    }*/
        private IDosyaServis dosyaServis = new DosyaYoneticisi();
        string dosyaYolu = "uyeler.txt";


       public void UyeEkle(Uye uye)
        {
            string kaydedilecekMetin = $" {uye.ID} | {uye.Ad} | {uye.Soyad} | {uye.Telefon}";
            dosyaServis.TxtYaz(dosyaYolu,kaydedilecekMetin);
            Console.WriteLine("Uye Basariyla Kaydedildi");

        }
        public void  UyeleriGoster()
        {
            string[] uyeleriGoster = dosyaServis.TxtOku(dosyaYolu);
            if (uyeleriGoster.Length == 0) { Console.WriteLine("Dosya bos "); }

            foreach (string uyeler in uyeleriGoster)
            {
                if (string.IsNullOrEmpty(uyeler)) { continue; }
                
                string[] bilgiler = uyeler.Split("|");
                if(bilgiler.Length==4)
                Console.WriteLine($"ID: {bilgiler[0]}  Ad Soyad: {bilgiler[1]} {bilgiler[2]}  Telefon: {bilgiler[3]} ");
            }

        }

        public void UyeSil(int ids)
        {
          string[] tumSatirlar = dosyaServis.TxtOku(dosyaYolu);
            List<string> guncelSatirlar = new List<string>();
            bool uyeBulundu = false;
            foreach (string s in tumSatirlar)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    continue;
                }

                string [] bilgiler = s.Split('|');

                if (int.TryParse(bilgiler[0],out int okunanId))
                {
                    if (okunanId != ids)
                    {
                        guncelSatirlar.Add(s);
                    }
                    else
                    { 
                        uyeBulundu=true;
                    }
                    
                }
                if (uyeBulundu)
                {
                    dosyaServis.KitaplariYenidenYaz(dosyaYolu,guncelSatirlar);
                }

            
            
            }

        }

        public void YenidenYaz(string dosyaAdi, List<string> satirlar)
        {
            
        }
    }
    public class DosyaYoneticisi : IDosyaServis
    {
        public void KitaplariYenidenYaz(string dosyaYolu, List<string> satirlar)
        {
          
        }

        /* public interface IDosyaServis
{
public void TxtYaz(string dosya ,string icerik);
string[] TxtOku(string dosyaAdi);

}*/
        public string[] TxtOku(string dosyaAdi)
        {
            if (File.Exists(dosyaAdi))
            {
            return File.ReadAllLines(dosyaAdi);
            }
            return new string[0];
        }

        public void TxtYaz(string dosya, string icerik)
        {
          File.AppendAllText(dosya, icerik+ Environment.NewLine);
        }
    }
}
