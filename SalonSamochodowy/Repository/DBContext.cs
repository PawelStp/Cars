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
                Personalia_pracownikow = new RepositoryBase<Pracownik_personalia>(transaction, session);
                Samochody = new RepositoryBase<Samochod>(transaction, session);
                Samochody_fabryczne = new RepositoryBase<Samochod_fabryka>(transaction, session);
                Statusy_zamowienia = new RepositoryBase<Status_zamowienia>(transaction, session);
                Usterki = new RepositoryBase<Usterka>(transaction, session);
                Zakup = new RepositoryBase<Zakup>(transaction, session);
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
                var pracownik = new Pracownik() { Id_dzialu = 1, Od_kiedy = DateTime.Now, Do_kiedy = DateTime.Now.AddDays(2) };
                Pracownicy.Add(pracownik);
                transaction.Commit();
                Personalia_pracownikow.Add(new Pracownik_personalia
                {
                    Imie = "Pawel",
                    Nazwisko = "Stypulkowski",
                    Kod_pocztowy = "18-218",
                    Miejscowosc = "Sokoly",
                    Ulica = "Truskolasy Lachy",
                    Nr_domu = 19,
                    Nr_telefoonu = "518665682",
                    Pensja = 1000,
                    Id = pracownik.Id,
                    PESEL = "123123123",
                    Data_zatrudnienia = DateTime.Now
                });
            }
            private void DeleteAll()
            {
                session.Delete("from Pracownik_personalia");
                session.Flush();
                session.Delete("from Pracownik");
            }
        }
    }
}