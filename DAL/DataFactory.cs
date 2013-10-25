using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DAL
{
    /// <summary>
    /// Die DataFactory erstellt ein unabh�ngiges Datenobject
    /// </summary>
    public class DataFactory
    {
        private static Dictionary<String, DAL.DALObjects.cObjConfiguration> _configStack = new Dictionary<string, DAL.DALObjects.cObjConfiguration>();


        /// <summary>
        /// F�gt eine neue Konfiguration hinzu
        /// </summary>
        /// <param name="_configuration"></param>
        /// <returns>false wenn der Konfigurationsname schon existiert</returns>
        public static Boolean AddConfiguration(DAL.DALObjects.cObjConfiguration _configuration)
        {
            if (!_configStack.ContainsKey(_configuration.ConnectionName))
            {
                _configStack.Add(_configuration.ConnectionName, _configuration);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gibt eine Konfiguration zur�ck
        /// Wirft im DEBUG-mode einen Fehler wenn die Konfiguration nicht vorhanden
        /// Gibt ansonsten null zur�ck
        /// </summary>
        /// <param name="_configurationName">Ben�tigt den Namen der Konfiguration</param>
        /// <returns>Konfiguration</returns>
        public static DAL.DALObjects.cObjConfiguration GetConfiguration(string _configurationName)
        {
            try
            {
                return _configStack[_configurationName];
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#else
                return null;
#endif
            }

        }

        /// <summary>
        /// Gibt den Datenprovider zur�ck
        /// Der Typ des Datenproviders wird durch die Konfiguration bestimmt
        /// Wirft im DEBUG-mode eine Exception wenn die config fehlerhaft ist
        /// </summary>
        /// <param name="_provider"></param>
        /// <returns>Datenprovider</returns>
        public static DAL.DALObjects.dDataProvider GetProvider(String _provider)
        {
            try
            {
                DAL.DALObjects.cObjConfiguration _myconfig = GetConfiguration(_provider);
                DAL.DALObjects.dDataProvider _myProvider;
                if (_myconfig != null)
                {
                    switch (_myconfig.ConnectionType)
                    {
                        case DAL.DataDefinition.enumerators.ConnectionType.OLEDB:
                            _myProvider = new DAL.DALObjects.OLEDataProvider(_myconfig);
                            break;
                        case DAL.DataDefinition.enumerators.ConnectionType.ODBC:
                            _myProvider = new DAL.DALObjects.OLEDataProvider(_myconfig);
                            break;
                        case DAL.DataDefinition.enumerators.ConnectionType.SQLSSERVER:
                            _myProvider = new DAL.DALObjects.OLEDataProvider(_myconfig);
                            break;
                        default:
                            _myProvider = null;
                            break;

                    }

                    return _myProvider;
                }
                else
                {
#if DEBUG
                    throw new ApplicationException("no config");
#else
                return null;
#endif
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                throw new ApplicationException(ex.Message);
#else
                return null;
#endif
            }

        } // GetProvider()
        
        
        /// <summary>
        /// erzeuge und initialisiere einen Data provider f�r eine Access-DB
        /// </summary>
        /// <param name="_dbfilename">Pfadname zur Access Datei</param>
        /// <returns>Provider</returns>
        public static DAL.DALObjects.dDataProvider GetAccessDBProvider(String _dbfilename)
        {
            //Zuerst ben�tigen wir ein Konfigurationsobjekt f�r unsere Datenbank
            DAL.DALObjects.cObjConfiguration _myConfiguration = DAL.HelperClasses.ConfigurationHelper.GetAccessConfiguration(_dbfilename, "AccessDB");

            //F�gen wir jetzt unsere Konfiguration zum Datenprovider hinzu
            //Im Konfigurationsobjekt wird automatisch der Datenprovider ausgew�hlt
            DAL.DataFactory.AddConfiguration(_myConfiguration);

            //Lesen wir jetzt unseren Datenprovider, damit wird die Datenbank auch automatisch ge�ffnet
            //Der Name des Providers wird in dem Fall oben gleich in das Konfigurationsobjekt eingebaut.
            //Dadurch kann ohne Code�nderung ein fein gesteuerter Zugriff auf unterschiedlichste Datenprovider mit einem einzigen Quellcode und zentralisierter Steuerung
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetProvider("AccessDB");
            return _myProvider;
        } // GetAccessDBProvider()
    }
}
