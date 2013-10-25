using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace DAL.DALObjects
{

    public abstract class dDataProvider
    {

        /// <summary>
        /// Füge einen Parameter hinzu
        /// </summary>
        /// <param name="_paramKey">Name des Parameters</param>
        /// <param name="_paramValue">ParameterValue</param>
        /// <param name="_paramDataType">Datentyp</param>
        public abstract void AddParam(String _paramKey, object _paramValue, DAL.DataDefinition.enumerators.SQLDataType _paramDataType);
        
        /// <summary>
        /// Konstruktor des Datenproviders
        /// </summary>
        /// <param name="_configuration"></param>
        public dDataProvider(DAL.DALObjects.cObjConfiguration _configuration) { }

        /// <summary>
        /// Erstellt die Rückgabe als Dataset
        /// </summary>
        /// <param name="_StoredProcedureName">Name der Stored Procedure</param>
        /// <returns>Das DataSet</returns>
        public abstract DataSet GetStoredProcedureDSResult(string _StoredProcedureName);
        /// <summary>
        /// Erstellt die Rückgabe als ArrayList mit gemappten Objekten
        /// </summary>
        /// <param name="_StoredProcedureName">Name der Stored Procedure</param>
        /// <returns>Die ArrayList</returns>
        public abstract ArrayList GetStoredProcedureALResult(string _StoredProcedureName);
        /// <summary>
        /// Führt eine Operation aus und gibt die Menge der veränderten Zellen zurück
        /// </summary>
        /// <param name="_StoredProcedureName"></param>
        /// <returns></returns>
        public abstract int MakeStoredProcedureAction(String _StoredProcedureName);
        /// <summary>
        /// Erstellt die Rückgabe als Array und gibt nur den ersten Datensatz als gemapptes Objekt aus
        /// </summary>
        /// <param name="_StoredProcedureName">Name der Stored Procedure</param>
        /// <returns>Das Array</returns>
        public abstract Array GetSingleStoredProcedureArrResult(String _StoredProcedureName);
        

    }
}
