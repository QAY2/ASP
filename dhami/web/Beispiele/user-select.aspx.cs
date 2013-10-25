using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;

namespace web.beispiele
{
    public partial class user_select : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ereignis beim Klick auf den Auswahlknopf zur DropDownList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDropDownSelect_Click(object sender, EventArgs e)
        {
            clsUser _myUser = new clsUser();
            clsUserCollection _myUserCol = new clsUserCollection();

            int _id = Convert.ToInt32(ddlUser.SelectedValue);

            _myUser = _myUserCol.GetUserById(_id);

            if (_myUser != null)
                lblMsg.Text = "Auswahl in DropDownList: " + _myUser.Name + " " + _myUser.Address;
            else
                lblMsg.Text = "Auswahl in DropDownList nicht gefunden: " + _id.ToString();
        }  // btnDropDownSelect_Click()

        /// <summary>
        /// Ereignis beim Klicken auf den Auswahlknopf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _name = grdUsers.SelectedRow.Cells[1].Text;  // 2. Spalte in gridView
            string _address = grdUsers.SelectedRow.Cells[2].Text;   //3. Spalte in gridView
            lblMsg.Text = "Auswahl in GridView: " + _name + " " + _address;
        }  // grdUsers_SelectedIndexChanged()
    }
}