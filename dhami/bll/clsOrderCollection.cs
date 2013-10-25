using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace bll
{
    /// <summary>
    /// clsOrderCollection: Verwalten von Order-Objekten und OrderExtended Objekten
    /// </summary>
    public class clsOrderCollection
    {
        string _databaseFile;   // String zur Access-Datei, wird im Konstruktor initialisiert
 
        /// <summary>
        /// Order-Collection Konstruktor 
        /// </summary>
        public clsOrderCollection() 
        {   
            // hier wird der Pfad zur Access-Datei aus web.config gelesen
            _databaseFile = System.Configuration.ConfigurationManager.AppSettings["AccessFileName"];
        }

        /// <summary>
        /// Liest alle Order aus der DB und gibt sie als Liste zurück
        /// </summary>
        /// <returns></returns>
        public List<clsOrder> getAllOrders()
        {

            //Hier wird ein DB-Provider instanziiert und eine Verbindung zur Access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            //Hier wird unser Dataset aus der DB befüllt
            DataSet _myDataSet = _myProvider.GetStoredProcedureDSResult("QOGetAllOrders");

            //das DataSet enthält nur eine DataTable
            DataTable _myDataTable = _myDataSet.Tables[0];

            //Instantiieren eine Liste von Order-Objekten
            List<clsOrder> _myOrderList = new List<clsOrder>();

            //Lesen wir jetzt Zeile (DataRow) für Zeile
            foreach (DataRow _dr in _myDataTable.Rows)
            {
                //Wir füllen unsere Liste nach und nach mit neuen Ordern
                _myOrderList.Add(DatarowToclsOrder(_dr));
            }
            return _myOrderList;
        } //getAllOrders() 

        /// <summary>
        /// Liest alle OrderExtended aus der DB und gibt sie als Liste zurück
        /// </summary>
        /// <returns></returns>
        public List<clsOrderExtended> getAllOrdersExtended()
        {

            //Hier wird ein DB-Provider instanziiert und eine Verbindung zur Access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            //Hier wird unser Dataset aus der DB befüllt
            DataSet _myDataSet = _myProvider.GetStoredProcedureDSResult("QOGetAllOrders");

            //das DataSet enthält nur eine DataTable
            DataTable _myDataTable = _myDataSet.Tables[0];

            //Instantiieren eine Liste von Order-Objekten
            List<clsOrderExtended> _myOrderList = new List<clsOrderExtended>();

            //Lesen wir jetzt Zeile (DataRow) für Zeile
            foreach (DataRow _dr in _myDataTable.Rows)
            {
                //Wir füllen unsere Liste nach und nach mit neuen Ordern
                clsOrderExtended _myOrder = new clsOrderExtended();
                _myOrder = DatarowToclsOrder(_dr);
                _myOrderList.Add(DatarowToclsOrder(_dr));
            }
            return _myOrderList;
        } //getAllOrdersExtended() 

        /// <summary>
        /// Insert eines Orderobjekts
        /// </summary>
        /// <param name="_Order">Order-Objekt</param>
        /// <returns>1 falls Insert erfolgreich </returns>
        public int InsertOrder(clsOrder _Order)
        {

            //DB-Provider instanziiert und eine Verbindung zur access-Datenbank aufgebaut
            DAL.DALObjects.dDataProvider _myProvider = DAL.DataFactory.GetAccessDBProvider(_databaseFile);

            // Jetzt müssen wir erstmal die Übergabeparameter hinzufügen 
            // (Parameter in derselben Reihenfolge wie in der Access-Query)
            _myProvider.AddParam("UserId", _Order.UserId, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("ProduktId", _Order.ProductId, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("Date", _Order.OrderDate, DAL.DataDefinition.enumerators.SQLDataType.DATETIME);
            _myProvider.AddParam("Size", _Order.OrderSize, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("Extras", _Order.OrderExtras, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("Count", _Order.OrderCount, DAL.DataDefinition.enumerators.SQLDataType.INT);
            _myProvider.AddParam("Sum", _Order.OrderSum, DAL.DataDefinition.enumerators.SQLDataType.DOUBLE);
            _myProvider.AddParam("Delivery", _Order.OrderDelivery, DAL.DataDefinition.enumerators.SQLDataType.BOOL);
            _myProvider.AddParam("Storno", _Order.OrderStorno, DAL.DataDefinition.enumerators.SQLDataType.INT);
            //Ausführen und veränderte Zeilen zurückgeben
            int _changedSets = _myProvider.MakeStoredProcedureAction("QOInsertOrder");

            return _changedSets;
        } //insertOrder()

        /// <summary>
        /// DatarowToclsOrder(): Transforms a DataRow into a OrderExtended Object
        /// </summary>
        /// <param name="fieldName">DataRow</param>
        /// <returns>OrderExtended-Objekt</returns>
        private clsOrderExtended DatarowToclsOrder(DataRow _dr)
        {
            clsOrderExtended _myOrder = new clsOrderExtended();
            clsHelper h = new clsHelper();
            //und hier die Daten nach Index
            _myOrder.ID = (int)_dr["OID"];
            _myOrder.ProductId = h.AddIntFieldValue(_dr, "OFKProduktId");
            _myOrder.ProductName = h.AddStringFieldValue(_dr, "PName");
            _myOrder.UserId = h.AddIntFieldValue(_dr, "OFKUserId");
            _myOrder.UserName = h.AddStringFieldValue(_dr, "UName");
            _myOrder.OrderDate = Convert.ToDateTime(_dr["ODate"]);
            _myOrder.OrderExtras = h.AddIntFieldValue(_dr, "OExtras");
            _myOrder.OrderSize = h.AddIntFieldValue(_dr, "OSize");
            _myOrder.OrderCount = h.AddIntFieldValue(_dr, "OCount");
            _myOrder.OrderSum = h.AddIntFieldValue(_dr, "OSum");
            _myOrder.OrderDelivery = h.AddBoolFieldValue(_dr, "ODelivery");
            _myOrder.OrderStorno = h.AddIntFieldValue(_dr, "OStorno");
            return _myOrder;
        } //DatarowToclsOrder()


    }
}
