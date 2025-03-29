// See https://aka.ms/new-console-template for more information
namespace Program_Kontenery;

internal class Program
{
    public static void Main(string[] args)
    {
        // Testowanie klasy Kontener
        Kontener kontener = new Kontener(100, 100, 100, 1000);
        kontener.informacje();
        kontener.zaladowanieLadunku(500);
        kontener.informacje();
        kontener.oproznienieLadunku();
        kontener.informacje();

        // Testowanie klasy KontenerNaGaz
        KontenerNaGaz kontenerNaGaz = new KontenerNaGaz(100, 100, 100, 1000);
        kontenerNaGaz.informacje();
        kontenerNaGaz.zaladowanieLadunku(500);
        kontenerNaGaz.informacje();
        kontenerNaGaz.oproznienieLadunku();
        kontenerNaGaz.informacje();

        // Testowanie klasy KontenerNaPlyn
        KontenerNaPlyn kontenerNaPlyn = new KontenerNaPlyn(100, 100, 100, 1000);
        kontenerNaPlyn.informacje();
        kontenerNaPlyn.zaladowanieLadunku(500, true);
        kontenerNaPlyn.informacje();
        // kontenerNaPlyn.oproznienieLadunku();
        kontenerNaPlyn.informacje();
        kontener.informacje();
        // Testowanie klasy KontenerChlodniczy
        KontenerChlodniczy kontenerChlodniczy = new KontenerChlodniczy(100, 100, 100, 1000, "Bananas", 10);
        kontenerChlodniczy.informacje();
        kontenerChlodniczy.zaladowanieLadunku(200, "Bananas");
        kontenerChlodniczy.informacje();
        // kontenerChlodniczy.oproznienieLadunku();
        kontenerChlodniczy.informacje();
        kontener.informacje();
        // Testowanie klasy Kontenerowiec
        Kontenerowiec kontenerowiec2 = new Kontenerowiec( 100, 10, 1000);
        kontenerowiec2.informacje();
        kontenerowiec2.dodajKontener(kontener);
        kontenerowiec2.dodajKontener(kontenerNaGaz);
        kontenerowiec2.informacje();
        kontenerowiec2.usunKontener(kontener);
        kontenerowiec2.dodajKontener(kontenerNaPlyn);
        kontenerowiec2.informacje();
        kontenerowiec2.usunKontener(kontenerNaPlyn);
        kontenerowiec2.dodajKontener(kontenerChlodniczy);
        kontenerowiec2.informacje();
        kontenerowiec2.usunKontener(kontener);
        kontenerowiec2.informacje();
        kontener.informacje();
        // Testowanie pozostalych metod kontenerowca
        Kontenerowiec kontenerowiec = new Kontenerowiec(100, 10, 2000);

        // Testowanie metody usunKontener
        kontenerowiec.dodajKontener(kontener);
        kontenerowiec.usunKontener(kontener);
        kontenerowiec.informacje();

    // Testowanie metody zastapKontener
        Kontener kontenerNowy = new Kontener(100, 100, 100, 25000);
        kontenerowiec.dodajKontener(kontener);
        kontenerowiec.zastapKontener(kontener, kontenerNowy);
        kontenerowiec.informacje();

    // Testowanie metody przeniesKontener
        Kontenerowiec kontenerowiecNowy = new Kontenerowiec(100, 10, 1000);
        kontenerowiec.dodajKontener(kontener);
        kontenerowiec.przeniesKontener(kontener, kontenerowiecNowy);
        kontenerowiec.informacje();
        kontenerowiecNowy.informacje();

// Testowanie metody dodajKontenery
        List<Kontener> kontenery = new List<Kontener>();
        kontenery.Add(kontener);
        kontenery.Add(kontenerNowy);
        kontenerowiec.dodajKontenery(kontenery);
        kontenerowiec.informacje();
        kontenerNowy.informacje();
    }
}
