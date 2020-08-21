using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryIshangoBar.Evenements
{
    public class EvenementDataAccessLayer
    {
        // Methode pour enregistrement un evenement 

        public int SaveEvent(EvenementModel eventModel, string path)
        {
            using (SqlConnection connection = new SqlConnection(ConnexionClass.SetConnexion())) 
            {
                connection.Open();

                string query = "INSERT INTO tEvenement"+
                                " (imageEvent, titleEvenent, descriptionEvent)"+
                                " VALUES(@imageEvent, @titleEvenent, @descriptionEvent)";

                SqlCommand commande = new SqlCommand(query, connection);

                commande.Parameters.AddWithValue("@imageEvent", path);
                commande.Parameters.AddWithValue("@titleEvenent", eventModel.TitreEvenement);
                commande.Parameters.AddWithValue("@descriptionEvent", eventModel.DescriptionEvenement);

                return commande.ExecuteNonQuery();
            }
        }

        // Methode pour get les evenements de la data base

        public IEnumerable<EvenementModel> GetLesEvents()
        {
            List<EvenementModel> listeEvenement = new List<EvenementModel>();

            using (SqlConnection connection = new SqlConnection(ConnexionClass.SetConnexion()))
            {
                string query = "SELECT * FROM tEvenement";

                SqlCommand commande = new SqlCommand(query, connection);
                commande.CommandType = CommandType.Text;

                connection.Open();

                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    EvenementModel eventModel = new EvenementModel();


                    eventModel.IdEvenement = Convert.ToInt32(reader["idEvent"]);
                    eventModel.ImageEvenement = reader["imageEvent"].ToString();
                    eventModel.TitreEvenement = reader["titleEvenent"].ToString();
                    eventModel.DescriptionEvenement = reader["descriptionEvent"].ToString();

                    listeEvenement.Add(eventModel);

                }
                connection.Close();
            }

            return listeEvenement;
        }

        // Methode pour recuperer le dernier element de la table

        public String GetDernierDUCodeEvent()
        {
            using (SqlConnection connexion = new SqlConnection(ConnexionClass.SetConnexion()))
            {
                connexion.Open();

                //string query = "SELECT        MAX(idEvent) AS MaxIdEvent FROM  tEvenement";
                string query = "SELECT        MAX(idEvent) AS [@idEvent] FROM tEvenement";


                SqlCommand commande = new SqlCommand(query, connexion);


                string NomImage;
                
                    NomImage = "Image" + (Convert.ToInt64(commande.ExecuteScalar()) + 1).ToString();

                    return NomImage;
                
                
            }
        }
    }
}
