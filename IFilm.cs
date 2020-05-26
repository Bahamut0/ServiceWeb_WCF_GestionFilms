using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfProjetFilm.Model;

namespace WcfProjetFilm
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IFilm
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/AjouterFilm", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int AjouterFilm(film f);

        [WebInvoke(UriTemplate = "/ModifierFilm/", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        int ModifierFilm(film f);

        [WebInvoke(UriTemplate = "/SupprimerFilm/", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        int SupprimerFilm(film f);

        [WebGet(UriTemplate = "/ListeFilm/", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json)]
        [OperationContract]
        List<film> GetListeFilm();

        [WebGet(UriTemplate = "/recherche/activite/{critere}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<film> RechercherFilmParCritere(string critere);

        [WebGet(UriTemplate = "/recherche/activite/{critere}/{selection}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<film> RechercherFilmParCritereEtSelection(string critere, string selection);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
