using System;
using System.Text.Json;
namespace monPotager
{
    public class Commandes
    {
        private Potager _potager;

        public Commandes(Potager potager)
        {
            _potager = potager;
        }

        public void AjouterPlante()
        {
            try
            {
                Console.Write("Veuillez entrer le nom de la plante : ");
                string? nom = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nom)) throw new InvalidPlanteException("Le nom est vide, il ne peut pas être ajouté au potager.");

                Console.Write("Veuillez entrer le type de la plante (légume, fruit ou aromate): ");
                string? type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(type)) throw new InvalidPlanteException("Type invalide. La plante n'a pas pu être ajoutée au potager.");

                Console.Write("Veuillez entrer le stade de croissance de la plante (0 = jeune pousse 🌱, 1 = en croissance 🌿, 2 = plante mature 🌳): ");
                if (!int.TryParse(Console.ReadLine(), out int stade)) throw new FormatException("Stade de croissance invalide.");

                if (stade < 0 || stade > 2) throw new InvalidPlanteException("Le stade de croissance doit être compris entre 0 et 2.");

                Plante plante = type.ToLower() switch
                {
                    "légume" => new Legume(nom, stade),
                    "fruit" => new Fruit(nom, stade),
                    "aromate" => new Aromate(nom, stade),
                    _ => throw new InvalidPlanteException("\nType de plante invalide."),
                    
                };

                _potager.AjouterPlante(plante);
            }
            catch (InvalidPlanteException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur : {ex.Message}");
                Console.ResetColor();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur : {ex.Message}");
                Console.ResetColor();
            }
        }

        public void AfficherEspaceDisponible()
        {
            _potager.AfficherEspaceDisponible();
        }

        public void AfficherPotager()
        {
            _potager.AfficherPotager();
        }

        public void AfficherPlantes()
        {
            _potager.AfficherPlantes();
        }

        public void SupprimerPlante()
        {
            try
            {
                Console.Write("Veuillez entrer le nom de la plante à supprimer : ");
                string? nom = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrWhiteSpace(nom)) throw new InvalidPlanteException("\nLe nom ne peut pas être vide, veuillez entrer un nom valide.");
                Console.ResetColor();

                _potager.SupprimerPlante(nom);
            }
            catch (InvalidPlanteException ex)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur : {ex.Message}");
                Console.ResetColor();
            }
        }

        public void AfficherPlantesARecolter()
        {
            _potager.AfficherPlantesARecolter();
        }

        public void Arroser()
        {
            _potager.ArroserPlantes();
        }

        public void AfficherPlantesParType()
        {
            Console.Write("Veuillez entrer le type de plante à afficher (légume, fruit ou aromate) : ");
            string? type = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(type))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nType invalide.");
                Console.ResetColor();
                return;
            }

            _potager.AfficherPlantesParType(type);
        }

        public void RechercherPlantesParNom()
        {
            Console.Write("Veuillez entrer le nom de la plante à rechercher : ");
            string? nom = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nom))
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe nom n'est pas valide.");
                Console.ResetColor();
                return;
            }

            var plantePresente = _potager.Plantes.FirstOrDefault(p => p.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
            if (plantePresente != null)
            {   
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nPlante présente dans le potager : {plantePresente.Nom}, Type = {plantePresente.Type}, Stade = {plantePresente.Stade}");
                Console.ResetColor();
            }
            else
            {   
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nAucune plante trouvée avec le nom '{nom}'.");
                Console.ResetColor();
            }
        }

        public void ChargementFichier()
        {
            Console.Write("Veuillez entrer le chemin du fichier texte ou CSV : ");
            string? chemin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(chemin) || !File.Exists(chemin))
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe fichier n'a pas été trouvé.");
                Console.ResetColor();
                return;
            }

            try
            {
                var lignes = File.ReadAllLines(chemin);
                foreach (var ligne in lignes)
                {
                    if (_potager.Plantes.Count >= Potager.MaxPlantes)
                    {   
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nLe potager est plein. Impossible d'ajouter davantage de plantes.");
                        Console.ResetColor();
                        break;
                    }
                    var items = ligne.Split(",");
                    if (items.Length == 3 && int.TryParse(items[1], out int stade))
                    {
                        var plante = new Plante(items[0], stade, items[2]);
                        _potager.AjouterPlante(plante);
                    }
                    else
                    {   
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nLigne ignorée (format incorrect) : {ligne}");
                        Console.ResetColor();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLe fichier a été chargé avec succès.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur lors de la lecture du fichier : {ex.Message}");
                Console.ResetColor();
            }
        }

        public void SaveFichierTxt()
        {
            Console.Write("Veuillez entrer le chemin pour sauvegarder le fichier txt : ");
            string? chemin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(chemin))
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nChemin invalide.");
                Console.ResetColor();
                return;
            }
            try 
            {
                var lignes = _potager.Plantes.Select(p => $"{p.Nom}, {p.Type}, {p.Stade}");
                File.WriteAllLines(chemin,lignes);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nLe fichier a été sauvegardé avec succès.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur lors de la sauvegarde du fichier : {ex.Message}");
                Console.ResetColor();
            }
        }

        public void LectureJson()
        {
            Console.Write("Veuillez entrer le chemin du fichier JSON : ");
            string? chemin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(chemin) || !File.Exists(chemin))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe fichier n'a pas été trouvé.");
                Console.ResetColor();
                return;
            }
            try 
            {
                var json = File.ReadAllText(chemin);
                var plantes = JsonSerializer.Deserialize<List<Plante>>(json);

                if (plantes != null)
                {
                    foreach (var plante in plantes)
                    {
                        if (_potager.Plantes.Count >= Potager.MaxPlantes)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nLe potager est plein. Impossible d'ajouter davantage de plantes.");
                            Console.ResetColor();
                            break;
                        }
                        _potager.AjouterPlante(plante);
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nLe fichier Json a été chargé avec succès !");
                    Console.ResetColor();
                }
                else
                {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLe fichier Json n'est pas valide.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur lors de la lecture du fichier Json : {ex.Message}");
                Console.ResetColor();
            }
        }

        public void SaveFichierJson()
        {
            Console.Write("Entrez le chemin pour sauvegarder le fichier JSON : ");
            string? chemin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(chemin))
            {
                Console.WriteLine("Le chemin n'est pas valide.");
                return;
            }
            try
            {
                var json = JsonSerializer.Serialize(_potager.Plantes);
                File.WriteAllText(chemin, json);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nLe fichier Json a été sauvegardé avec succès ! ");               
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErreur lors de la sauvegarde du fichier Json : {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}