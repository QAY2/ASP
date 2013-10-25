using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace bll
{
    /// <summary>
    /// clsUserCollection: Verwalten der Menge von clsUser-Objekten
    /// </summary>
 
    public class clsUserCollection
    {
        string _databaseFile;   // String zur Access-Datei, wird im Konstruktor initialisiert
 
        /// <summary>
        /// User-Collection Konstruktor 
        /// </summary>
        public clsUserCollection() 
        {   
            // hier wird der Pfad zur Access-Datei aus web.config gelesen
            _databaseFile = System.Configuration.ConfigurationManager.AppSettings["AccessFileName"];
        }

        /// <summary>
        /// Liest alle User aus der DB und gibt sie als Liste zurück
        /// </summary>
        /// <returns></returns>
        public List<clsUser> getAllUsers()
        {

            //Hier wird ein DB-Provider instanziiert und eine Verbindung zur Access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            //Hier wird unser Dataset aus der DB befüllt
            DataSet _myDataSet = _myProvider.GetStoredProcedureDSResult("QUGetAllUsers");

            //das DataSet enthält nur eine DataTable
            DataTable _myDataTable = _myDataSet.Tables[0];

            //Instantiieren eine Liste von User-Objekten
            List<clsUser> _myUserList = new List<clsUser>();

            //Lesen wir jetzt Zeile (DataRow) für Zeile
            foreach (DataRow _dr in _myDataTable.Rows)
            {
                //Wir füllen unsere Liste nach und nach mit neuen Usern
                clsUser _myUser = new clsUser();
                _myUser = DatarowToClsUser(_dr);
                _myUserList.Add(DatarowToClsUser(_dr));
            }
            return _myUserList;
        } //getAllUsers() 

        /// <summary>
        /// Update eines Userobjekts
        /// </summary>
        /// <param name="_User">User-Objekt mit geänderten Attributen</param>
        /// <returns>1 falls Update erfolgreich </returns>
        public int UpdateUser(clsUser _User)
        {

            //DB-Provider instanziiert und eine Verbindung zur access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            // Jetzt müssen wir erstmal die Übergabeparameter hinzufügen 
            // (Parameter in derselben Reihenfolge wie in der Access-Query)
            _myProvider.AddParam("Name", _User.Name, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myProvider.AddParam("Address", _User.Address, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myProvider.AddParam("Distance", _User.Distance, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("IsAdmin", _User.IsAdmin, DAL.DataDefinition.enumerators.SQLDataType.BOOL);
            _myProvider.AddParam("Password", _User.Password, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myProvider.AddParam("ID", _User.ID, DAL.DataDefinition.enumerators.SQLDataType.INT);

            //Ausführen und veränderte Zeilen zurückgeben
            int _changedSets = _myProvider.MakeStoredProcedureAction("QUUpdateUserById");

            return _changedSets;
        } //updateUser()

        /// <summary>
        /// Löschen eines Userobjekts
        /// </summary>
        /// <param name="_User">User-Objekt mit geänderten Attributen</param>
        /// <returns>1 falls delete erfolgreich </returns>
        public int DeleteUser(clsUser _User)
        {

            //DB-Provider instanziiert und eine Verbindung zur access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            // Übergabeparameter ID hinzufügen 
            _myProvider.AddParam("ID", _User.ID, DAL.DataDefinition.enumerators.SQLDataType.INT);

            //Ausführen und veränderte Zeilen zurückgeben
            int _changedSets = _myProvider.MakeStoredProcedureAction("QUDeleteUserById");

            return _changedSets;
        } //deleteUser()

        /// <summary>
        /// Insert eines Userobjekts
        /// </summary>
        /// <param name="_User">User-Objekt</param>
        /// <returns>1 falls Insert erfolgreich </returns>
        public int InsertUser(clsUser _User)
        {

            //DB-Provider instanziiert und eine Verbindung zur access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            // Jetzt müssen wir erstmal die Übergabeparameter hinzufügen 
            // (Parameter in derselben Reihenfolge wie in der Access-Query)
            _myProvider.AddParam("Name", _User.Name, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myProvider.AddParam("Address", _User.Address, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myProvider.AddParam("Distance", _User.Distance, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("IsAdmin", _User.IsAdmin, DAL.DataDefinition.enumerators.SQLDataType.BOOL);
            _myProvider.AddParam("Password", _User.Password, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);

            //Ausführen und veränderte Zeilen zurückgeben
            int _changedSets = _myProvider.MakeStoredProcedureAction("QUInsertUser");

            return _changedSets;
        } //insertUser()

        /// <summary>
        /// Gibt User mit gegebener ID zurück
        /// </summary>
        /// <param name="_id">ID des gesuchten Users</param>
        /// <returns>User-Objekt (oder NULL) </returns>
        public clsUser GetUserById(int _id)
        {

            //Hier wird ein DB-Provider instanziiert und eine Verbindung zur access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            //Jetzt müssen wir erstmal den Übergabeparameter hinzufügen
            _myProvider.AddParam("ID", _id, DAL.DataDefinition.enumerators.SQLDataType.INT);

            //Hier wird unser Dataset initialisiert
            DataSet _myDataSet = _myProvider.GetStoredProcedureDSResult("QUGetUserById");

            //füllen wir eine DataTable mit dem DataSet
            DataRow _dr = _myDataSet.Tables[0].Rows[0];

            //clsUser _myUser = new clsUser();
            //_myUser.ID = (int)_dr["UID"];
            //_myUser.Name = (String)_dr["UName"];
            //_myUser.Address = (String)_dr["UAddress"];
            //_myUser.Distance = Convert.ToInt32(_dr["UDistance"]);
            //_myUser.IsAdmin = (Boolean)_dr["UIsAdmin"];
            //_myUser.Password = (String)_dr["UPassword"];

            return DatarowToClsUser(_dr);
        } // getUserbyId()


        /// <summary>
        /// Zählt Anzahl Users, indem erst alle eingelesen werden und dann Länge der Liste zurückgegeben wird
        /// </summary>
        /// <param name="_id"></param>
        /// <returns>Anzahl Users</returns>
        public int CountUsers()
        {
            int _count;
            List<clsUser> _UserList;

            _UserList = getAllUsers();
            _count = _UserList.Count;

            return _count;
        } // CountUsers()


        /// <summary>
        /// DatarowToClsUser(): Transforms a DataRow into a User Object
        /// </summary>
        /// <param name="fieldName">DataRow</param>
        /// <returns>User-Objekt</returns>
        private clsUser DatarowToClsUser(DataRow _dr) {

            clsUser _myUser = new clsUser();
            clsHelper h = new clsHelper();
            //und hier die Daten nach Index
            _myUser.ID = (int)_dr["UID"];
            _myUser.Name = h.AddStringFieldValue(_dr, "UName");
            _myUser.Address = h.AddStringFieldValue(_dr, "UAddress");
            _myUser.Distance = h.AddIntFieldValue(_dr, "UDistance");
                _myUser.IsAdmin = h.AddBoolFieldValue(_dr, "UIsAdmin");
            _myUser.Password = h.AddStringFieldValue(_dr, "UPassword");
            return _myUser;
        } //DatarowToClsUser()
    }
}
