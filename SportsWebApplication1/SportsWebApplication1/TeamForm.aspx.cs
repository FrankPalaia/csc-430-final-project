using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;        //add it for Access Database
using SportsClassLibrary2;

namespace SportsWebApplication1
{
    //Temperory Database class
    public class Personnel
    {
        public string PersonnelName { get; set; }
        public string Salary { get; set; }
    }
    public partial class TeamForm : System.Web.UI.Page
    {
        private readonly string _conString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        protected void Page_Load1(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create DataAdapter
                string CommandText = "SELECT p.P_ID AS ID, p.p_name AS PersonnelName, d.d_name AS Department, a.a_name AS AgentName, Salary, Date_Signed " +
                    "FROM((Personnel AS p INNER JOIN Agent AS a ON p.A_ID = a.A_ID) " +
                    "INNER JOIN Department AS d ON d.D_ID = p.D_ID)";
                OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString1);
                // Return DataSet
                DataTable dtPersonnel = new DataTable();
                dad.Fill(dtPersonnel);
                //Binding the Data to Gridview 1
                GridView1.DataSource = dtPersonnel;
                GridView1.DataBind();
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            DataTable perdt = new DataTable("Personnel");
            perdt.Columns.Add(new DataColumn() { ColumnName = "PersonnelName", DataType = typeof(String) });
            perdt.Columns.Add(new DataColumn() { ColumnName = "Salary", DataType = typeof(String) });


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox ChkSelect = GridView1.Rows[i].FindControl("ChkSelect") as CheckBox;
                    if (ChkSelect.Checked)
                    {
                        DataRow perdr = perdt.NewRow();
                        Label lblEmp = GridView1.Rows[i].FindControl("lblName") as Label;
                        Label lblMon = GridView1.Rows[i].FindControl("lblSal") as Label;
                        perdr["PersonnelName"] = lblEmp.Text;
                        perdr["Salary"] = lblMon.Text;
                        perdt.Rows.Add(perdr);
                    }
                }
            }

            Session["PersonnelData"] = perdt;

            Response.Redirect("CurrentTeam.aspx", true);
        }
        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}