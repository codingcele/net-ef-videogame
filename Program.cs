using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (VideogameContext db = new VideogameContext())
            {
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("Digita ins per inserire un nuovo videogioco.");
                    Console.WriteLine("Digita id per cercare un videogioco per id.");
                    Console.WriteLine("Digita str per cercare i videogiochi che contencono una stringa nel nome.");
                    Console.WriteLine("Digita d per eliminare un videogioco per id.");
                    Console.WriteLine("Digita exit per chiudere il programma.");

                    // Leggi l'input dell'utente dalla console
                    string input = Console.ReadLine();

                    if (input == "exit")
                    {
                        Console.WriteLine("Il programma è stato chiuso.");
                        break;
                    }

                    // Confronta l'input dell'utente con le parole chiave e esegui il comando corrispondente
                    switch (input)
                    {
                        case "ins":
                            Console.Write("Inserisci il nome del videogioco: ");
                            // Leggi il nome del film digitato dall'utente
                            string nome = Console.ReadLine();
                            Console.Write("Inserisci una descrizione del videogioco: ");
                            // Leggi la descrizione del film del film digitata dall'utente
                            string overview = Console.ReadLine();

                            Videogame newVideogame = new Videogame { Name = nome, Overview = overview };
                            db.Add(newVideogame);
                            db.SaveChanges();

                            Console.WriteLine("Videogioco creato correttamente!");
                            break;

                        case "id":
                            Console.Write("Inserisci l'id: ");
                            int id = int.Parse(Console.ReadLine());
                            Videogame byIdVideogame = db.Videogames.SingleOrDefault(videogame => videogame.VideogameId == id);
                            if (byIdVideogame == null)
                            {
                                Console.WriteLine($"Non è presente nessun videogioco con id {id}");
                            }
                            else
                            {
                                Console.WriteLine($"Il videogioco trovato è: {byIdVideogame.Name}");
                                Console.WriteLine($"Descrizione: {byIdVideogame.Overview}");
                            }
                            break;
                        case "str":
                            Console.Write("Inserisci una stringa per cercare un videogioco per nome: ");
                            string searchString = Console.ReadLine();
                            var videogames = db.Videogames.Where(videogame => videogame.Name.Contains(searchString));
                            if (videogames.Count() == 0)
                            {
                                Console.WriteLine($"Nessun videogioco trovato con la stringa '{searchString}' nel titolo");
                            }
                            else
                            {
                                Console.WriteLine($"Trovati {videogames.Count()} videogioco/i con la stringa '{searchString}' nel titolo:");
                                foreach (var videogame in videogames)
                                {
                                    Console.WriteLine($"- {videogame.Name} (id: {videogame.VideogameId})");
                                }
                            }
                            break;
                        case "d":
                            Console.Write("Inserisci l'id del videogioco da eliminare: ");
                            int idDelete = int.Parse(Console.ReadLine());

                            // Cerca il videogioco nel database
                            Videogame videogameToDelete = db.Videogames.Find(idDelete);
                            db.SaveChanges();

                            // Se il videogioco non viene trovato, stampa un messaggio e termina l'esecuzione
                            if (videogameToDelete == null)
                            {
                                Console.WriteLine($"Il videogioco con id {idDelete} non è stato trovato nel database.");
                                return;
                            }

                            // Rimuovi il videogioco dal database e salva i cambiamenti
                            db.Videogames.Remove(videogameToDelete);
                            db.SaveChanges();

                            // Stampa un messaggio di conferma
                            Console.WriteLine($"Il videogioco con id {idDelete} è stato eliminato dal database.");

                            break;
                        default:
                            // Se l'input non corrisponde a nessuna delle parole chiave, mostra un messaggio di errore
                            Console.WriteLine("Parola non riconosciuta");
                            break;
                    }
                }

                // Create
                //Videogame newVideogame = new Videogame { Name = "Avengers", Overview = "Sggdhsh ddksk." };
                //db.Add(newVideogame);

                //Videogame newGame = new Videogame { Name = "Chiedimi se sono felice", Overview = "Hdshv disds." };
                //db.Add(newGame);

                //Videogame Game = new Videogame { Name = "Hola", Overview = "dsdsdsds." };
                //db.Add(Game);
                //db.SaveChanges();

            }
        }
    }
}