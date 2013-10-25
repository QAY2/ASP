using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace bll
{
    /// <summary>
    /// einige viel verwendete Methoden
    /// </summary>
    public class clsHelper
    {

        /// <summary>
        /// AddStringFieldValue(): String aus DataRow-Field, mit Handling von DBNull
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="fieldName">feldname</param>
        /// <returns>String</returns>
        public string AddStringFieldValue(DataRow row, string fieldName)
        {
            if ((row[fieldName]) != DBNull.Value)
                return (string)row[fieldName];
            else
                return "";
        }

        /// <summary>
        /// AddIntFieldValue(): String aus DataRow-Field, mit Handling von DBNull
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="fieldName">feldname</param>
        /// <returns>int</returns>
        public int AddIntFieldValue(DataRow row, string fieldName)
        {
            if ((row[fieldName]) != DBNull.Value)
                return Convert.ToInt32(row[fieldName]);
            else
                return 999;
        }


        /// <summary>
        /// AddIntFieldValue(): String aus DataRow-Field, mit Handling von DBNull
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="fieldName">feldname</param>
        /// <returns>bool</returns>
        public Boolean AddBoolFieldValue(DataRow row, string fieldName)
        {
            if ((row[fieldName]) != DBNull.Value)
                return (Boolean) row[fieldName];
            else
                return false;
        }
    }
}
