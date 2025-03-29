
using System.Transactions;

namespace Program_Kontenery
{
    class KontenerChlodniczy : Kontener, IHazardNotifier
    {
        static public Dictionary<string, float> rodzajeProduktow = new Dictionary<string, float> { { "Bananas", 13.3f }, { "Chocolate", 18f }, { "Fish", 2f } };
        static public int id = 0;

        public KontenerChlodniczy(float masaWlasna, float glebokosc, float wysokosc, float maxLadownosc, string rodzajProduktu, float temperatura) : base(masaWlasna, glebokosc, wysokosc, maxLadownosc)
        {
            this.rodzajProduktu = rodzajProduktu;
            this.temperatura = temperatura;
            id++;
            NumerSeryjny = ("CON-CH-" + id);
            Kontener.id--;
        }

        private float temperatura;
        public float Temperatura { get => temperatura; set => temperatura = value; }
        private string rodzajProduktu;


        public void zaladowanieLadunku(float masa, string rodzajProduktu)
        {
            try
            {
            if (rodzajProduktu != this.rodzajProduktu)
            {
                throw new NotifyHazard("Kontener nie przystosowany do zaladunku tego typu produktu.");
            }
            if (rodzajeProduktow[rodzajProduktu] > temperatura)
            {
                if (masa > MaxLadownosc)
                    {
                        throw new OverfillException("Masa ładunku przekracza maksymalną ładowność kontenera.");
                    }
            }
            else
            {
                throw new NotifyHazard("Temperatura kontenera jest zbyt niska."); 
            }
            MasaLadunku += masa;
        }
        catch (OverfillException e) {}
        }

        public override void informacje()
        {
            Console.WriteLine($"Numer seryjny: {NumerSeryjny}");
            Console.WriteLine($"Masa własna: {MasaWlasna}");
            Console.WriteLine($"Głębokość: {Glebokosc}");
            Console.WriteLine($"Wysokość: {Wysokosc}");
            Console.WriteLine($"Maksymalna ładowność: {MaxLadownosc}");
            Console.WriteLine($"Masa ładunku: {MasaLadunku}");
            Console.WriteLine($"Temperatura: {Temperatura}");
            Console.WriteLine($"Rodzaj produktu: {rodzajProduktu}");
        }

        public class NotifyHazard : Exception
        {
            public NotifyHazard() { }
            public NotifyHazard(string message) : base(message) { }
        }
    }
}
