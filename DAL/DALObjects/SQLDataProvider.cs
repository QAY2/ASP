using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DAL.DALObjects
{
    public class SQLDataProvider : dDataProvider
    {

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlParameter _parameter;
        private SqlDataAdapter _adapter;
        private DataSet _dataSet;

        /// <summary>
        /// Stellt eine Verbindung her
        /// Wirft im DEBUG-mode einen Fehler wenn Connection fehlschlägt
        /// </summary>
        /// <param name="_configuration"></param>
        public SQLDataProvider(cObjConfiguration _configuration)
            : base(_configuration)
        {
            this._command = new SqlCommand();
            this._command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                this._connection = new SqlConnection(_configuration.ConnectionString);
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

        private SqlDbType GetDataType(DAL.DataDefinition.enumerators.SQLDataType _type)
        {
            SqlDbType _locType;
            switch (_type)            

            {


                case DAL.DataDefinition.enumerators.SQLDataType.CHAR:
                    _locType = SqlDbType.Char;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.BINARY:
                    _locType = SqlDbType.Binary;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.DATETIME:
                    _locType = SqlDbType.Date;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.DOUBLE:
                    _locType = SqlDbType.Float;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.FULLTEXT:
                    _locType = SqlDbType.VarChar;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.INT:
                    _locType = SqlDbType.Int;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.VARCHAR:
                    _locType = SqlDbType.VarChar;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.XML:
                    _locType = SqlDbType.VarChar;
                    break;
                case DAL.DataDefinition.enumerators.SQLDataType.BOOL:
                    _locType = SqlDbType.Bit;
                    break;
                default:
                    _locType = SqlDbType.VarChar;
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
                this._parameter = new SqlParameter(_paramKey, this.GetDataType(_paramDataType));
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
            this._adapter = new SqlDataAdapter();
            this._adapter.SelectCommand = this._command;
            this._dataSet = new DataSet();
            this._adapter.Fill(this._dataSet);
            this._connection.Close();
            return this._dataSet;
        }

        public override ArrayList GetStoredProcedureALResult(string _StoredProcedureName)
        {
            this._command.CommandText = _StoredProcedureName;
            this._adapter = new SqlDataAdapter();
            this._adapter.SelectCommand = this._command;
            ArrayList _arrList = new ArrayList();
            SqlDataReader _reader = this._command.ExecuteReader();
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
            this._adapter = new SqlDataAdapter();
            this._adapter.SelectCommand = this._command;
            ArrayList _arrList = new ArrayList();
            SqlDataReader _reader = this._command.ExecuteReader();
            _reader.Read();

            object[] _values = new object[_reader.FieldCount];
            _reader.GetValues(_values);



            return _values;
        }
    }
}