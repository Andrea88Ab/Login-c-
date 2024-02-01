namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace GestioneAccessi
    {
        public class Utente
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public Utente(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        public class Accesso
        {
            public string Username { get; set; }
            public DateTime DataOra { get; set; }

            public Accesso(string username)
            {
                Username = username;
                DataOra = DateTime.Now;
            }
        }

        public class GestioneAccessi
        {
            private List<Utente> utenti;
            private List<Accesso> accessi;
            private Utente utenteCorrente;

            public GestioneAccessi()
            {
                utenti = new List<Utente>
            {
                new Utente("user1", "password1"), // Aggiungi qui utenti predefiniti
                // Aggiungi altri utenti se necessario
            };
                accessi = new List<Accesso>();
            }

            public bool Login(string username, string password)
            {
                var utente = utenti.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (utente != null)
                {
                    utenteCorrente = utente;
                    accessi.Add(new Accesso(username));
                    return true;
                }
                return false;
            }

            public void Logout()
            {
                utenteCorrente = null;
            }

            public void StampaAccessi()
            {
                foreach (var accesso in accessi)
                {
                    Console.WriteLine($"Accesso: {accesso.Username} - Data/Ora: {accesso.DataOra}");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                GestioneAccessi gestioneAccessi = new GestioneAccessi();
                bool uscita = false;

                while (!uscita)
                {
                    Console.WriteLine("======== Operazioni ==========");

                    Console.WriteLine("1. Login\n2. Logout\n3. Stampa Accessi\n4. Esci");
                    var scelta = Console.ReadLine();

                    switch (scelta)
                    {
                        case "1":
                            Console.Write("Inserisci Username: ");
                            var username = Console.ReadLine();
                            Console.Write("Inserisci Password: ");
                            var password = Console.ReadLine();

                            if (gestioneAccessi.Login(username, password))
                            {
                                Console.WriteLine("Login effettuato con successo!");
                            }
                            else
                            {
                                Console.WriteLine("Username o Password errati.");
                            }
                            break;
                        case "2":
                            gestioneAccessi.Logout();
                            Console.WriteLine("Logout effettuato.");
                            break;
                        case "3":
                            gestioneAccessi.StampaAccessi();
                            break;
                        case "4":
                            uscita = true;
                            break;
                        default:
                            Console.WriteLine("Scelta non valida.");
                            break;
                    }
                }
            }
        }
    }

}
