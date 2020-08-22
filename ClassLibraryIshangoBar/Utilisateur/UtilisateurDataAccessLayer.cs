using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static ClassLibraryIshangoBar.Utilisateur.UtilisateurModel;

namespace ClassLibraryIshangoBar.Utilisateur
{
    public class UtilisateurDataAccessLayer
    {

        public partial class tUser
        {
            public int IdUser { get; set; }
            [Required(ErrorMessage ="Entrez le nom d'utilisateur svp!!!")]
            public string UserName { get; set; }
            [Required(ErrorMessage ="Entrez le mot de passe svp!!!")]
            public string PassWord { get; set; }
        }


        //Methode pour select les utilisateurs

        public tUser GetUsers(string username, string password)
        {
            using (SqlConnection Conn = new SqlConnection(ConnexionClass.SetConnexion()))

                try
                {
                    Conn.Open();
                    tUser objCust = new tUser();
                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tUser where UserName = @username and PassWord = @password";
                    //where UserName = @a and PassWord = @b
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@username", username);
                    objCommand.Parameters.AddWithValue("@password", password);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        objCust.IdUser = Convert.ToInt32(_Reader["IdUser"].ToString());
                        objCust.UserName = _Reader["UserName"].ToString();
                        objCust.PassWord = _Reader["PassWord"].ToString();
                    }

                    return objCust;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
                    }
                }
        }
    }
}
