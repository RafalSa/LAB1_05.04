using System;

namespace FabrykaPaczek
{
    public interface IPaczka
    {
        void Przygotuj();
    }

    public class MałaPaczka : IPaczka
    {
        public void Przygotuj()
        {
            Console.WriteLine("Przygotowano małą paczkę.");
        }
    }

    public class DużaPaczka : IPaczka
    {
        public void Przygotuj()
        {
            Console.WriteLine("Przygotowano dużą paczkę.");
        }
    }

    public class ZarządzaniePaczkami
    {
        private IFabrykaPaczek fabrykaPaczek;
        private static ZarządzaniePaczkami _instancja;

        private ZarządzaniePaczkami() { }

        public static ZarządzaniePaczkami Instancja
        {
            get
            {
                if (_instancja == null)
                {
                    _instancja = new ZarządzaniePaczkami();
                }
                return _instancja;
            }
        }

        public void UstawFabrykę(IFabrykaPaczek fabryka)
        {
            fabrykaPaczek = fabryka;
        }

        public void PrzygotujPaczkę()
        {
            if (fabrykaPaczek != null)
            {
                IPaczka paczka = fabrykaPaczek.UtwórzPaczkę();
                paczka.Przygotuj();
            }
            else
            {
                Console.WriteLine("Fabryka paczek nie została ustawiona.");
            }
        }
    }

    public interface IFabrykaPaczek
    {
        IPaczka UtwórzPaczkę();
    }

    public class FabrykaMałychPaczek : IFabrykaPaczek
    {
        public IPaczka UtwórzPaczkę()
        {
            return new MałaPaczka();
        }
    }

    public class FabrykaDużychPaczek : IFabrykaPaczek
    {
        public IPaczka UtwórzPaczkę()
        {
            return new DużaPaczka();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ZarządzaniePaczkami zarządzanie = ZarządzaniePaczkami.Instancja;
            zarządzanie.UstawFabrykę(new FabrykaMałychPaczek());
            zarządzanie.PrzygotujPaczkę(); 

            zarządzanie.UstawFabrykę(new FabrykaDużychPaczek());
            zarządzanie.PrzygotujPaczkę();
        }
    }
}
