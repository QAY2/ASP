using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DALObjects
{
    public class cObjConfiguration
    {
        private String _connectionString;

        public String ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private String _name;

        public String ConnectionName
        {
            get { return _name; }
            set { _name = value; }
        }

        private DAL.DataDefinition.enumerators.ConnectionType _connectionType;

        public DAL.DataDefinition.enumerators.ConnectionType ConnectionType
        {
            get { return _connectionType; }
            set { _connectionType = value; }
        }

        public cObjConfiguration(String _myConnectionName, String _myConnectionString, DAL.DataDefinition.enumerators.ConnectionType _myConnectionType)
        {
            this._name = _myConnectionName;
            this._connectionString = _myConnectionString;
            this._connectionType = _myConnectionType;
        }
	
    }
}
