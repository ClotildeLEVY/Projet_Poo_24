using System;
using System.Collections.Generic;
using System.Linq;

namespace monPotager
{
    public class Potager
    {   
        public const int MaxPlantes = 9;
        public List<Plante> Plantes {get; private set;} = new List<Plante>();

        public void AjouterPlante(Plante plante)
        {
            if (Plantes.Count >= MaxPlantes)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe potager est plein ! Il faut attendre la prochiane récolte pour libérer de l'espace.");
                Console.ResetColor();
                return;
            }

            Plantes.Add(plante);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nLa plante '{plante.Nom}' a été ajoutée au potager !");
            Console.ResetColor();
        }

        public void SupprimerPlante(string nom)
        {
            var planteASupprimer = Plantes.FirstOrDefault(p => p.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
            if (planteASupprimer != null)
            {
                Plantes.Remove(planteASupprimer);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nLa plante '{nom}' a été retirée du potager.");
                Console.ResetColor();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nLa plante '{nom}' n'a pas été trouvée dans le potager.");
                Console.ResetColor();
            }

        }

        public void ArroserPlantes()
        {
            if(Plantes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIl n'y a pas de plantes dans le potager.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n💧...Arrosage en cours...💧");
            //pour ajouter un peu de temps de latence pour l'arrosage 
            System.Threading.Thread.Sleep(1500);
            foreach (var plante in Plantes)
            {
                if (plante.Stade < 2)
                {
                    plante.PasserAuStadeSuperieur();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"La plante '{plante.Nom}' est passée au stade {plante.Stade} !");
                    Console.ResetColor();
                }
                else
                {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"La plante '{plante.Nom}' est déjà au stade maximal.");
                    Console.ResetColor();
                }
                System.Threading.Thread.Sleep(500);
            }
        }

        public void AfficherPlantes()
        {
            if (Plantes.Count == 0)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIl n'y a pas de plante, le potager est vide.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n---🌻 Liste des plantes du potager 🌻---");
            foreach (var plante in Plantes)
            {
                Console.WriteLine($"Nom : {plante.Nom}, Type : {plante.Type}, Stade : {plante.Stade}");           
            }
        }

        public void AfficherPlantesParType(string rechercheType)
        {
            var plantesFiltrees = Plantes.Where(p => p.Type.Equals(rechercheType, StringComparison.OrdinalIgnoreCase));
            if (!plantesFiltrees.Any())//si aucune plante de correspond au type recherché
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nIl n'y a aucune plante de type '{rechercheType}' dans le potager.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"\n--- Liste des plantes de type '{rechercheType}' ---");
            foreach (var plante in plantesFiltrees)
            {
                Console.WriteLine($"Nom : {plante.Nom}, Type : {plante.Type}, Stade : {plante.Stade}");
            }
        }

        public void AfficherPlantesARecolter()
        {
            var plantesMatures = Plantes.Where(p => p.Stade == 2).ToList();

            if(!plantesMatures.Any())
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAucune plante n'est prête à être récoltée.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n---🌾 Plantes prêtes à être récoltées 🌾---");
            foreach (var plante in plantesMatures)
            {
                Console.WriteLine($"Nom : {plante.Nom}, Type : {plante.Type}, Stade : {plante.Stade}");
            }
        }

        public void AfficherEspaceDisponible()
        {
            int placesLibres = MaxPlantes - Plantes.Count;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nIl reste {placesLibres} place(s) dans le potager.");
            Console.ResetColor();
        }

        public void AfficherPotager()
        {
            Console.WriteLine("\n---------🌱 POTAGER 🌱---------");

            int colonnes = 3;
            int rows = (int)Math.Ceiling((double)MaxPlantes / colonnes);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    int index = i * colonnes + j;

                    if (index < Plantes.Count)
                
                {
                    var plante = Plantes[index];

                    string emoji = plante.Nom.ToLower() switch
                    {
                        "carotte" => "🥕",
                        "épinard" => "🥬",
                        "chou" => "🥬",
                        "brocoli" => "🥦",
                        "tomate" => "🍅",
                        "aubergine" => "🍆",
                        "salade" => "🥬",
                        "oignon" => "🧅",
                        "échalote" => "🧅",
                        "ail" => "🧄",
                        "piment" => "🌶️ ",
                        "poivron" => "🫑",
                        "concombre" => "🥒",
                        "avocat" => "🥑",
                        "pomme de terre" => "🥔",
                        "patate douce" => "🍠",
                        "basilic" => "🌿",
                        "romarin" => "🌿",
                        "menthe" => "🌿",
                        "persil" => "🌿",
                        "thym" => "🌿",
                        "ciboulette" => "🌿",
                        "coriandre" => "🌿",
                        "origan" => "🌿",
                        "aneth" => "🌿",
                        "estragon" => "🌿",
                        "fraise" => "🍓",
                        "pastèque" => "🍉",
                        "melon" => "🍈",
                        "raisin" => "🍇",
                        "banane" => "🍌",
                        "cerise" => "🍒",
                        "citron" => "🍋",
                        "mangue" => "🥭",
                        "pêche" => "🍑",
                        "ananas" => "🍍",
                        "kiwi" => "🥝",
                        "orange" => "🍊",
                        "clémentine" => "🍊",
                        "pomme" => "🍎",
                        "poire" => "🍐",
                        "myrtille" => "🫐",
                        _ => "🌱",
                    };


                    Console.Write($"| {emoji}{plante.Nom} ");
                }
                else if (index < MaxPlantes)
                {
                    Console.Write("| 🟫 LIBRE");
                }
            }
            Console.WriteLine("|");
            }
        }
    }
}