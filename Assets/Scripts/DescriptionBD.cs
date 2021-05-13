using System.Runtime.ConstrainedExecution;

namespace DefaultNamespace
{
    public class DescriptionBD
    {
        private static readonly string TITRE_HOG = "Hog, dirigeant du bataillon Dimitrov";
        // private static readonly string TITRE_MANUELA = "Manuela, reine du Royaume des Nuages";
        // private static readonly string TITRE_THOMAS_MALORY = "Thomas Malory, chevalier de 1er Rang";
        // private static readonly string TITRE_LA_LLORONA = "La llorona, jeune fille épeurée";
        
        private static readonly string DESC_HOG = "Hog est un sergent des brigades internationales, il était en train de former des soldats lorsqu’il fit kidnappé par ce monde parallèle. Hog n’était pas un très bon soldat, mais il était capable de crier fort et de tirer n’importe où. En espérant que ses facultés lui sauvent la vie.";
        // private static readonly string DESC_MANUELA = "Manuela sort elle-même d’un conte de fée, elle sait que, tout comme elle, les créatures de cet univers parallèle ne sont que fictions. Elle est prête à laisser de côté son rôle de reine pour affronter les défis imposés et survivre quoiqu’elle n’ait pas vraiment le choix…";
        // private static readonly string DESC_THOMAS_MALORY = "Sir Malory est le meilleur des chevaliers et détient du sang de Noble, il est persuadé qu’il a été choisi par son Dieu pour relever le défi, il se rendra vite compte que son Dieu n’a aucune incidence dans ce monde. Perdra-t-il la foi?";
        // private static readonly string DESC_LA_LLORONA = "La Llorona est triste d’avoir à vivre cette aventure. Elle ne le sait pas, mais son sanglot lui aidera à vaincre les ennemis quoique les chances qu’elle s’en sorte vivante sont minces. ";
       
        public static readonly string[][] TitresDescriptions =
        {
            new[] {TITRE_HOG, DESC_HOG},
            // new[] {TITRE_THOMAS_MALORY, DESC_THOMAS_MALORY},
            // new[] {TITRE_MANUELA, DESC_MANUELA},
            // new[] {TITRE_LA_LLORONA, DESC_LA_LLORONA}
        };
    }
}