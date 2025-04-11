using System;

namespace SistemManajemenKaryawan
{
    public class Karyawan
    {
        private string _nama;
        private string _id;
        private double _gajiPokok;

        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public double GajiPokok
        {
            get { return _gajiPokok; }
            set { _gajiPokok = value; }
        }

        public virtual void HitungGaji()
        {
            double GajiAkhir = _gajiPokok;
        }
    }


    public class KaryawanTetap : Karyawan
    {
        private double BonusTetap = 500000;

        public override void HitungGaji()
        {
            double GajiAkhir = GajiPokok + BonusTetap;
            Console.WriteLine($"Gaji Akhir  : Rp {GajiAkhir}");
        }
    }


    public class KaryawanKontrak : Karyawan
    {
        private double PotonganKontrak = 200000;

        public override void HitungGaji()
        {
            double GajiAkhir = GajiPokok - PotonganKontrak;
            Console.WriteLine($"Gaji Akhir  : Rp {GajiAkhir}");
        }
    }


    public class KaryawanMagang : Karyawan
    {
        public override void HitungGaji()
        {
            double GajiAkhir = GajiPokok;
            Console.WriteLine($"Gaji Akhir  : Rp {GajiAkhir}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===>>>> Sistem Manajemen Karyawan <<<<===");

            Console.WriteLine("Jenis Karyawan : \n1. Tetap \n2. Kontrak \n3. Magang ");
            Console.Write("Pilih [1/2/3] : ");
            int jenisKaryawan = int.Parse(Console.ReadLine());

            Console.Write("Nama Karyawan : ");
            string nama = Console.ReadLine();

            Console.Write("ID Karyawan   : ");
            string id = Console.ReadLine();

            Console.Write("Gaji Pokok    : ");
            double gajiPokok = double.Parse(Console.ReadLine());


            Karyawan karyawan = null;
            string status = null;

            if (jenisKaryawan == 1)
            {
                karyawan = new KaryawanTetap();
                status = "Karyawan Tetap";
            }
            else if (jenisKaryawan == 2)
            {
                karyawan = new KaryawanKontrak();
                status = "Karyawan Kontrak";
            }
            else if (jenisKaryawan == 3)
            {
                karyawan = new KaryawanMagang();
                status = "Karyawan Magang";
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
                return;
            }

            karyawan.Nama = nama;
            karyawan.ID = id;
            karyawan.GajiPokok = gajiPokok;

            Console.WriteLine("\n**** Detail Karyawan ****");
            Console.WriteLine($"Nama        : {karyawan.Nama}");
            Console.WriteLine($"ID          : {karyawan.ID}");
            Console.WriteLine($"Status      : {status}");
            Console.WriteLine($"Gaji Pokok  : Rp {karyawan.GajiPokok}");
            karyawan.HitungGaji();
        }
    }
}