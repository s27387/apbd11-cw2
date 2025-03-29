namespace Program_Kontenery;

public class KontenerNaGaz : Kontener, IHazardNotifier

{
    static public int id = 0;
    public KontenerNaGaz(float masaWlasna, float glebokosc, float wysokosc, float maxLadownosc) : base(masaWlasna, glebokosc, wysokosc, maxLadownosc) {
        id++;
        NumerSeryjny = ("CON-G-" + id);
        Kontener.id--;
    }

    private float cisnienie;
    public float Cisnienie { get => cisnienie; set => cisnienie = value; }
    public override void oproznienieLadunku()
    {
        MasaLadunku = MasaLadunku * 0.05f;
    }

    public override void zaladowanieLadunku(float masa)
    {
        try
        {
            if (masa > MaxLadownosc)
            {
                throw new OverfillException($"Masa ładunku przekracza maksymalną ładowność kontenera: {NumerSeryjny}");
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
        Console.WriteLine($"Ciśnienie: {Cisnienie}");

    }

    public class NotifyHazard : Exception
    {
        public NotifyHazard() { }
        public NotifyHazard(string message) : base(message) { }
    }
}
