using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourLinq
{
    class Vehicule
    {
        #region Static Fields
        private static Random rand = new Random();
        private static string[] colorList = new string[] { "Jaune", "Bleu", "Vert", "Turquoise", "Cerise" , "Rouge", "Gris Spaciale", "Or", "Maron", "Argent", "Mauve", "Orange", "Brique", "Poussin", "Taupe", "Prune"};
        public static string[] brandList = new string[] { "Renault", "Lamborghini", "Hyundai", "Toyota" };
        private static string[] modelListRenault = new string[] { "Twingo", "Clio", "Megane" };
        private static string[] modelListLamborghini = new string[] { "Aventador", "Diablo", "Hurakan" };
        private static string[] modelListHyundai = new string[] { "H30", "H50", "Coupé" };
        private static string[] modelListToyota = new string[] { "Corola", "Supra", "Aygo" };
        private static int[] doorNumbList = new int[] { 3, 5 };
        private static int[] placeNumbList = new int[] { 2, 5 };
        private static string[] rentalRangeList = new string[] { "Eco", "Standard", "Luxe" };

        #endregion
        #region Fields

        /// <summary>
        ///     Plaque d'immatriculation du véhicule
        /// </summary>
        private string licensePalte;
        /// <summary>
        ///     Couleur du véhicule
        /// </summary>
        private string color;
        /// <summary>
        ///     Kilométrage: nombre de kilomètre parcourue par le véhicule
        /// </summary>
        private int kilometerCount;
        /// <summary>
        ///     Puissance du moteur du véhicule
        /// </summary>
        private int motorPower;
        /// <summary>
        ///     marque du véhicule
        /// </summary>
        private string marque;
        /// <summary>
        ///     model du véhicule
        /// </summary>
        private string model;
        /// <summary>
        ///     date d'arrivée du véhicule dans le parc
        /// </summary>
        private DateTime arrivalDateTime;
        /// <summary>
        ///     Nombre de porte sur le véhicule
        /// </summary>
        private int doorNum;
        /// <summary>
        ///     Nombre de places assise dans le véhicule
        /// </summary>
        private int placeNum;
        /// <summary>
        ///     gamme du véhicule (eco(0,8), luxe(1,0), normale(1,2))
        /// </summary>
        private string rentalRange;
        /// <summary>
        ///     Prix location à journée du véhicule
        /// </summary>
        private double rentalBasePricePerDay;
        /// <summary>
        ///     Prix réel à la journée (prix loc * coef de la gamme)
        /// </summary>
        private double rangeCoef;

        #endregion


        #region Properties
        /// <summary>
        ///     Obtient ou définit la plaque d'immatriculation du véhicule
        /// </summary>
        public string LicensePalte { get => licensePalte; set => licensePalte = value; }
        /// <summary>
        ///     Obtient ou définit la couleur du véhicule
        /// </summary>
        public string Color { get => color; set => color = value; }
        /// <summary>
        ///     Obtient ou définit le nombre de kilometre parcouru par le véhicule
        /// </summary>
        public int KilometerCount { get => kilometerCount; set => kilometerCount = value; }
        /// <summary>
        ///     Obtient ou définit la puissance du moteur du véhicule
        /// </summary>
        public int MotorPower { get => motorPower; set => motorPower = value; }
        /// <summary>
        ///     Obtient ou définit la marque du véhicule
        /// </summary>
        public string Marque { get => marque; set => marque = value; }
        /// <summary>
        ///     Obtient ou définit le modele du véhicule
        /// </summary>
        public string Model { get => model; set => model = value; }
        /// <summary>
        ///     Obtient ou définit la date d'arrivée du véhicule dans le parc
        /// </summary>
        public DateTime ArrivalDateTime { get => arrivalDateTime; set => arrivalDateTime = value; }
        /// <summary>
        ///     Obtient ou définit le nombre de porte sur le véhicule
        /// </summary>
        public int DoorNum { get => doorNum; set => doorNum = value; }
        /// <summary>
        ///     Obtient ou définit le nombre de place dans le véhicule
        /// </summary>
        public int PlaceNum { get => placeNum; set => placeNum = value; }
        /// <summary>
        ///     Obtient ou définit la gamme du véhicule
        /// </summary>
        public string RentalRange { get => rentalRange; set => rentalRange = value; }
        /// <summary>
        ///     Obtient ou définit le prix location à journée
        /// </summary>
        public double RentalBasePricePerDay { get => rentalBasePricePerDay; set => rentalBasePricePerDay = value; }
        /// <summary>
        ///     Obtient ou définit le prix réel à la journée (prix loc * coef de la gamme)
        /// </summary>
        public double RangeCoef {
            get
            {
                switch (rentalRange)
                {
                    case "Eco": return 0.80;
                    case "Standard": default: return 1;
                    case "Luxe": return 1.20;
                }
            }
        }

        #endregion

        #region Methods

        public static List<Vehicule> GetVehicules(int _vehiculeCount)
        {
            List<Vehicule> result = new List<Vehicule>();
            for(int i = 0; i < _vehiculeCount; i++)
            {
                Vehicule vehicule = new Vehicule(true);
                result.Add(vehicule);
            }

            return result;
        }


        #endregion

        #region Constructors

        public Vehicule()
        {

        }

        public Vehicule(bool _generateRand = false)
        {
            
            if (_generateRand)
            {
                this.licensePalte = Guid.NewGuid().ToString();
                this.color = colorList[rand.Next(0, colorList.Length)];
                this.kilometerCount = rand.Next(100, 150000);
                this.motorPower = rand.Next(7, 40) * 10;
                int brandId = rand.Next(0, brandList.Length);
                this.marque = brandList[brandId];
                switch (brandId)
                {
                    case 0:
                    default:
                        this.model = modelListRenault[rand.Next(0, modelListRenault.Length)];
                        break;
                    case 1:
                        this.model = modelListLamborghini[rand.Next(0, modelListLamborghini.Length)];
                        break;
                    case 2:
                        this.model = modelListHyundai[rand.Next(0, modelListHyundai.Length)];
                        break;
                    case 3:
                        this.model = modelListToyota[rand.Next(0, modelListToyota.Length)];
                        break;
                }
                this.arrivalDateTime = DateTime.Now.Date.AddDays(rand.Next(-700, 0));
                this.doorNum = doorNumbList[rand.Next(0, doorNumbList.Length)];
                this.placeNum = placeNumbList[rand.Next(0, doorNumbList.Length)];
                this.rentalRange = rentalRangeList[rand.Next(0, rentalRangeList.Length)];
                this.rentalBasePricePerDay = rand.Next(10, 15);
              
                


            }

            
        }


        #endregion


        /**
         * Créer une classe qui est déterminée par : 
         * Immatriculation (Chaine)
         * Couleur(chaine)
         * Kilométrage(entier)
         * Puissance moteur (entier)
         * Marque (chaine)
         * Modèle (cahine)
         * Date d'entrée dans le parc (DateTime)
         * Nombre de porte (entier)
         * Nombre de place (entier)
         * Gamme (éco(0.8), luxe(1), standard(1.2)) (chaine)
         * Prix location à journée (double)
         * Prix réel à la journée (prix loc * coef de la gamme) (double)
         * 
         * */
    }
}
