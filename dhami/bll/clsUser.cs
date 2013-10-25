using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    /// <summary>
    /// clsUser: Klasse für Benutzer von Pizza
    /// nur Attribute, keine Methoden
    /// </summary>
    public class clsUser
    {
        // private Attribute
        private int _id;
        private string _name;
        private string _address;
        private int _distance;
        private bool _isAdmin;
        private string _password;


        // Constructor (mit default-Werten)
        public clsUser() {
            this._id = 0;
            this._name = "No Name";
            this._address = "No Address";
            this._distance = 999;
            this._isAdmin = false;
            this._password = "";
        }

        // properties
        /// <summary>
        /// ID des User
        /// </summary>
        public int ID {
            get { return _id; }
            set { _id = value;}     
        }

        /// <summary>
        /// Name des User
        /// </summary>
        public String Name
        {
            get { return _name; }
            set
            {
                if ((value != null) && (value != ""))
                    _name = value;
                else
                    _name = "No Name";
            }
        }

        /// <summary>
        /// Adresse des User
        /// </summary>
        public String Address
        {
            get { return _address; }
            set
            {   if ((value != null) && (value != ""))
                _address = value;
                else
                _address = "No Address";
            }
        }

        /// <summary>
        /// Distanz: Entfernung zum Pizza-Shop
        /// </summary>
        public int Distance
        {
            get { return _distance; }
            set
            {
                if (value < 0)
                    _distance = 0;
                else
                    _distance = value;
            }
        }

        /// <summary>
        /// True if Admin (may manage Users and Products)
        /// </summary>
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        /// <summary>
        /// Passwort (optional)
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {             
                    if (value == null)
                        _password = "";
                    else
                        _password = value;              
            }
        }
    } // clsUser
}
