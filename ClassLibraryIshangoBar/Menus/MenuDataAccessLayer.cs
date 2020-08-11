using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace ClassLibraryIshangoBar.Menus
{
    public class MenuDataAccessLayer
    {
        // Methode pour inserer les menus dans la base des donnees
        public int InsertMenu(MenuModel menuModel)
        {
            using (SqlConnection connexion = new SqlConnection(ConnexionClass.SetConnexion()))
            {
                connexion.Open();

                string query = "INSERT INTO tMenu" +
                               " (imageMenu, descriptionMenu, prixMenu)" +
                                 " VALUES(@imageMenu, @descriptionMenu, @prixMenu)";
                SqlCommand commande = new SqlCommand(query, connexion);

                commande.Parameters.AddWithValue("@imageMenu", "OK");
                commande.Parameters.AddWithValue("@descriptionMenu", menuModel.DescriptionMenu);
                commande.Parameters.AddWithValue("@prixMenu", menuModel.PrixMenu);

                return commande.ExecuteNonQuery();
            }
        }

        // Methode pour retrieve les menus dans la base des donnees

        public IEnumerable<MenuModel> GetLesMenus()
        {
            List<MenuModel> listeMenu = new List<MenuModel>();

            using (SqlConnection connection = new SqlConnection(ConnexionClass.SetConnexion()))
            {
                string query = "SELECT * FROM tMenu";

                SqlCommand commande = new SqlCommand(query, connection);
                commande.CommandType = CommandType.Text;

                connection.Open();

                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    MenuModel menuModel = new MenuModel();

                    menuModel.IdMenu = Convert.ToInt32(reader["idMenu"]);
                    menuModel.ImageMenu = reader["imageMenu"].ToString();
                    menuModel.DescriptionMenu = reader["descriptionMenu"].ToString();
                    menuModel.PrixMenu = reader["prixMenu"].ToString();

                    listeMenu.Add(menuModel);

                }
                connection.Close();
            }

            return listeMenu;
        }
    }
}
