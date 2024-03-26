namespace KutuphaneOtomasyonSistemi
{
	public enum Durum
	{
		OduncAlabilir,
		OduncVerildi,
		MevcutDegil
	}

	public abstract class Kitap
	{
		public string ISBN { get; set; }
		public string Baslik { get; set; }
		public string Yazar { get; set; }
		public int YayinYili { get; set; }
		public Durum Durum { get; set; }
	}

	public class KitapBilim : Kitap
	{
		public string Konu { get; set; }
	}

	public class KitapRoman : Kitap
	{
		public string AnaKarakter { get; set; }
	}

	public class KitapTarih : Kitap
	{
		public string Donem { get; set; }
	}

	public interface IUye
	{
		string Ad { get; set; }
		string Soyad { get; set; }
		int UyeNo { get; set; }
		List<Kitap> OduncKitaplar { get; set; }

		void KitapOduncAl(Kitap kitap);
		void KitapIadeEt(Kitap kitap);
	}

	public class Uye : IUye
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public int UyeNo { get; set; }
		public List<Kitap> OduncKitaplar { get; set; }

		public void KitapOduncAl(Kitap kitap)
		{
			if (kitap.Durum == Durum.OduncAlabilir)
			{
				kitap.Durum = Durum.OduncVerildi;
				OduncKitaplar.Add(kitap);
				Console.WriteLine($"{kitap.Baslik} kitabı ödünç alındı.");
			}
			else
			{
				Console.WriteLine($"{kitap.Baslik} kitabı ödünç alınamaz.");
			}
		}

		public void KitapIadeEt(Kitap kitap)
		{
			if (OduncKitaplar.Contains(kitap))
			{
				kitap.Durum = Durum.OduncAlabilir;
				OduncKitaplar.Remove(kitap);
				Console.WriteLine($"{kitap.Baslik} kitabı iade edildi.");
			}
			else
			{
				Console.WriteLine($"{kitap.Baslik} kitabı zaten ödünçte değil.");
			}
		}
	}

	public class Kutuphane
	{
		public List<Kitap> Kitaplar { get; set; }
		public List<IUye> Uyeler { get; set; }

		public void KitapDurumGuncelle(Kitap kitap, Durum durum)
		{
			kitap.Durum = durum;
		}

		public void KatalogGoruntule()
		{
			Console.WriteLine("Katalog:");
			foreach (var kitap in Kitaplar)
			{
				Console.WriteLine($"{kitap.Baslik} - {kitap.Durum}");
			}
		}

		public void UyeKitaplariGoruntule(IUye uye)
		{
			Console.WriteLine($"{uye.Ad} {uye.Soyad} Ödünç Kitapları:");
			foreach (var kitap in uye.OduncKitaplar)
			{
				Console.WriteLine($"{kitap.Baslik}");
			}
		}
	}
}
