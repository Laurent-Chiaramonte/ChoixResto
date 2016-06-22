using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChoixResto.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
            if (restoTrouve != null)
            {
                restoTrouve.Nom = nom;
                restoTrouve.Telephone = telephone;
                bdd.SaveChanges();
            }
        }

        public bool RestaurantExiste(string nom)
        {
            return bdd.Restos.Any(resto => string.Compare(resto.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public int AjouterUtilisateur(string nom, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Utilisateur utilisateur = new Utilisateur { Prenom = nom, MotDePasse = motDePasseEncode };
            bdd.Utilisateurs.Add(utilisateur);
            bdd.SaveChanges();
            return utilisateur.Id;
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

    }
}