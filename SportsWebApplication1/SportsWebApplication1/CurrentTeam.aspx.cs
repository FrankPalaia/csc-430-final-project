using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsWebApplication1
{
    public partial class CurrentTeam : System.Web.UI.Page
    {
        int totalsalary = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    DataTable perdt = new DataTable("Personnel");

                    //Retrieving the Data from Session.
                    perdt = Session["PersonnelData"] as DataTable;

                    if (perdt == null)
                    {
                        Response.Write("Empty Team: Need to Fill </br> Schedule Meetings with Agents to Hire Personnel");
                        Button3.Visible = false;
                    }

                    //Binding the Data retrieved from Session to GridView 2 on Second Page.
                    else if (perdt.Rows.Count > 0)
                    {
                        {
                            GridView2.DataSource = perdt;
                            GridView2.DataBind();

                        }
                        GridView2.FooterRow.Cells[1].Text = "Total:";
                        GridView2.FooterRow.Cells[3].Text = "Remaining Budget:";
                        GridView2.FooterRow.Cells[4].Text = (100000000 - totalsalary).ToString();
                        if((100000000 - totalsalary)< 0 )
                        {
                            Response.Write("Not Enough Payroll, Team is overbudget!");
                        }
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable perdt = new DataTable("Personnel");
            perdt.Columns.Add(new DataColumn() { ColumnName = "PersonnelName", DataType = typeof(String) });
            perdt.Columns.Add(new DataColumn() { ColumnName = "Salary", DataType = typeof(String) });


            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (GridView2.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox ChkSelect = GridView2.Rows[i].FindControl("ChkDelete") as CheckBox;
                    if (ChkSelect.Checked == false)
                    {
                        DataRow perdr = perdt.NewRow();
                        Label lblEmp = GridView2.Rows[i].FindControl("lblName") as Label;
                        Label lblMon = GridView2.Rows[i].FindControl("lblSal") as Label;
                        perdr["PersonnelName"] = lblEmp.Text;
                        perdr["Salary"] = lblMon.Text;
                        perdt.Rows.Add(perdr);
                    }
                }
            }

            Session["PersonnelData"] = perdt;

            Response.Redirect("CurrentTeam.aspx", true);
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Salary = (Label)e.Row.FindControl("lblSal");
                totalsalary = totalsalary + int.Parse(Salary.Text);            
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalSalary");
                lblTotalPrice.Text = totalsalary.ToString();
            }            
        }
    }
}