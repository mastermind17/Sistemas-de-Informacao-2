namespace Tickets_ex1.Forms
{
	partial class Form_ExportTicketToXML
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
			this.lbl_ticketCode = new System.Windows.Forms.Label();
			this.textBox_ticketCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_filename = new System.Windows.Forms.TextBox();
			this.btn_export = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_ticketCode
			// 
			this.lbl_ticketCode.AutoSize = true;
			this.lbl_ticketCode.Location = new System.Drawing.Point(12, 9);
			this.lbl_ticketCode.Name = "lbl_ticketCode";
			this.lbl_ticketCode.Size = new System.Drawing.Size(65, 13);
			this.lbl_ticketCode.TabIndex = 0;
			this.lbl_ticketCode.Text = "Ticket Code";
			// 
			// textBox_ticketCode
			// 
			this.textBox_ticketCode.Location = new System.Drawing.Point(83, 6);
			this.textBox_ticketCode.Name = "textBox_ticketCode";
			this.textBox_ticketCode.Size = new System.Drawing.Size(34, 20);
			this.textBox_ticketCode.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(123, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Save to Filename";
			// 
			// textBox_filename
			// 
			this.textBox_filename.Location = new System.Drawing.Point(218, 6);
			this.textBox_filename.Name = "textBox_filename";
			this.textBox_filename.Size = new System.Drawing.Size(121, 20);
			this.textBox_filename.TabIndex = 3;
			// 
			// btn_export
			// 
			this.btn_export.Location = new System.Drawing.Point(345, 4);
			this.btn_export.Name = "btn_export";
			this.btn_export.Size = new System.Drawing.Size(75, 23);
			this.btn_export.TabIndex = 4;
			this.btn_export.Text = "Export";
			this.btn_export.UseVisualStyleBackColor = true;
			this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
			// 
			// Form_ExportTicketToXML
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 35);
			this.Controls.Add(this.btn_export);
			this.Controls.Add(this.textBox_filename);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_ticketCode);
			this.Controls.Add(this.lbl_ticketCode);
			this.Name = "Form_ExportTicketToXML";
			this.Text = "Export Ticket to XML";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_ticketCode;
		private System.Windows.Forms.TextBox textBox_ticketCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_filename;
		private System.Windows.Forms.Button btn_export;
	}
}