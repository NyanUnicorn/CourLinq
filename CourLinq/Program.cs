using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourLinq
{
    class Program
    {

        
        static void Main(string[] args)
        {
            List<Vehicule> vehicules = Vehicule.GetVehicules(10);
            /*
            foreach (Vehicule voiture in Vehicule.GetVehicules(10))
            {
                Console.WriteLine($"{voiture.Marque} {voiture.Model} -- {voiture.Color} \n     places : {voiture.PlaceNum} \n     portes : {voiture.DoorNum} \n     kilometrage : {voiture.KilometerCount} \n     Plaque : {voiture.LicensePalte}" +
                    $"\n     PS:{voiture.MotorPower}");
            }
            */
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("1 - Afficher la liste complète");
                Console.WriteLine("2 - Afficher les voitures de marque...");
                Console.WriteLine("3 - Afficher les vehicules de la marque triées par km");
                Console.WriteLine("4 - Afficher le nombre de vehicules d'une marque donnée");
                Console.WriteLine("5 - Demander 2 Dates et afficher les vehicules entrés pendant période");
                Console.WriteLine("6 - Afficher le vehicule qui à le plus grand kilométrage");
                Console.WriteLine("7 - Afficher la moyenne du kilométrage des véhicules du parc");
                Console.WriteLine("8 - Afficher la moyenne du prix total / J des véhicules du parc");
                Console.WriteLine("9 - Afficher pour chaque marque le nombre de véhicules (trié par marque");
                Console.WriteLine("0 - Quitter");

                switch (readChoice())
                {
                    case "1":
                        displayVehicles(vehicules);
                        break;
                    case "2":
                        displayVehiclesOfBrand(vehicules);
                        break;
                    case "3":
                        displayVehiclesOfBrand(vehicules, 1);
                        break;
                    case "4":
                        displayVehiclesOfBrand(vehicules, 2);
                        break;
                    case "5":

                        break;
                    case "6":
                        displayVehiclesOfBrand(vehicules, 3);
                        break;
                    case "7":
                        displayVehiclesOfBrand(vehicules, 4);
                        break;
                    case "8":
                        displayVehiclesOfBrand(vehicules, 5);
                        break;
                    case "9":
                        displayVehiclesOfBrand(vehicules, 6);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        ///     Demande une entré pour le nom de la marque puis affiche une liste de vehicules de la marque demandé
        ///     0 = no mod;
        ///     1 = order by km count;
        ///     2 = number of vehicles;
        ///     3 = average of vehicle kilometer count in park
        ///     4 = kilométrage moyen
        ///     5 = prix moyen par jour
        ///     6 = nombre de voitur trié par marque
        /// </summary>
        /// <param name="_vehiculeList"></param>
        /// <param name="mod"></param>
        static void displayVehiclesOfBrand(List<Vehicule> _vehiculeList, int mod = 0)
        {
            Console.Clear();
            
            string marque;
            switch (mod)
            {
                case 0:
                default:
                    Console.WriteLine("Entrez le nom de la marque que vous cherchez");
                    marque = Console.ReadLine();
                    displayVehicles(_vehiculeList.Where((voiture) => voiture.Marque.ToLower().Contains(marque)).ToList());
                    break;
                case 1:
                    Console.WriteLine("Entrez le nom de la marque que vous cherchez");
                    marque = Console.ReadLine();
                    displayVehicles(_vehiculeList.Where((voiture) => voiture.Marque.ToLower().Contains(marque)).OrderBy((voiture) => voiture.KilometerCount).ToList());
                    break;
                case 2:
                    Console.WriteLine("Entrez le nom de la marque que vous cherchez");
                    marque = Console.ReadLine();
                    Console.WriteLine($"{_vehiculeList.Where((voiture) => voiture.Marque.ToLower().Contains(marque)).Count()}");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Le vehicule avec le plus grand kilométrage est : ");
                    displayVehicles(_vehiculeList.Where((voiture) => voiture.KilometerCount == _vehiculeList.Max(v => v.KilometerCount)).ToList());
                    break;
                case 4:
                    Console.WriteLine($"Moyenne Kilométrage : {_vehiculeList.Average(v => v.KilometerCount)}");
                    break;
                case 5:
                    Console.WriteLine($"Moyenne Prix par jour : {_vehiculeList.Average(v => v.RangeCoef)}");
                    break;
                case 6:
                    List<Vehicule> veh = new List<Vehicule>();

                    _vehiculeList.GroupBy(v => v.Marque).OrderBy(v => v.Key).ToList().ForEach(grp => Console.WriteLine($"{grp.Key}  {grp.Count()}"));
                   
                    Console.ReadKey();
                    break;
                
            }
        }

        /// <summary>
        ///     Affiche une liste de vahicules d'une liste donnée
        /// </summary>
        /// <param name="_vehiculeList"></param>
        static void displayVehicles(List<Vehicule> _vehiculeList)
        {
            Console.Clear();
            if (_vehiculeList.Count() > 0)
            {
                foreach (Vehicule voiture in _vehiculeList)
                {
                    displayVehicle(voiture);
                }
            }
            else
            {
                Console.WriteLine("Pas de vehicule de cette marque");
            }
            Console.ReadKey();
        }

        static void displayVehicle(Vehicule _v)
        {
            Console.WriteLine($"{_v.Marque} {_v.Model} -- {_v.Color} \n     places : {_v.PlaceNum} \n     portes : {_v.DoorNum} \n     kilometrage : {_v.KilometerCount} \n     Plaque : {_v.LicensePalte}" +
                       $"\n     PS:{_v.MotorPower}");
        }


        /// <summary>
        ///     Retourne la touche qui à été touché
        /// </summary>
        /// <returns>string</returns>
        private static string readChoice()
        {
            return Console.ReadKey().KeyChar.ToString();
        }
    }
}
