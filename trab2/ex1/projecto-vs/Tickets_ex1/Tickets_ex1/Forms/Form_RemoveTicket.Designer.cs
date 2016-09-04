namespace Tickets_ex1.Forms
{
	partial class Form_RemoveTicket
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
			this.btn_rmv_ticket = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_cod = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btn_rmv_ticket
			// 
			this.btn_rmv_ticket.Location = new System.Drawing.Point(198, 23);
			this.btn_rmv_ticket.Name = "btn_rmv_ticket";
			this.btn_rmv_ticket.Size = new System.Drawing.Size(75, 23);
			this.btn_rmv_ticket.TabIndex = 0;
			this.btn_rmv_ticket.Text = "Remove";
			this.btn_rmv_ticket.UseVisualStyleBackColor = true;
			this.btn_rmv_ticket.Click += new System.EventHandler(this.btn_rmv_ticket_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(95, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Remove Ticket";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Ticket Code";
			// 
			// textBox_cod
			// 
			this.textBox_cod.Location = new System.Drawing.Point(84, 25);
			this.textBox_cod.Name = "textBox_cod";
			this.textBox_cod.Size = new System.Drawing.Size(100, 20);
			this.textBox_cod.TabIndex = 3;
			// 
			// Form_RemoveTicket
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 58);
			this.Controls.Add(this.textBox_cod);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_rmv_ticket);
			this.Name = "Form_RemoveTicket";
			this.Text = "Remove Ticket";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_rmv_ticket;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_cod;
	}
}