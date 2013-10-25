using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.beispiele
{
    public partial class user_insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// wird bei Klick des Einfügen-Knopfs aufgerufen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bll.clsUser newUser = new bll.clsUser();
            bll.clsUserCollection myUserCol = new bll.clsUserCollection();

            newUser.Name = txtName.Text;
            newUser.Address = txtAddress.Text;
            newUser.Distance = Convert.ToInt32(txtDistance.Text);
            newUser.IsAdmin = chkIsAdmin.Checked;
            newUser.Password = txtPassword.Text;

            if (myUserCol.InsertUser(newUser) == 1)
                lblMsg.Text = "Insert von " + newUser.Name + " erfolgreich!";
            else
                lblMsg.Text = "Insert von " + newUser.Name + " NICHT erfolgreich!";
            
        } //btnInsert_Click()
    }
}