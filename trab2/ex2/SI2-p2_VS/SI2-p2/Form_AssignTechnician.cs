using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SI2_p2
{
    public partial class Form_AssignTechnician : Form
    {
        private string connstr = Utility.GetConnectionString();

        public Form_AssignTechnician()
        {
            InitializeComponent();
        }       

        private void btn_assign_Click(object sender, EventArgs e)
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
                    using (SqlCommand cmd = new SqlCommand("dbo.proc_Assign_Technician", con))
                    {
                        SqlParameter tech_num = new SqlParameter("@tech_num", SqlDbType.Int);

                        SqlParameter ticket_code = new SqlParameter("@cod", SqlDbType.VarChar);
                        ticket_code.Size = 20;
                        ticket_code.Direction = ParameterDirection.Output;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(tech_num);
                        cmd.Parameters.Add(ticket_code);

                        tech_num.Value = Convert.ToInt16(textBox_techCode.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        string ticket = ticket_code.Value.ToString();
                        
                        if (ticket.Equals("."))
                        {
                            MessageBox.Show("The Technician with number " + tech_num.Value.ToString()+" doesn't exist in the DB");
                        }
                        else
                        {
                            if (ticket.Equals(""))
                            {
                                MessageBox.Show("There are no unassigned Tickets.");
                            }
                            else
                            {
                                MessageBox.Show("The Technician with number " + tech_num.Value.ToString() + " has been assigned to Ticket " + ticket);
                            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
