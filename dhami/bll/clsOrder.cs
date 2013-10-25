using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
    /// <summary>
    /// clsOrder: Bestellung
    /// </summary>
    public class clsOrder
    {
        // private Attribute
        private int _id;            // Order id, wird von DB vergeben

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _productId;     // product ordered

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private int _userId;        // user ordering

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }


        private DateTime _orderDate;    // order date

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        private int _orderSize;     // size in cm, liters, etc.

        public int OrderSize
        {
            get { return _orderSize; }
            set { _orderSize = value; }
        }
        private int _orderExtras;   // nr of extras (pizza)

        public int OrderExtras
        {
            get { return _orderExtras; }
            set { _orderExtras = value; }
        }


        private int _orderCount;    // nr of products ordered

        public int OrderCount
        {
            get { return _orderCount; }
            set { _orderCount = value; }
        }
        private double _orderSum;      // total amount of bill

        public double OrderSum
        {
            get { return _orderSum; }
            set { _orderSum = value; }
        }

        private bool _orderDelivery;    // true if delivery requested

        public bool OrderDelivery
        {
            get { return _orderDelivery; }
            set { _orderDelivery = value; }
        }

        private int _orderStorno;   // points to corresponding strono-transaction, -1 if no storno

        public int OrderStorno
        {
            get { return _orderStorno; }
            set { _orderStorno = value; }
        }

        /// <summary>
        /// Constructor (mit Default-Werten)
        /// </summary>
        public clsOrder()
        {
            this._id = 0;
            this._productId = 0;
            this._userId = 0;
            this._orderDate = Convert.ToDateTime("1.1.1999");
            this._orderSize = 0;
            this._orderExtras = 0;
            this._orderSum = 0.0;
            this._orderDelivery = false;
            this._orderStorno = -1;
        }

    } // clsOrder

    /// <summary>
    /// clsOrderExtended(): Erweiterung von clsOrder um Attzribute ProductName und UserName
    /// diese sind für die Anzeige benutzerfreundlicher als die zugehörigen IDs
    /// </summary>
    public class clsOrderExtended : clsOrder
    {
        private string _productName;    // Name of product ordered; not part of DB table, for viewing purposes, do not update

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private string _userName;      // user name ordering; not part of DB table, do not update

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// Constructor (mit Default-Werten)
        /// ruft zunächst Constructor der Oberklasse (clsOrder) auf und setzt dann die zusätzlichen Attribute
        /// </summary>
        public clsOrderExtended() : base()
        {
            this._productName = "";
            this._userName = "";
        }
        
    } // clsOrderExtended
}
