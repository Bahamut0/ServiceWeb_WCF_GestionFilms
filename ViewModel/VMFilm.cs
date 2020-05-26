using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfProjetFilm.Model;

namespace WcfProjetFilm.ViewModel
{
    public class VMFilm : IDisposable
    {
        private static ProjetFilmEntities1 dtc;

        public VMFilm()
        {
            if (dtc == null) { dtc = new ProjetFilmEntities1(); }
        }

        //Affichage de la liste des films
        public static List<film> GetListeFilm()
        {
            using (ProjetFilmEntities1 dtc = new ProjetFilmEntities1())
            {
                return dtc.film.ToList();
            }
        }

        //Ajout
        public static int AjouterFilm( film f)
        {
            int _retour = 0;                        
            if (string.IsNullOrEmpty(f.Titre)) _retour = -1;
            if (string.IsNullOrEmpty(f.Synopsis)) _retour = -2;
            dtc.film.Add(f);
            _retour = dtc.SaveChanges();          
            return _retour;
        }

        //Modification
        public static int ModifFilm(film f)
        {
            int _retour = 0;
            film filmAModifier = dtc.film.Where(x => x.Id == f.Id).SingleOrDefault();
            filmAModifier.Titre = f.Titre;
            filmAModifier.Synopsis = f.Synopsis;
            filmAModifier.Affiche = f.Affiche;
            filmAModifier.genre = f.genre;
            filmAModifier.pays = f.pays;
            _retour = dtc.SaveChanges();          
            return _retour;
        }

        //Suppression via  objet
        public static int SuppFilm(film f)
        {
            int _retour = 0; 
                film filmASuprimer = dtc.film.Where(x => x.Id == f.Id).SingleOrDefault();
                dtc.film.Remove(filmASuprimer);
                _retour = dtc.SaveChanges();
            return _retour;
        }

        // Recherche
        public static List<film> RechercherParCritere(string critere)
        {
            List<film> _listARetourner = new List<film>();
            int _code = 0;
            critere = critere.ToLower();
            if (int.TryParse(critere, out _code))
            {
                if (_code != 0)
                {
                    _listARetourner = dtc.film.Where(x => x.Annee == _code).ToList();

                }
            }
            _listARetourner = dtc.film.Where(
                   a => a.Titre.ToLower().Contains(critere) || a.Synopsis.ToLower().Contains(critere)).ToList();

            return _listARetourner;

        }
        public static List<film> RechercherFilmParCritereEtSelection(string critere, string selection)
        {
            var listeARetourner = new List<film>();           
            switch (selection)
            {

                case "Titre":
                    listeARetourner = dtc.film.Where(x => x.Titre.ToLower().Contains(critere)).ToList();
                   
                    break;
                case "Synopsis":
                    listeARetourner = dtc.film.Where(x => x.Synopsis.ToLower().Contains(critere)).ToList();
                    
                    break;
                case "Année":
                    int _code;
                    if (int.TryParse(critere, out _code))
                    {
                        if (_code != 0)
                        {
                            listeARetourner = dtc.film.Where(x => x.Annee == _code).ToList();
                            
                        }
                    }
                    break;

                default:
                    break;
            }

            return listeARetourner;

        }
        public void Dispose()
        {
            dtc.Dispose();
        }
    }
}