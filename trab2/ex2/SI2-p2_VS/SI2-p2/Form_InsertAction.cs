using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SI2_p2
{
    public partial class Form_InsertAction : Form
    {
        private string connstr = Utility.GetConnectionString();
        private SqlConnection con;

        private int resp_technician;
        private string ticket_type;

        public Form_InsertAction()
        {
            InitializeComponent();
        }

        //hides the labels, textboxes and button for the insertion part
        private void Conceal()
        {
            lbl_mainInfo.Visible = false;
            lbl_techNum.Visible = false;
            lbl_stepNumber.Visible = false;
            lbl_note.Visible = false;
            btn_Insert.Visible = false;
            textBox_actionNote.Visible = false;
            textBox_techNum.Visible = false;
            textBox_stepNum.Visible = false;
        }

        //shows the labels, textboxes and button for the insertion part
        private void Reveal()
        {
            lbl_mainInfo.Visible = true;
            lbl_techNum.Visible = true;
            lbl_stepNumber.Visible = true;
            lbl_note.Visible = true;
            btn_Insert.Visible = true;
            textBox_actionNote.Visible = true;
            textBox_techNum.Visible = true;
            textBox_stepNum.Visible = true;
        }

        private void GetConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = connstr;
        }

        private void CloseConnection()
        {
            try
            {
                con.Close();
                con.Dispose();
                con = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void textBox_ticketCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetTicketInfo();
            }
        }

        private void GetTicketInfo()
        {
            GetConnection();
            try
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    bool reveal = true;

                    SqlParameter ticket_code = new SqlParameter("@cod", SqlDbType.VarChar);
                    ticket_code.Size = 20;
                    cmd.Parameters.Add(ticket_code);
                    cmd.CommandText = "select orderNumber,description,technician,ticketState,Step.ticketType from vi_Ticket "
                        + "inner join Step "
                        + "on vi_Ticket.ticketType = Step.ticketType "
                        + "where cod = @cod";

                    ticket_code.Value = textBox_ticketCode.Text;

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        //if ticket code doesn't exist, hides the insertion section
                        Conceal();
                        MessageBox.Show("There isn't any ticket with the code " + ticket_code.Value.ToString());
                    }
                    else
                    {
                        while (dr.Read())
                        {
                            if (!dr["ticketState"].ToString().Equals("In Progress"))
                            {
                                MessageBox.Show("The ticket " + ticket_code.Value.ToString() + " is not in progress");
                                Conceal();
                                reveal = false;
                                break;
                            }

                            dgv_steps.Rows.Add(
                                dr["orderNumber"],
                                dr["description"]
                                );
                            //stores the responsible technician for the ticket, for future use
                            resp_technician = Convert.ToInt32(dr["technician"]);
                            //stores the ticket's ticket type for future use
                            ticket_type = dr["ticketType"].ToString();
                        }
                        
                        if (reveal)
                        {
                            Reveal();
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
                con.Close();
            }         
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            DoInsertion();
        }

        private void DoInsertion()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_Insert_Ticket_Action", con))
                {
                    SqlParameter ticketCode = new SqlParameter("@ticket", SqlDbType.VarChar);
                    ticketCode.Size = 20;                    

                    SqlParameter tech = new SqlParameter("@technician", SqlDbType.Int);

                    SqlParameter ticketType = new SqlParameter("@stepTicketType", SqlDbType.VarChar);
                    ticketType.Size = 20;                    

                    SqlParameter stepOrderNumber = new SqlParameter("@stepOrderNumber", SqlDbType.Int);

                    SqlParameter note = new SqlParameter("@note", SqlDbType.VarChar);
                    note.Size = 20;

                    SqlParameter orderNumber = new SqlParameter("@orderNumber", SqlDbType.Int);
                    orderNumber.Direction = ParameterDirection.Output;

                    ticketCode.Value = textBox_ticketCode.Text;
                    tech.Value = Convert.ToInt32(textBox_techNum.Text);
                    ticketType.Value = ticket_type;
                    stepOrderNumber.Value = Convert.ToInt32(textBox_stepNum.Text);
                    note.Value = textBox_actionNote.Text;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ticketCode);
                    cmd.Parameters.Add(tech);
                    cmd.Parameters.Add(ticketType);
                    cmd.Parameters.Add(stepOrderNumber);
                    cmd.Parameters.Add(note);
                    cmd.Parameters.Add(orderNumber);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                    if (MessageBox.Show("When you press Ok, the action will be closed", "Confirm", MessageBoxButtons.OK) == DialogResult.OK)
                    {

                        using (SqlCommand cmd_end = new SqlCommand("dbo.sp_End_Ticket_Action", con))
                        {
                            cmd_end.CommandType = CommandType.StoredProcedure;

                            //since the parameters were already being used in another collection, new parameters had to be created
                            SqlParameter orderNumber2 = new SqlParameter("@orderNumber", SqlDbType.Int);
                            orderNumber2.Value = orderNumber.Value;
                            SqlParameter ticketCode2 = new SqlParameter("@ticket", SqlDbType.VarChar);
                            ticketCode2.Size = 20;
                            ticketCode2.Value = ticketCode.Value;

                            cmd_end.Parameters.Add(orderNumber2);
                            cmd_end.Parameters.Add(ticketCode2);

                            cmd_end.ExecuteNonQuery();

                            if (MessageBox.Show("Did the action solve the problem?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                if (resp_technician == Convert.ToInt32(textBox_techNum.Text))
                                {
                                    using (SqlCommand cmd_close = new SqlCommand("dbo.sp_Close_Ticket", con))
                                    {
                                        SqlParameter ticketCode3 = new SqlParameter("@ticket", SqlDbType.VarChar);
                                        ticketCode3.Size = 20;
                                        ticketCode3.Value = ticketCode.Value;
                                        SqlParameter tech2 = new SqlParameter("@technician", SqlDbType.Int);
                                        tech2.Value = tech.Value;

                                        cmd_close.CommandType = CommandType.StoredProcedure;
                                        cmd_close.Parameters.Add(ticketCode3);
                                        cmd_close.Parameters.Add(tech2);
                                        cmd_close.ExecuteNonQuery();
                                        MessageBox.Show("The ticket "+ ticketCode.Value.ToString()+ " has been closed.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("You're not the technician responsible for this ticket, so it's not closed.");
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (!Utility.fatalNetworkException(ex.Number)) throw ex;
                SqlConnection.ClearAllPools();
                GetConnection();
                DoInsertion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                CloseConnection();
                this.Close();
            }
        }
    }
}
