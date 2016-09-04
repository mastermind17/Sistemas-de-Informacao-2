namespace Tickets_ex1.Forms
{
	partial class Form_AssignTechnician
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_techCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_assign = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Technician Code";
			// 
			// textBox_techCode
			// 
			this.textBox_techCode.Location = new System.Drawing.Point(115, 30);
			this.textBox_techCode.Name = "textBox_techCode";
			this.textBox_techCode.Size = new System.Drawing.Size(78, 20);
			this.textBox_techCode.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(281, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Assign a Technician to the most recent unassigned Ticket";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// btn_assign
			// 
			this.btn_assign.Location = new System.Drawing.Point(214, 28);
			this.btn_assign.Name = "btn_assign";
			this.btn_assign.Size = new System.Drawing.Size(75, 23);
			this.btn_assign.TabIndex = 4;
			this.btn_assign.Text = "Assign";
			this.btn_assign.UseVisualStyleBackColor = true;
			this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
			// 
			// Form_AssignTechnician
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(308, 61);
			this.Controls.Add(this.btn_assign);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_techCode);
			this.Controls.Add(this.label1);
			this.Name = "Form_AssignTechnician";
			this.Text = "Technician Assignment";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_techCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_assign;
	}
}