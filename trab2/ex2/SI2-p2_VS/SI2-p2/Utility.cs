using System.Configuration;

namespace SI2_p2
{
    internal class Utility
    {
        //Get the connection string from App config file.
        internal static string GetConnectionString()
        {
            string returnValue = null;

			ConnectionStringSettings settings =
			ConfigurationManager.ConnectionStrings["SI2_p2.Properties.Settings.connString"];

			if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        internal static bool fatalNetworkException(int n)
        {
            return n == 232 || n == 233;
        }
    }
}
