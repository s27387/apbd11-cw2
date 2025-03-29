
namespace Program_Kontenery;

    public class KontenerNaPlyn : Kontener, IHazardNotifier
{
        static public int id = 0;
        public KontenerNaPlyn(float masaWlasna, float glebokosc, float wysokosc, float maxLadownosc) : base(masaWlasna, glebokosc, wysokosc, maxLadownosc) 
        {
        id++;
        NumerSeryjny = ("CON-P-" + id);
        Kontener.id--;
        }
        public override void oproznienieLadunku()
        {
            MasaLadunku = MasaLadunku * 0.05f;
        }
        public void zaladowanieLadunku(float masa, bool isDangeroous)
        {
            try
            { 
            if(isDangeroous & masa > MaxLadownosc * 0.5f)
                {
                    throw new NotifyHazard("Masa ładunku przekracza maksymalną dozwoloną dla tego towaru ładowność w kontenerze", this);
                }
            if (masa > MaxLadownosc * 0.9f)
                {
                    throw new NotifyHazard("Masa ładunku przekracza maksymalną ładowność kontenera", this);
                }
                MasaLadunku += masa;
            }
            catch (NotifyHazard e) {}
        }
    

    public class NotifyHazard : Exception
        {
            public NotifyHazard() { }
            public NotifyHazard(String message, KontenerNaPlyn kontener)
            {
                Console.WriteLine($"Kontener o numerze seryjnym: {kontener.NumerSeryjny} jest niebezpieczny. {message}");
            }
            public NotifyHazard(string message) : base(message) { }
        }
    }
    
