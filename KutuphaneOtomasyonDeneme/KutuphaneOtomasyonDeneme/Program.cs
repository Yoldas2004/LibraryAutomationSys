using System;

namespace KutuphaneOtomasyonDeneme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // İşlemleri yapacak olan yöneticilerimizi (servislerimizi) hazırlıyoruz.
            IUyeServis uyeServisi = new UyeYoneticiC();
            IKitapServis kitapServisi = new KitapYoneticiC();

            // Programın sürekli açık kalmasını sağlayacak anahtarımız
            bool sistemCalisiyor = true;

            while (sistemCalisiyor)
            {
                // Konsol ekranını temiz ve düzenli tutmak için menüyü çizdiriyoruz
                Console.WriteLine("\n==================================");
                Console.WriteLine("    KÜTÜPHANE OTOMASYON SİSTEMİ   ");
                Console.WriteLine("==================================");
                Console.WriteLine("1 - Yeni Üye Ekle");
                Console.WriteLine("2 - Üyeleri Listele");
                Console.WriteLine("3 - Yeni Kitap Ekle");
                Console.WriteLine("4 - Kitapları Listele");
                Console.WriteLine("5 - Üye Sil");
                Console.WriteLine("6 - Kitap Sil");
                Console.WriteLine("7 - Çıkış");
                Console.WriteLine("==================================");
                Console.Write("Lütfen bir işlem seçiniz (1-7): ");

                // Kullanıcının klavyeden girdiği tuşu alıyoruz
                string secim = Console.ReadLine();

                // Girilen tuşa göre ilgili senaryoyu (case) çalıştırıyoruz
                switch (secim)
                {
                    case "1":
                        Console.WriteLine("\n--- YENİ ÜYE KAYDI ---");
                        Uye yeniUye = new Uye();

                        Console.Write("ID giriniz: ");
                        if (int.TryParse(Console.ReadLine(), out int girilenID))
                        {
                            yeniUye.ID = girilenID;
                        }
                        else
                        {
                            Console.WriteLine("Hatali giris yaptiniz ID 0 olarak atandi");
                            yeniUye.ID = 0;
                        }

                        Console.Write("Ad giriniz: ");
                        yeniUye.Ad = Console.ReadLine();

                        Console.Write("Soyad giriniz: ");
                        yeniUye.Soyad = Console.ReadLine();

                        Console.Write("Telefon giriniz: ");
                        yeniUye.Telefon = Console.ReadLine();

                        // Bilgileri dolan nesneyi kaydetmesi için servise yolluyoruz
                        uyeServisi.UyeEkle(yeniUye);
                        break;

                    case "2":
                        Console.WriteLine("\n--- ÜYE LİSTESİ ---");
                        uyeServisi.UyeleriGoster();
                        break;

                    case "3":
                        Console.WriteLine("\n--- YENİ KİTAP KAYDI ---");
                        Kitap kitap = new Kitap();
                        Console.Write("Kitap Id giriniz: ");
                        // int.Parse yerine TryParse kullanarak programın çökmesini engelledik
                        int kitapId;
                        if (int.TryParse(Console.ReadLine(), out kitapId))
                        {
                            kitap.ID = kitapId;
                           // Console.WriteLine("Hatalı ID girdiniz, kitap ID'si 0 olarak atandı.");
                        }

                        Console.Write("Kitap Adı giriniz: ");
                        string kitapAdi = Console.ReadLine();

                        Console.Write("Yazar Adı giriniz: ");
                        string yazarAdi = Console.ReadLine();

                        // Kitap ekleme servisine elimizdeki bilgileri yolluyoruz
                        kitapServisi.KitapEkle(kitapId, kitapAdi, yazarAdi);
                        break;

                    case "4":
                        Console.WriteLine("\n--- KİTAP LİSTESİ ---");
                        kitapServisi.KitaplariGoster();
                        break;

                    case "5":
                        Console.WriteLine("\n--- ÜYE SİL ---");
                        Console.Write("Silmek istediğiniz üyenin ID'sini giriniz: ");
                        if (int.TryParse(Console.ReadLine(), out int silinecekUyeId))
                        {
                            uyeServisi.UyeSil(silinecekUyeId);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş yaptınız. Lütfen sadece sayı kullanın.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("\n--- KİTAP SİL ---");
                        Console.Write("Silmek istediğiniz kitabın ID'sini giriniz: ");
                        if (int.TryParse(Console.ReadLine(), out int silinecekKitapId))
                        {
                            // Dikkat: IKitapServis arayüzündeki KitapSil metodunun içine (int id) parametresini eklemeyi unutma!
                            kitapServisi.KitapSil(silinecekKitapId);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş yaptınız. Lütfen sadece sayı kullanın.");
                        }
                        break;

                    case "7":
                        Console.WriteLine("\nSistemden çıkılıyor... İyi günler!");
                        sistemCalisiyor = false; // Döngüyü kırar ve programı kapatır
                        break;

                    default:
                        // Eğer kullanıcı 1-7 dışında saçma bir tuşa basarsa burası çalışır
                        Console.WriteLine("\nHatalı bir seçim yaptınız. Lütfen 1 ile 7 arasında bir değer giriniz.");
                        break;
                }
            }
        }
    }
}