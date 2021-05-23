using System;
using System.Data;
using System.Web;
using System.Data.OleDb;        //add it for Access Database
namespace SportsClassLibrary2
{
    public class Class1
    {
        private readonly string _conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        public DataSet getPersonnel()
        {

            // Create DataAdapter
            string CommandText = "SELECT * FROM AvailablePersonnel";
            OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString);
            // Return DataSet
            DataSet dstPersonnel = new DataSet();
            using (dad)
            {
                dad.Fill(dstPersonnel);
            }
            return dstPersonnel;
        }
    }
    public class Class2
    {
        private readonly string _conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        public DataSet viewAgents()
        {

            // Create DataAdapter
            string CommandText = "SELECT  a.A_ID AS AgentID, a.a_name AS AgentName, p.p_name AS Client, d.d_name AS Department " +
                "FROM((AvailablePersonnel AS p INNER JOIN Agent AS a ON p.A_ID = a.A_ID) " +
                "INNER JOIN Department AS d ON d.D_ID = p.D_ID)";
            OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString);
            // Return DataSet
            DataSet dstPersonnel = new DataSet();
            using (dad)
            {
                dad.Fill(dstPersonnel);
            }
            return dstPersonnel;
        }
    }
    public class Class3
    {
        private readonly string _conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        public DataSet viewPersonnel()
        {

            // Create DataAdapter
            string CommandText = "SELECT p.P_ID AS ID, p.p_name AS Name, p.A_ID AS Agent_ID, a.a_name AS Agent, p.D_ID AS Dept_ID, d.d_name AS Department, Salary, Date_Signed " +
                "FROM((Personnel AS p INNER JOIN Agent AS a ON p.A_ID = a.A_ID) " +
                "INNER JOIN Department AS d ON d.D_ID = p.D_ID)";
            OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString);
            // Return DataSet
            DataSet dstPersonnel = new DataSet();
            using (dad)
            {
                dad.Fill(dstPersonnel);
            }
            return dstPersonnel;
        }
    }
    public class Class4
    {
        private readonly string _conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        public DataSet viewMeetings()
        {

            // Create DataAdapter
            string CommandText = "SELECT  m.A_ID AS AgentID, m.a_name AS AgentName, m.p_name AS Client, m.MeetTime AS MeetingTime " +
                "FROM((AvailablePersonnel AS p INNER JOIN AgentMeeting AS m ON p.A_ID = m.A_ID) " +
                "INNER JOIN Agent AS a ON a.A_ID = p.D_ID)";
            OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString);
            // Return DataSet
            DataSet dstPersonnel = new DataSet();
            using (dad)
            {
                dad.Fill(dstPersonnel);
            }
            return dstPersonnel;
        }
    }
    public class Class5
    {
        private readonly string _conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fp3times2\\Documents\\CSC 430 Final Project Sports.accdb";
        public DataSet viewPayroll()
        {

            // Create DataAdapter
            string CommandText = "SELECT Payroll FROM Team";
            OleDbDataAdapter dad = new OleDbDataAdapter(CommandText, _conString);
            // Return DataSet
            DataSet dstPersonnel = new DataSet();
            using (dad)
            {
                dad.Fill(dstPersonnel);
            }
            return dstPersonnel;
        }
    }
}
