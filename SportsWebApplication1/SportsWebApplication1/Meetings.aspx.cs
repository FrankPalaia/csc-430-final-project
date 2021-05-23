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
    public class Agents
    {
        public string AgentName { get; set; }
        public string Client { get; set; }
    }
    public partial class Meetings : System.Web.UI.Page
    {
        private readonly string _conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create DataAdapter
                string CommandText = "SELECT a.A_ID AS AgentID, a.a_name AS AgentName, p.p_name AS Client, d.d_name AS Department " +
                "FROM((AvailablePersonnel AS p INNER JOIN Agent AS a ON p.A_ID = a.A_ID) " +
                "INNER JOIN Department AS d ON d.D_ID = p.D_ID)";
                OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString);
                // Return DataSet
                DataTable dtPersonnel = new DataTable();
                dad.Fill(dtPersonnel);            
                //Binding the Data to Gridview 1
                GridView1.DataSource = dtPersonnel;
                GridView1.DataBind();     
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random agree = new Random();
            DataTable agtdt = new DataTable("Agents");
            agtdt.Columns.Add(new DataColumn() { ColumnName = "AgentName", DataType = typeof(String) });
            agtdt.Columns.Add(new DataColumn() { ColumnName = "Client", DataType = typeof(String) });
            bool approved = false;
            int[] meetings = new int[GridView1.Rows.Count];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {                    
                    CheckBox ChkSelect = GridView1.Rows[i].FindControl("ChkSelect") as CheckBox;
                    if (ChkSelect.Checked)
                    {
                        DataRow agtdr = agtdt.NewRow();
                        Label lblAgt = GridView1.Rows[i].FindControl("lblName") as Label;
                        Label lblCl = GridView1.Rows[i].FindControl("lblCl") as Label;
                        agtdr["AgentName"] = lblAgt.Text;
                        agtdr["Client"] = lblCl.Text;
                        meetings[i] = agree.Next(0, 10);
                        if (meetings[i] % 2 == 0)
                        {
                            Response.Write("Agent: " + lblAgt.Text + " agreed to meet!</br>");
                            Response.Write("Meeting value: " + meetings[i] + "</br>");
                            agtdt.Rows.Add(agtdr);
                            approved = true;

                            
                        }
                        else if(meetings[i] % 2 ==1)
                        {
                            Response.Write("Agent: " + lblAgt.Text + " did not agree to meet</br>");
                            Response.Write("Meeting value: " + meetings[i] + "</br>");
                        }
                    }
                }
            }
            if(approved)
            {
                Session["AgentData"] = agtdt;

                Response.Redirect("ScheduledMeetings.aspx", true);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}