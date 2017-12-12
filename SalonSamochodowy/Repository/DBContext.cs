using NHibernate;
using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Repository
{
    public class DBContext
    {
        public class DbContext : IDisposable
        {
            private ISession session;
            private ITransaction transaction;

            public RepositoryBase<Dostawa> Dostawy { get; set; }
            public RepositoryBase<Dzial> Dzialy { get; set; }
            public RepositoryBase<Fabryka> Fabryki { get; set; }
            public RepositoryBase<Klient> Klienci { get; set; }
            public RepositoryBase<Naprawa> Naprawy { get; set; }
            public RepositoryBase<Pracownik> Pracownicy { get; set; }
            public RepositoryBase<Pracownik_personalia> Personalia_pracownikow { get; set; }
            public RepositoryBase<Samochod> Samochody { get; set; }
            public RepositoryBase<Samochod_fabryka> Samochody_fabryczne { get; set; }
            public RepositoryBase<Status_zamowienia> Statusy_zamowienia { get; set; }
            public RepositoryBase<Usterka> Usterki { get; set; }
            public RepositoryBase<Zakup> Zakup { get; set; }
            public RepositoryBase<Zamowienie> Zamowienia { get; set; }

            public DbContext()
            {
                session = NHibernateSession.OpenSession();
                transaction = session.BeginTransaction();

                InitRepositories();
            }

            private void InitRepositories()
            {
                Dostawy = new RepositoryBase<Dostawa>(transaction, session);
                Dzialy = new RepositoryBase<Dzial>(transaction, session);
                Fabryki = new RepositoryBase<Fabryka>(transaction, session);
                Klienci = new RepositoryBase<Klient>(transaction, session);
                Naprawy = new RepositoryBase<Naprawa>(transaction, session);
                Pracownicy = new RepositoryBase<Pracownik>(transaction, session);
                Samochody = new RepositoryBase<Samochod>(transaction, session);
                Samochody_fabryczne = new RepositoryBase<Samochod_fabryka>(transaction, session);
                Usterki = new RepositoryBase<Usterka>(transaction, session);
                Zakup = new RepositoryBase<Zakup>(transaction, session);
                Zamowienia = new RepositoryBase<Zamowienie>(transaction, session);
            }

            public void SaveChanges()
            {
                transaction.Commit();
                Dispose();
            }

            public void Dispose()
            {
                transaction.Dispose();
            }


            public void InitData()
            {
                DeleteAll();
                var dzialAdministracji = new Dzial() { Nazwa = "Administracja" };
                var dzialNaprawy = new Dzial() { Nazwa = "Mechanika" };
                Dzialy.Add(dzialAdministracji);
                Dzialy.Add(dzialNaprawy);

                var pracownikPawel = new Pracownik() { Id_dzialu = dzialAdministracji.Id,Imie="Pawel", Nazwisko="Stypulkowski", Stanowisko = "Prezes", PESEL="95959", Data_zatrudnienia = DateTime.Now.AddDays(-10), Password=Crypto.Hash("Bigos123"), Role="Admin" };
                var pracownikKacper = new Pracownik() { Id_dzialu = dzialNaprawy.Id, Imie = "Kacper", Nazwisko = "Swislocki", Stanowisko = "Slugus", PESEL="87878", Data_zatrudnienia=DateTime.Now.AddDays(-1), Password = Crypto.Hash("Bigos123"), Role = "Pracownik" };
                Pracownicy.Add(pracownikPawel);
                Pracownicy.Add(pracownikKacper);

                var klientTybor = new Klient() { Imie = "Marcin", Nazwisko = "Tyborowski", Kod_pocztowy = "20-200", Miejscowosc = "Lapy", Nr_domu = 10, Ulica = "Lawendowa", PESEL = "969696", Nr_telefonu = "515151515"};
                var klientSado = new Klient() { Imie = "Michal", Nazwisko = "Sadowski", Kod_pocztowy = "20-220", Miejscowosc = "Choroszcz", Nr_domu = 20, Ulica = "Zlotoria",  PESEL = "96969697", Nr_telefonu = "515123235" };
                Klienci.Add(klientTybor);
                Klienci.Add(klientSado);

                var fabrykaAudi = new Fabryka() { Nazwa = "Audi", Nr_telefonu = "4764214", Adres="Niemcy 10" };
                var fabrykaToyoty = new Fabryka() { Nazwa = "Toyota", Nr_telefonu = "42141212", Adres="Japonia 20"};
                Fabryki.Add(fabrykaAudi);
                Fabryki.Add(fabrykaToyoty);

                var autoAudi = new Samochod_fabryka() { Id_fabryki = fabrykaAudi.Id, Marka = "Audi", Model = "A", Moc_silnika = 1, Pojemnosc_silnika = (float)1.00, Typ_wyposazenia = "tak", Cena_fabryka = 25000 };
                var autoToyota = new Samochod_fabryka() { Id_fabryki = fabrykaToyoty.Id, Marka = "Toyota", Model = "T", Moc_silnika = 2, Pojemnosc_silnika = (float)2.00, Typ_wyposazenia = "tak", Cena_fabryka = 35000 };
                Samochody_fabryczne.Add(autoAudi);
                Samochody_fabryczne.Add(autoToyota);

                var zamowienieAudi = new Zamowienie() { Id_pracownika = pracownikPawel.Id, Id_samochodu_fabryka = autoAudi.Id, Ilosc_zamowionych = 50, Ilosc_dostarczonych = 10, Obecny_status = "Niezrealizowane", Data_zamowienia = DateTime.Now.AddDays(-2) };
                var zamowienieToyoty = new Zamowienie() { Id_pracownika = pracownikPawel.Id, Id_samochodu_fabryka = autoToyota.Id, Ilosc_zamowionych = 100, Ilosc_dostarczonych = 100, Obecny_status = "Zrealizowane", Data_zamowienia = DateTime.Now.AddDays(-2) };
                Zamowienia.Add(zamowienieAudi);
                Zamowienia.Add(zamowienieToyoty);

                var dostawaAudi = new Dostawa() { Id_zamowienia = zamowienieAudi.Id, Data_dostawy = DateTime.Now.AddDays(-1) };
                var dostawaToyoty = new Dostawa() { Id_zamowienia = zamowienieToyoty.Id, Data_dostawy = DateTime.Now.AddDays(-1) };
                Dostawy.Add(dostawaAudi);
                Dostawy.Add(dostawaToyoty);

                var samochoduAudi = new Samochod() { Id_dostawy = dostawaAudi.Id, Cena = 30000, Marka = autoAudi.Marka, Model = autoAudi.Model, Moc_silnika = autoAudi.Moc_silnika, Pojemnosc_silnika = autoAudi.Pojemnosc_silnika, Typ_wyposazenia = "tak", Data_produkcji = DateTime.Now.AddYears(-2)};
                var samochodToyota = new Samochod() { Id_dostawy = dostawaToyoty.Id, Cena = 30000, Marka = autoToyota.Marka, Model = autoToyota.Model, Moc_silnika = autoToyota.Moc_silnika, Pojemnosc_silnika = autoToyota.Pojemnosc_silnika, Typ_wyposazenia = "tak", Data_produkcji = DateTime.Now.AddYears(-2)};
                Samochody.Add(samochoduAudi);
                Samochody.Add(samochodToyota);

                var usterka1 = new Usterka() { Koszt_czesci = 200, Koszt_robocizny = 100, Ogolny_koszt = 300, Nazwa = "Urw" };
                var usterka2 = new Usterka() { Koszt_czesci = 200, Koszt_robocizny = 200, Ogolny_koszt = 400, Nazwa = "Ura" };
                Usterki.Add(usterka1);
                Usterki.Add(usterka2);

                var naprawaToyoty = new Naprawa() { Id_pracownika = pracownikKacper.Id, Id_usterki = usterka1.Id, Id_samochodu = samochodToyota.Id };
                var naprawaAudi = new Naprawa() { Id_pracownika = pracownikKacper.Id, Id_usterki = usterka2.Id, Id_samochodu = samochoduAudi.Id };
                Naprawy.Add(naprawaToyoty);
                Naprawy.Add(naprawaAudi);

                var zakupToyoty = new Zakup() { Id_klienta = klientSado.Id, Id_pracownika = pracownikPawel.Id, Id_samochodu = samochodToyota.Id, Data_zakupu = DateTime.Now };
                var zakupAudi = new Zakup() { Id_klienta = klientTybor.Id, Id_pracownika = pracownikPawel.Id, Id_samochodu = samochoduAudi.Id, Data_zakupu = DateTime.Now };
                Zakup.Add(zakupToyoty);
                Zakup.Add(zakupAudi);
            }
            private void DeleteAll()
            {
                session.Delete("from Zakup");
                session.Delete("from Naprawa");
                session.Delete("from Usterka");
                session.Delete("from Samochod");
                session.Delete("from Dostawa");
                session.Delete("from Zamowienie");
                session.Delete("from Samochod_fabryka");
                session.Delete("from Fabryka");
                session.Delete("from Pracownik");
                session.Delete("from Dzial");
                session.Delete("from Klient");
            }
        }
    }
}