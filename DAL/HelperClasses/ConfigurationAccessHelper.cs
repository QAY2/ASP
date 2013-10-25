using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.HelperClasses
{
    /// <summary>
    /// Erstellt Configurationobjects zur Verwendung mit unterschiedlichen Datenbanken und Zugriffsarten (partial)
    /// </summary>
    public partial class ConfigurationHelper
    {

        /// <summary>
        /// Gibt ein Access ConfigurationObjekt zurück (normale Accessdatenbank)
        /// </summary>
        /// <param name="_file">Datenbankdatei</param>
        /// <param name="_user">Datenbankuser</param>
        /// <param name="_password">DatenbankPasswort</param>
        /// <param name="_connectionName">Name der Verbindung</param>
        /// <returns></returns>
        public static DAL.DALObjects.cObjConfiguration GetAccessConfiguration(String _file, String _user, String _password, String _connectionName)
        {
            String _connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + _file;
            // String _connString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + _file;
            return new DAL.DALObjects.cObjConfiguration(_connectionName, _connString, DAL.DataDefinition.enumerators.ConnectionType.OLEDB);
        }

        /// <summary>
        /// Gibt ein Access ConfigurationObjekt zurück unter Verwendung einer Systemdatenbank (Workgroup)
        /// </summary>
        /// <param name="_file">Datenbankdatei</param>
        /// <param name="_systemDatabase">Systemdatenbank</param>
        /// <param name="_connectionName">Name der Verbindung</param>
        /// <returns></returns>
        public static DAL.DALObjects.cObjConfiguration GetAccessConfiguration(String _file, String _systemDatabase, String _connectionName)
        {
            String _connString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+_file+"; Jet OLEDB:System Database="+_systemDatabase;
            return new DAL.DALObjects.cObjConfiguration(_connectionName, _connString, DAL.DataDefinition.enumerators.ConnectionType.OLEDB);
        }


        /// <summary>
        /// Gibt ein Access ConfigurationObjekt zurück zur Verwendung mit einer Passwortgesicherten Datenbank
        /// </summary>
        /// <param name="_file">Datenbankdatei</param>
        /// <param name="_passwort">Datenbankpasswort</param>
        /// <param name="_connectionName">Name der Verbindung</param>
        /// <returns></returns>
        public static DAL.DALObjects.cObjConfiguration GetAccessProtectedConfiguration(String _file, String _passwort, String _connectionName)
        {
            String _connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + _file;
            // String _connString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + _file;
            return new DAL.DALObjects.cObjConfiguration(_connectionName, _connString, DAL.DataDefinition.enumerators.ConnectionType.OLEDB);
        }

        /// <summary>
        /// Gibt ein Access ConfigurationObjekt zurück mit Zugriff auf eine lokale oder netzwerk-Datenbankdatei
        /// </summary>
        /// <param name="_file">Datenbankdatei</param>
        /// <param name="_connectionName">Name der Verbindung</param>
        /// <returns></returns>
        public static DAL.DALObjects.cObjConfiguration GetAccessConfiguration(String _file, String _connectionName)
        {
            String _connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + _file;
            // String _connString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + _file;
            return new DAL.DALObjects.cObjConfiguration(_connectionName, _connString, DAL.DataDefinition.enumerators.ConnectionType.OLEDB);
        }

        /// <summary>
        /// Gibt ein Access ConfigurationObjekt zurück mit Zugriff auf einen RemoteServer und einer dort gelegenen Datenbankdatei
        /// </summary>
        /// <param name="_file">Datenbankdatei</param>
        /// <param name="_remoteServer">RemoteServer IP</param>
        /// <param name="_connectionName">Name der Verbindung</param>
        /// <returns></returns>
        public static DAL.DALObjects.cObjConfiguration GetAccessRemoteConfiguration(String _file,String _remoteServer, String _connectionName)
        {
            String _connString = @"Provider=MS Remote; Remote Server="+_remoteServer+"; Remote Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+_file;
            return new DAL.DALObjects.cObjConfiguration(_connectionName, _connString, DAL.DataDefinition.enumerators.ConnectionType.OLEDB);
        }



    }
}
