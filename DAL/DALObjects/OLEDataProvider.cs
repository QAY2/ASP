using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace DAL.DALObjects
{
    public class OLEDataProvider : dDataProvider
    {

        private OleDbConnection _connection;
        private OleDbCommand _command;        
        private OleDbParameter _parameter;
        private OleDbDataAdapter _adapter;
        private DataSet _dataSet;

        /// <summary>
        /// Stellt eine Verbindung her
        /// Wirft im DEBUG-mode einen Fehler wenn Connection fehlschlägt
        /// </summary>
        /// <param name="_configuration"></param>
        public OLEDataProvider(cObjConfiguration _configuration) : base(_configuration)
        {
            this._command = new OleDbCommand();
            this._command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                this._connection = new OleDbConnection(_configuration.ConnectionString);
                this._connection.Open();                
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#else
                _connection = null;
#endif
            }
            this._command.Connection = this._connection;
        }

        private OleDbType GetDataType(DAL.DataDefinition.enumerators.SQLDataType _type)
        {

            OleDbType _locType;
            switch (_type)
            {
                case DAL.DataDefinition.enumerators.SQLDataType.CHAR:
                    _locType = OleDbType.Char;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.BINARY:
                    _locType = OleDbType.Binary;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.DATETIME:
                    _locType = OleDbType.Date;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.DOUBLE:
                    _locType = OleDbType.Double;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.FULLTEXT:
                    _locType = OleDbType.VarChar;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.INT:
                    _locType = OleDbType.Integer;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.VARCHAR:
                    _locType = OleDbType.VarChar;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.XML:
                    _locType = OleDbType.VarChar;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.BOOL:
                    _locType = OleDbType.Boolean;
                    break;
                default:
                    _locType = OleDbType.VarChar;
                    break;

            }

            return _locType;
        }

        /// <summary>
        /// Füge einen Parameter hinzu
        /// </summary>
        /// <param name="_paramKey">Name des Parameters</param>
        /// <param name="_paramValue">der Parameter</param>
        /// <param name="_paramDataType">Der Datentyp</param>
        public override void AddParam(string _paramKey, object _paramValue, DAL.DataDefinition.enumerators.SQLDataType _paramDataType)
        {
            try
            {
                this._parameter = new OleDbParameter(_paramKey, this.GetDataType(_paramDataType));
                this._parameter.Value = _paramValue;
                this._command.Parameters.Add(this._parameter);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#else
                //Make nothing
#endif
            }
        }

        public override System.Data.DataSet GetStoredProcedureDSResult(string _StoredProcedureName)
        {            
            this._command.CommandText = _StoredProcedureName;
            this._adapter = new OleDbDataAdapter();
            this._adapter.SelectCommand = this._command;
            this._dataSet = new DataSet();
            this._adapter.Fill(this._dataSet);
            this._connection.Close();
            return this._dataSet;
        }

        public override ArrayList GetStoredProcedureALResult(string _StoredProcedureName)
        {
            this._command.CommandText = _StoredProcedureName;
            this._adapter = new OleDbDataAdapter();
            this._adapter.SelectCommand = this._command;
            ArrayList _arrList = new ArrayList();
            OleDbDataReader _reader = this._command.ExecuteReader();
            while (_reader.Read())
            {
                object[] _values = new object[_reader.FieldCount];
                _reader.GetValues(_values);
                _arrList.Add(_values);
            }
            _reader.Close();
            this._connection.Close();
            return _arrList;
            
        }

        

        public override int MakeStoredProcedureAction(string _StoredProcedureName)
        {
            this._command.CommandText = _StoredProcedureName;
            int _num = this._command.ExecuteNonQuery();
            this._connection.Close();
            return _num;
            

        }

        public override Array GetSingleStoredProcedureArrResult(string _StoredProcedureName)
        {
            this._command.CommandText = _StoredProcedureName;
            this._adapter = new OleDbDataAdapter();
            this._adapter.SelectCommand = this._command;
            ArrayList _arrList = new ArrayList();
            OleDbDataReader _reader = this._command.ExecuteReader();
            object[] _values;
            if (_reader.HasRows)
            {

                _reader.Read();

                _values = new object[_reader.FieldCount];
                _reader.GetValues(_values);
            }
            else
            {
                 _values = new object[0];
            }
            
           
            return _values;
        }
    }
}
