using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SI2_p2
{
    public partial class Form_ExportTicketToXML : Form
    {
        private string connstr = Utility.GetConnectionString();

        public Form_ExportTicketToXML()
        {
            InitializeComponent();
        }

        //button export click event
        private void btn_export_Click(object sender, EventArgs e)
        {
            GetTicketInfo();
        }

        private void GetTicketInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = connstr;                   

                    using (SqlCommand cmd = new SqlCommand("dbo.proc_Get_Ticket_Info", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter cod = new SqlParameter("@cod", SqlDbType.VarChar);
                        cod.Size = 20;
                        cmd.Parameters.Add(cod);

                        cod.Value = textBox_ticketCode.Text;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("The ticket "+textBox_ticketCode.Text+"does not exist.");
                        }
                        else
                        {
                            //move to first record
                            //this is done because every record has almost the exact same information, except the one regarding actions
                            //so the first record has the same info for ticket,technician,owner and ticket_type as the rest
                            dr.Read();
                            using(DataSet ds = new DataSet())
                            {
                                //reads XML_Schema to build dataset
                                ds.ReadXmlSchema("XML_Schema.xsd");
                                //populate dataset
                                FillTables(dr, ds.Tables);
                                ds.DataSetName = "Ticket_Info";
                                //saves both xsd and xml
                                ds.WriteXml(textBox_filename.Text+".xml");
                                ds.WriteXmlSchema(textBox_filename.Text + ".xsd");
                                MessageBox.Show("The ticket " + textBox_ticketCode.Text + " has been exported to " + textBox_filename + ".xml");
                            }
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                if (!Utility.fatalNetworkException(ex.Number)) throw ex;
                SqlConnection.ClearAllPools();
                GetTicketInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //closes the form
                this.Close();
            }
        }

        private void FillTables(SqlDataReader dr, DataTableCollection dtc)
        {
            FillTicketTable(dr, dtc["ticket"]);
            FillOwnerTable(dr,dtc["owner"]);
            FillSupervisorTable(dr, dtc["supervisor"]);
            FillTicketTypeTable(dr,dtc["type_type"]);
            FillActionsTable(dr, dtc["actions"], dtc["action"]);
        }

        private void FillTicketTable(SqlDataReader dr, DataTable dt)
        {
            //because it's only 1 ticket, the id is 1...if there were more, then we'd use a different system
            dt.Rows.Add(new object[] { dr["tt_id"], dr["cod"], dr["ticketState"],dr["ticketDescription"],1});
        }

        private void FillOwnerTable(SqlDataReader dr, DataTable dt)
        {
            dt.Rows.Add(new object[] { dr["owner_email"], dr["owner_name"], dr["owner_id"], dr["owner_email"],1});
        }

        private void FillSupervisorTable(SqlDataReader dr, DataTable dt)
        {
            dt.Rows.Add(new object[] { dr["anumber"], dr["tech_name"], dr["tech_email"], dr["anumber"],1});
        }

        private void FillTicketTypeTable(SqlDataReader dr, DataTable dt)
        {
            dt.Rows.Add(new object[] { dr["tt_id"], dr["tt_name"], dr["tt_id"],1});
        }

        private void FillActionsTable(SqlDataReader dr, DataTable actions, DataTable action)
        {
            actions.Rows.Add(new object[] { 1 });
            //already at first record of sqldatareader
            action.Rows.Add(new object[] { dr["orderNumber"], dr["beginDate"], dr["endDate"], dr["orderNumber"],1 });
            
            //continues while there's more
            while (dr.Read())
            {
                action.Rows.Add(new object[] { dr["orderNumber"], dr["beginDate"], dr["endDate"], dr["orderNumber"],1 });
            }            
        }        
    }
}
