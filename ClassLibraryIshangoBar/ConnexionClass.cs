using System;

namespace ClassLibraryIshangoBar
{
    public class ConnexionClass
    {
        public static string connection;

        public static string SetConnexion()
        { 
            connection = @"Data Source=127.0.0.1;Initial Catalog=BaseIshangoBar;Integrated Security=false ;User ID=Ushindi; Password =Usher097";

            return connection;
        }
    }
}
