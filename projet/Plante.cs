using System;

namespace monPotager
{
    public class Plante 
    {
        public string Nom {get; private set;}
        public string Type {get; private set;}
        public int Stade {get; private set;}

        public Plante(string nom, int stade)
        {
            if (string.IsNullOrWhiteSpace(nom)) throw new InvalidPlanteException("Le nom ne peut pas être vide.");
            // if (string.IsNullOrWhiteSpace(type)) throw new InvalidPlanteException("Le type ne peut pas être vide.");
            if (stade < 0 || stade > 2) throw new InvalidPlanteException("Le stade doit être compris entre 0 et 2.");

            Nom = nom;
            Type = "Inconnu";
            Stade = stade;
        }

        public Plante(string nom, int stade, string type) : this(nom, stade) 
        {
            if (string.IsNullOrWhiteSpace(type)) throw new InvalidPlanteException("Le type ne peut pas être vide.");
            Type = type;
        }

        public void PasserAuStadeSuperieur()
        {
            if (Stade < 2)
            {
                Stade++;
            }
        }

        public virtual void AfficherDetails()
        {
            Console.WriteLine($"Nom : {Nom}, Type : {Type}, Stade : {Stade}");
        }
    }

    public class Legume : Plante
    {
        public Legume(string nom, int stade) : base(nom, stade, "Légume")
        {
        }
    }

    public class Fruit : Plante
    {
        public Fruit(string nom, int stade) : base(nom, stade, "Fruit")
        {
        }
    }

    public class Aromate : Plante
    {
        public Aromate(string nom, int stade) : base(nom, stade, "Aromate")
        {
        }
    }
}