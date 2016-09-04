namespace SI2_p2
{
    partial class Form_ListTickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_tickets = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.technician = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_tickets
            // 
            this.dgv_tickets.AllowUserToAddRows = false;
            this.dgv_tickets.AllowUserToDeleteRows = false;
            this.dgv_tickets.AllowUserToOrderColumns = true;
            this.dgv_tickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.ticketState,
            this.ticketDescription,
            this.ticketPriority,
            this.ticketType,
            this.ticketUser,
            this.creationDate,
            this.technician,
            this.closedDate});
            this.dgv_tickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tickets.Location = new System.Drawing.Point(0, 0);
            this.dgv_tickets.Name = "dgv_tickets";
            this.dgv_tickets.ReadOnly = true;
            this.dgv_tickets.Size = new System.Drawing.Size(749, 261);
            this.dgv_tickets.TabIndex = 0;
            // 
            // cod
            // 
            this.cod.HeaderText = "Code";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            // 
            // ticketState
            // 
            this.ticketState.HeaderText = "State";
            this.ticketState.Name = "ticketState";
            this.ticketState.ReadOnly = true;
            // 
            // ticketDescription
            // 
            this.ticketDescription.HeaderText = "Description";
            this.ticketDescription.Name = "ticketDescription";
            this.ticketDescription.ReadOnly = true;
            // 
            // ticketPriority
            // 
            this.ticketPriority.HeaderText = "Priority";
            this.ticketPriority.Name = "ticketPriority";
            this.ticketPriority.ReadOnly = true;
            // 
            // ticketType
            // 
            this.ticketType.HeaderText = "Type";
            this.ticketType.Name = "ticketType";
            this.ticketType.ReadOnly = true;
            // 
            // ticketUser
            // 
            this.ticketUser.HeaderText = "User";
            this.ticketUser.Name = "ticketUser";
            this.ticketUser.ReadOnly = true;
            // 
            // creationDate
            // 
            this.creationDate.HeaderText = "Creation Date";
            this.creationDate.Name = "creationDate";
            this.creationDate.ReadOnly = true;
            // 
            // technician
            // 
            this.technician.HeaderText = "Assigned Technician";
            this.technician.Name = "technician";
            this.technician.ReadOnly = true;
            // 
            // closedDate
            // 
            this.closedDate.HeaderText = "Closed Date";
            this.closedDate.Name = "closedDate";
            this.closedDate.ReadOnly = true;
            // 
            // ListTicketsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(749, 261);
            this.Controls.Add(this.dgv_tickets);
            this.Name = "ListTicketsForm";
            this.Text = "Tickets Information";
            this.Load += new System.EventHandler(this.ListTicketsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_tickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn technician;
        private System.Windows.Forms.DataGridViewTextBoxColumn closedDate;
    }
}