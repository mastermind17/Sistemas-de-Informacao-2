using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SI2_p2
{
    public partial class Form_RemoveTicket : Form
    {
        private string connstr = Utility.GetConnectionString();

        public Form_RemoveTicket()
        {
            InitializeComponent();
        }

        private void btn_rmv_ticket_Click(object sender, EventArgs e)
        {
            doAction();
        }

        private void doAction()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = connstr;
                    using (SqlCommand cmd = new SqlCommand("dbo.proc_Remove_Ticket", con))
                    {                        
                        SqlParameter ticket_code = new SqlParameter("@cod", SqlDbType.VarChar);
                        ticket_code.Size = 20;

                        SqlParameter res = new SqlParameter("@res", SqlDbType.Int);                        
                        res.Direction = ParameterDirection.Output;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(ticket_code);
                        cmd.Parameters.Add(res);

                        ticket_code.Value = textBox_cod.Text;

                        con.Open();
                        cmd.ExecuteNonQuery();

                        int r = Convert.ToInt32(res.Value.ToString());

                        if (r==0) {
                            MessageBox.Show("The ticket with code " + ticket_code.Value.ToString() + "does not exist or has already been removed.");
                        }

                        else
                        {
                            MessageBox.Show("The ticket with code " + ticket_code.Value.ToString() + "has been removed");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (!Utility.fatalNetworkException(ex.Number)) throw ex;
                SqlConnection.ClearAllPools();
                doAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
