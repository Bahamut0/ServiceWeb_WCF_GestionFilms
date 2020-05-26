using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfProjetFilm.Model;
using WcfProjetFilm.ViewModel;

namespace WcfProjetFilm
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceFilm" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceFilm.svc ou ServiceFilm.svc.cs dans l'Explorateur de solutions et démarrez le débogage.

    public class ServiceFilm : IFilm
    {
        public List<film> GetListeFilm() => VMFilm.GetListeFilm();
        public int AjouterFilm(film f) => VMFilm.AjouterFilm(f);
        public int ModifierFilm(film f) => VMFilm.ModifFilm(f);
        public int SupprimerFilm(film f) => VMFilm.SuppFilm(f);
        public List<film> RechercherFilmParCritere(string critere) => VMFilm.RechercherParCritere(critere);
        public List<film> RechercherFilmParCritereEtSelection(string critere, string selection) => VMFilm.RechercherFilmParCritereEtSelection(critere, selection);


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        
    }
}
