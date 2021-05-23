using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsWebApplication1
{
    public partial class ScheduledMeetings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    DataTable agtdt = new DataTable("Agents");

                    //Retrieving the Data from Session.
                    agtdt = Session["AgentData"] as DataTable;

                    if (agtdt == null)
                    {
                        Response.Write("No scheduled meetings: Schedule Meetings with Agents to Hire Personnel");
                        Button1.Visible = false;
                        Button3.Visible = false;
                    }

                    //Binding the Data retrieved from Session to GridView 2 on Second Page.
                    else if (agtdt.Rows.Count > 0)
                    {
                        {
                            GridView2.DataSource = agtdt;
                            GridView2.DataBind();

                        }
                    }
                    else if (agtdt.Rows.Count == 0)
                    {
                        Response.Write("No scheduled meetings: Schedule Meetings with Agents to Hire Personnel");
                        Button1.Visible = false;
                        Button3.Visible = false;
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable agtdt = new DataTable("Agents");
            agtdt.Columns.Add(new DataColumn() { ColumnName = "AgentName", DataType = typeof(String) });
            agtdt.Columns.Add(new DataColumn() { ColumnName = "Client", DataType = typeof(String) });

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (GridView2.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox ChkSelect = GridView2.Rows[i].FindControl("ChkDelete") as CheckBox;
                    if (ChkSelect.Checked == false)
                    {
                        DataRow agtdr = agtdt.NewRow();
                        Label lblAgt = GridView2.Rows[i].FindControl("lblName") as Label;
                        Label lblCl = GridView2.Rows[i].FindControl("lblCl") as Label;
                        agtdr["AgentName"] = lblAgt.Text;
                        agtdr["Client"] = lblCl.Text;
                        agtdt.Rows.Add(agtdr);
                    }
                }
            }

            Session["AgentData"] = agtdt;

            Response.Redirect("ScheduledMeetings.aspx", true);
        }
        protected void ButtonHome2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeamForm.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Meetings.aspx");
        }
    }
}