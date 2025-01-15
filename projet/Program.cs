using monPotager;

namespace monPotager
{

    public class Program
    {
        static void Main()
        {
            Potager monPotager = new Potager();
            Commandes commandes = new Commandes(monPotager);

            while (true)
            {
                //Console.Clear();
                // Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- 🌱 Bienvenue dans le Potager Interactif 🌱 ---\n");
                // Console.ResetColor();
                Console.WriteLine("1.  Ajouter une plante");
                Console.WriteLine("2.  Afficher les plantes présentes dans le potager");
                Console.WriteLine("3.  Afficher les plantes par type");
                Console.WriteLine("4.  Supprimer une plante du potager");
                Console.WriteLine("5.  Arroser les plantes du potager");
                Console.WriteLine("6.  Afficher les plantes prêtes à être récoltées");
                Console.WriteLine("7.  Rechercher une plante par son nom");
                Console.WriteLine("8.  Charger des plantes depuis un fichier texte ou CSV");
                Console.WriteLine("9.  Sauvegarder des plantes dans un fichier texte");
                Console.WriteLine("10. Charger des plantes depuis un fichier JSON");
                Console.WriteLine("11. Sauvegarder des plantes dans un fichier JSON");
                Console.WriteLine("12. Afficher l'espace disponible dans le potager");
                Console.WriteLine("13. Afficher le potager");
                Console.WriteLine("14. Quitter");

                Console.Write("\nChoisissez une option : ");

                string? choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        commandes.AjouterPlante();
                        break;
                    case "2":
                        commandes.AfficherPlantes();
                        break;
                    case "3":
                        commandes.AfficherPlantesParType();
                        break;
                    case "4":
                        commandes.SupprimerPlante();
                        break;
                    case "5":
                        commandes.Arroser();
                        break;
                    case "6":
                        commandes.AfficherPlantesARecolter();
                        break;
                    case "7":
                        commandes.RechercherPlantesParNom();
                        break;
                    case "8":
                        commandes.ChargementFichier();
                        break;
                    case "9":
                        commandes.SaveFichierTxt();
                        break;
                    case "10":
                        commandes.LectureJson();
                        break;
                    case "11":
                        commandes.SaveFichierJson();
                        break;
                    case "12":
                        commandes.AfficherEspaceDisponible();
                        break;
                    case "13":
                        commandes.AfficherPotager();
                        break;
                    case "14":
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("À bientôt ! 🌱\n");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCette option n'est pas valide. Réessayez.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\n 📝 Appuyez sur une touche du clavier pour revenir au menu principal...");
                Console.ReadKey();
            }
        }
    }
}