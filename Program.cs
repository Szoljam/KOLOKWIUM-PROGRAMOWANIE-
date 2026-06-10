//zadanie 3 UML 
using System;
using System.Collections.Generic;

public class Kontakt
{
    public string alternatywnyEmail { get; set; }
    public string email { get; set; }
    public string imie { get; set; }
    public string nazwisko { get; set; }
    public string opis { get; set; }
    public int telefonDOM { get; set; }
    public int telefonGSM { get; set; }
    public int telefonPraca { get; set; }

    public Kontakt(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }
}

public class Dzial
{
    public int id { get; set; }
    public string nazwa { get; set; }
    public string opis { get; set; }

    public Dzial(int id, string nazwa)
    {
        this.id = id;
        this.nazwa = nazwa;
    }
}

public class Zalacznik
{
    public string downloadUrl { get; set; }
    public string fileName { get; set; }

    public Zalacznik(string fileName, string downloadUrl)
    {
        this.fileName = fileName;
        this.downloadUrl = downloadUrl;
    }
}
public class KsiazkaAdresowa
{
    public List<Kontakt> kontakty { get; set; } = new List<Kontakt>();

    public KsiazkaAdresowa() { }

    public void addKontakt(Kontakt kontakt) => kontakty.Add(kontakt);

    public Kontakt getKontakt(int index) => (index >= 0 && index < kontakty.Count) ? kontakty[index] : null;

    public void removeKontakt(int index)
    {
        if (index >= 0 && index < kontakty.Count) kontakty.RemoveAt(index);
    }
}

public class CzarnaLista
{
    public List<string> adresyEmail { get; set; } = new List<string>();

    public CzarnaLista(params string[] adresy)
    {
        if (adresy != null) adresyEmail.AddRange(adresy);
    }

    public void dodajAdresEmail(string email) => adresyEmail.Add(email);
    public void usunAdresEmail(string email) => adresyEmail.Remove(email);
}

public class Ustawienia
{
    public string jezyk { get; set; }
    public string kodowanie { get; set; }
    public List<string> kolory { get; set; } = new List<string>();
    public string przekierowanie { get; set; }
    public List<string> skrotyKlawiszowe { get; set; } = new List<string>();

    public Ustawienia() { }

    public void dodajKolor(string kolor) => kolory.Add(kolor);
    public void usunKolor(string kolor) => kolory.Remove(kolor);
    public void dodajSkrot(string skrot) => skrotyKlawiszowe.Add(skrot);
    public void usunSkrot(string skrot) => skrotyKlawiszowe.Remove(skrot);
}

public class Reklama
{
    public List<Dzial> grupyDedykowane { get; set; } = new List<Dzial>();
    public string tresc { get; set; }

    public Reklama() { }

    public void dodajGrupeDedykowana(Dzial dzial) => grupyDedykowane.Add(dzial);
    public void usunGrupeDedykowana(int id) => grupyDedykowane.RemoveAll(d => d.id == id);
}
public class Użytkownik
{
    public CzarnaLista czarnaLista { get; set; }
    public string dataString { get; set; }
    public List<Dzial> dzialy { get; set; } = new List<Dzial>();
    public string haslo { get; set; }
    public KsiazkaAdresowa ksiazkaAdresowa { get; set; }
    public string login { get; set; }
    public Ustawienia ustawienia { get; set; }

    public Użytkownik(string login, string haslo)
    {
        this.login = login;
        this.haslo = haslo;
        this.ksiazkaAdresowa = new KsiazkaAdresowa();
        this.czarnaLista = new CzarnaLista();
        this.ustawienia = new Ustawienia();
    }

    public void wypiszDane()
    {
        Console.WriteLine($"Użytkownik: {login}, Posiada kontaktów: {ksiazkaAdresowa.kontakty.Count}");
    }
}

public class Folder
{
    public string nazwa { get; set; }
    public Użytkownik wlasciciel { get; set; }

    public Folder(string nazwa, Użytkownik wlasciciel)
    {
        this.nazwa = nazwa;
        this.wlasciciel = wlasciciel;
    }
}

public class Mail
{
    public string dataString { get; set; }
    public Folder folder { get; set; }
    public long godzina { get; set; }
    public string hourString { get; set; }
    public string nadawca { get; set; }
    public string odbiorca { get; set; }
    public string temat { get; set; }
    public string tresc { get; set; }
    public Użytkownik wlasciciel { get; set; }

    public HashSet<Zalacznik> zalaczniki { get; set; } = new HashSet<Zalacznik>();

    public Mail(string nadawca, string odbiorca, string temat, string tresc)
    {
        this.nadawca = nadawca;
        this.odbiorca = odbiorca;
        this.temat = temat;
        this.tresc = tresc;
    }

    public void printData()
    {
        Console.WriteLine($"Mail od: {nadawca} do: {odbiorca} | Temat: {temat}");
    }
}
public class Poczta
{
    public static void Main(string[] args)
    {
        Console.WriteLine("PROGRAM");

        Użytkownik user = new Użytkownik("Szermierz@2006", "Haslo24");

        Kontakt k1 = new Kontakt("Jan", "Nowak");
        k1.email = "Janusz@gmailqd";
        user.ksiazkaAdresowa.addKontakt(k1);

        user.wypiszDane();

        Folder skrzynkaOdbiorcza = new Folder("Odbiorcze", user);

        Mail nowyMail = new Mail("szef@firma.pl", "janusz@test.pl", "Pilne zadanie", "Proszę wdrożyć diagram klas na dzisiaj.");
        nowyMail.folder = skrzynkaOdbiorcza;
        nowyMail.wlasciciel = user;

        Zalacznik pdf = new Zalacznik("diagram.png", "http://storage.pl/diagram.png");
        nowyMail.zalaczniki.Add(pdf);

        nowyMail.printData();
        Console.WriteLine($"Liczba załączników w mailu: {nowyMail.zalaczniki.Count}");

        Console.ReadKey();
    }
}
