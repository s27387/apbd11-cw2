using System.Runtime.CompilerServices;

namespace Program_Kontenery;

public class Kontener
{
    static public int id = 0;
    private float masaLadunku = 0f;
    public float MasaLadunku { get => masaLadunku; set => masaLadunku = value; }
    
    public float MasaWlasna { get => masaWlasna; set => masaWlasna = value; }
    private float masaWlasna;
    
    public float MaxLadownosc { get => maxLadownosc; set => maxLadownosc = value; }
    private float maxLadownosc;
    
    public float Glebokosc { get => glebokosc; set => glebokosc = value; }
    private float glebokosc;
    
    public float Wysokosc { get => wysokosc; set => wysokosc = value; }
    private float wysokosc;
    
    public string NumerSeryjny { get => numerSeryjny; set => numerSeryjny = value; }
    private string numerSeryjny;
    
    
    public Kontener(float masaWlasna, float glebokosc, float wysokosc, float maxLadownosc)
    {
        this.masaWlasna = masaWlasna;
        this.glebokosc = glebokosc;
        this.wysokosc = wysokosc;
        this.maxLadownosc = maxLadownosc;
        id++;
        this.numerSeryjny = ("CON-" + id);
    }

    public virtual void oproznienieLadunku()
    {
        masaLadunku = 0;
    }
    
    public virtual void zaladowanieLadunku(float masa)
    {
        try
        {
            if (masa > this.maxLadownosc)
                throw new OverfillException("Masa ładunku przekracza maksymalną ładowność kontenera.");
            this.masaLadunku += masa;
        }
        catch (OverfillException e) {}
        
    }

    public virtual void informacje()
    {
        Console.WriteLine($"Numer seryjny: {numerSeryjny}");
        Console.WriteLine($"Masa własna: {masaWlasna}");
        Console.WriteLine($"Głębokość: {glebokosc}");
        Console.WriteLine($"Wysokość: {wysokosc}");
        Console.WriteLine($"Maksymalna ładowność: {maxLadownosc}");
        Console.WriteLine($"Masa ładunku: {masaLadunku}");
    }

    public class OverfillException : Exception
    {
        public OverfillException() { }

        public OverfillException(string message) : base(message) { }
    }
    
}