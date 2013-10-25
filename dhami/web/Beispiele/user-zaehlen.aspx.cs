using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.beispiele
{
    public partial class user_zaehlen : System.Web.UI.Page
    {
        /// <summary>
        /// Page_Load(): wird beim Aufruf der Seite aufgerfen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            bll.clsUserCollection _UserCol = new bll.clsUserCollection();

            // 1. Weg: Methode CountUsers1() aufrufen
            lblCount1.Text = Convert.ToString(_UserCol.CountUsers());

        }
    }
}