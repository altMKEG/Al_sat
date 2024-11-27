using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_sat
{
    class TicaretUygulamasi
    {
        static void Main()
        {
            int butce = 1000;
            List<string> urunlerim = new List<string>();

            List<string> satistakiurunler = new List<string>();
            List<int> urunfiyatlari = new List<int>();

            Console.WriteLine("Satışa sunmak istediğiniz ürünleri ekleyin");

            while (true)
            {
                Console.Write("Ürün adı giriniz (Çıkmak için 'q' yazın): ");
                string urunismi = Console.ReadLine();

                if (urunismi.ToLower() == "q")
                    break;

                Console.Write("Bu ürünün fiyatını giriniz: ");
                string fiyatgirisi = Console.ReadLine();
                int urunfiyat;

                if (int.TryParse(fiyatgirisi, out urunfiyat) && urunfiyat > 0)
                {
                    satistakiurunler.Add(urunismi);
                    urunfiyatlari.Add(urunfiyat);
                    Console.WriteLine($"{urunismi} ürünü {urunfiyat} TL olarak eklendi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz fiyat girdiniz. Lütfen tekrar deneyin.");
                }
            }

            Console.WriteLine("\nSatış listesi oluşturuldu");

            while (true)
            {
                Console.WriteLine("\nLütfen bir işlem seçiniz:");
                Console.WriteLine("1 - Sahip olduğum ürünleri görüntüle");
                Console.WriteLine("2 - Bakiyemi görüntüle");
                Console.WriteLine("3 - Ürün satın al");
                Console.WriteLine("4 - Ürün sat");
                Console.WriteLine("5 - Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("\nSahip Olduğunuz Ürünler:");
                    if (urunlerim.Count > 0)
                    {
                        foreach (var urun in urunlerim)
                        {
                            Console.WriteLine($"- {urun}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ürününüz yok.");
                    }
                }
                else if (secim == "2")
                {
                    Console.WriteLine($"\nMevcut Bakiyeniz: {butce} TL");
                }
                else if (secim == "3")
                {
                    if (satistakiurunler.Count == 0)
                    {
                        Console.WriteLine("\nSatışta ürün bulunmamaktadır.");
                        continue;
                    }

                    Console.WriteLine("\nSatışta olan ürünler:");
                    for (int i = 0; i < satistakiurunler.Count; i++)
                    {
                        Console.WriteLine($"- {satistakiurunler[i]}: {urunfiyatlari[i]} TL");
                    }

                    Console.Write("\nSatın almak istediğiniz ürünün adını giriniz: ");
                    string alinacakurun = Console.ReadLine();

                    int urunIndex = satistakiurunler.IndexOf(alinacakurun);

                    if (urunIndex != -1)
                    {
                        int fiyat = urunfiyatlari[urunIndex];
                        if (butce >= fiyat)
                        {
                            urunlerim.Add(alinacakurun);
                            butce -= fiyat;
                            Console.WriteLine($"{alinacakurun} satın alındı. Kalan bakiyeniz: {butce} TL");
                        }
                        else
                        {
                            Console.WriteLine("Bu ürünü satın alacak kadar bakiyeniz yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ürün adı girdiniz. Lütfen listeden bir ürün seçin.");
                    }
                }
                else if (secim == "4")
                {
                    if (urunlerim.Count == 0)
                    {
                        Console.WriteLine("\nSatacak bir ürününüz yok.");
                        continue;
                    }

                    Console.WriteLine("\nSatmak istediğiniz ürünler:");
                    for (int i = 0; i < urunlerim.Count; i++)
                    {
                        Console.WriteLine($"- {urunlerim[i]}");
                    }

                    Console.Write("\nSatmak istediğiniz ürünün adını giriniz: ");
                    string satilacakurun = Console.ReadLine();

                    if (urunlerim.Contains(satilacakurun))
                    {
                        Console.Write("Bu ürünü kaç TL'ye satmak istersiniz? ");
                        string fiyatgirisi = Console.ReadLine();
                        int satisFiyati;

                        if (int.TryParse(fiyatgirisi, out satisFiyati) && satisFiyati > 0)
                        {
                            urunlerim.Remove(satilacakurun);
                            butce += satisFiyati;
                            Console.WriteLine($"{satilacakurun} ürünü {satisFiyati} TL'ye satıldı. Yeni bakiyeniz: {butce} TL");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz fiyat girdiniz. Satış iptal edildi.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ürün adı girdiniz. Lütfen sahip olduğunuz ürünlerden birini seçin.");
                    }
                }
                else if (secim == "5")
                {
                    Console.WriteLine("Uygulamadan çıkış yapılıyor.");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyiniz.");
                }
            }

            Console.Read();


        }
    }
}
