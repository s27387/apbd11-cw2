

namespace Program_Kontenery
{
    class Kontenerowiec
    {
        public List<String> listaKontenerow = new List<String>();
        public float maxPredkosc;
        public int maxLiczbaKontenerow;
        public float maxLadownosc;
        public float obecneObciazenie = 0;

        public Kontenerowiec(float maxPredkosc, int maxLiczbaKontenerow, float maxLadownosc)
        {
            this.maxPredkosc = maxPredkosc;
            this.maxLiczbaKontenerow = maxLiczbaKontenerow;
            this.maxLadownosc = maxLadownosc;
        }
        public void dodajKontener(Kontener kontener)
        {
            try
            {
                if (listaKontenerow.Count < maxLiczbaKontenerow)
                {
                    if ((kontener.MasaLadunku + kontener.MasaWlasna) < maxLadownosc & (kontener.MasaLadunku + kontener.MasaWlasna) < obecneObciazenie)
                    {
                        throw new OverfillException("Masa ładunku przekracza maksymalną ładowność kontenerowca.");
                    }
                    obecneObciazenie += (kontener.MasaLadunku + kontener.MasaWlasna);
                    listaKontenerow.Add(kontener.NumerSeryjny);
                }
            }
            catch (OverfillException e) { }
           
        }
        public void dodajKontenery(List<Kontener> kontenery)
        {
            foreach (Kontener kontener in kontenery)
            {
                dodajKontener(kontener);
            }
        }
        public void usunKontener(Kontener kontener)
        {
            listaKontenerow.Remove(kontener.NumerSeryjny);
            obecneObciazenie -= (kontener.MasaLadunku + kontener.MasaWlasna);
        }
        public void zastapKontener(Kontener kontener, Kontener kontenerNowy)
        {
            try
            {
                if (kontenerNowy.MasaLadunku + kontenerNowy.MasaWlasna > maxLadownosc - (kontener.MasaLadunku + kontener.MasaWlasna))
                {
                    throw new OverfillException("Masa ładunku przekracza maksymalną ładowność kontenerowca.");
                }
                usunKontener(kontener);
                dodajKontener(kontenerNowy);
            }
            catch (OverfillException e) {}
        }
        public void przeniesKontener(Kontener kontener, Kontenerowiec kontenerowiecNowy)
        {
            kontenerowiecNowy.dodajKontener(kontener);
            usunKontener(kontener);
        }
        public void informacje()
        {
            Console.WriteLine($"Maksymalna prędkość: {maxPredkosc}");
            Console.WriteLine($"Maksymalna liczba kontenerów: {maxLiczbaKontenerow}");
            Console.WriteLine($"Maksymalna ładowność: {maxLadownosc}");
            Console.WriteLine("Lista kontenerów:");
            Console.WriteLine("Obecne obciazenie: " + obecneObciazenie);
            foreach (String numerSeryjny in this.listaKontenerow)
            {
                Console.WriteLine(numerSeryjny);
            }
        }
        public class OverfillException : Exception
        {
            public OverfillException() { }

            public OverfillException(string message) : base(message) { }
        }
    }
}
