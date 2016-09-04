namespace Tickets_ex1.Forms
{
	partial class Form_InsertAction
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
			this.lbl_mainInfo = new System.Windows.Forms.Label();
			this.lbl_techNum = new System.Windows.Forms.Label();
			this.textBox_techNum = new System.Windows.Forms.TextBox();
			this.lbl_ticketCode = new System.Windows.Forms.Label();
			this.textBox_ticketCode = new System.Windows.Forms.TextBox();
			this.dgv_steps = new System.Windows.Forms.DataGridView();
			this.lbl_stepInfo2 = new System.Windows.Forms.Label();
			this.lbl_dgvStep = new System.Windows.Forms.Label();
			this.lbl_stepNumber = new System.Windows.Forms.Label();
			this.textBox_stepNum = new System.Windows.Forms.TextBox();
			this.lbl_note = new System.Windows.Forms.Label();
			this.textBox_actionNote = new System.Windows.Forms.TextBox();
			this.btn_Insert = new System.Windows.Forms.Button();
			this.stepNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgv_steps)).BeginInit();
			this.SuspendLayout();
			// 
			// lbl_mainInfo
			// 
			this.lbl_mainInfo.AutoSize = true;
			this.lbl_mainInfo.Location = new System.Drawing.Point(220, 171);
			this.lbl_mainInfo.Name = "lbl_mainInfo";
			this.lbl_mainInfo.Size = new System.Drawing.Size(143, 13);
			this.lbl_mainInfo.TabIndex = 0;
			this.lbl_mainInfo.Text = "Insert an Action into a Ticket";
			this.lbl_mainInfo.Visible = false;
			// 
			// lbl_techNum
			// 
			this.lbl_techNum.AutoSize = true;
			this.lbl_techNum.Location = new System.Drawing.Point(12, 193);
			this.lbl_techNum.Name = "lbl_techNum";
			this.lbl_techNum.Size = new System.Drawing.Size(100, 13);
			this.lbl_techNum.TabIndex = 1;
			this.lbl_techNum.Text = "Technician Number";
			this.lbl_techNum.Visible = false;
			// 
			// textBox_techNum
			// 
			this.textBox_techNum.Location = new System.Drawing.Point(118, 190);
			this.textBox_techNum.Name = "textBox_techNum";
			this.textBox_techNum.Size = new System.Drawing.Size(30, 20);
			this.textBox_techNum.TabIndex = 2;
			this.textBox_techNum.Visible = false;
			// 
			// lbl_ticketCode
			// 
			this.lbl_ticketCode.AutoSize = true;
			this.lbl_ticketCode.Location = new System.Drawing.Point(244, 28);
			this.lbl_ticketCode.Name = "lbl_ticketCode";
			this.lbl_ticketCode.Size = new System.Drawing.Size(65, 13);
			this.lbl_ticketCode.TabIndex = 3;
			this.lbl_ticketCode.Text = "Ticket Code";
			// 
			// textBox_ticketCode
			// 
			this.textBox_ticketCode.Location = new System.Drawing.Point(324, 25);
			this.textBox_ticketCode.Name = "textBox_ticketCode";
			this.textBox_ticketCode.Size = new System.Drawing.Size(30, 20);
			this.textBox_ticketCode.TabIndex = 4;
			this.textBox_ticketCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ticketCode_KeyDown);
			// 
			// dgv_steps
			// 
			this.dgv_steps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_steps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_steps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.stepNumber,
			this.description});
			this.dgv_steps.Location = new System.Drawing.Point(1, 67);
			this.dgv_steps.Name = "dgv_steps";
			this.dgv_steps.Size = new System.Drawing.Size(594, 101);
			this.dgv_steps.TabIndex = 6;
			// 
			// lbl_stepInfo2
			// 
			this.lbl_stepInfo2.AutoSize = true;
			this.lbl_stepInfo2.Location = new System.Drawing.Point(215, 9);
			this.lbl_stepInfo2.Name = "lbl_stepInfo2";
			this.lbl_stepInfo2.Size = new System.Drawing.Size(178, 13);
			this.lbl_stepInfo2.TabIndex = 7;
			this.lbl_stepInfo2.Text = "Get Steps Associated to TicketType";
			// 
			// lbl_dgvStep
			// 
			this.lbl_dgvStep.AutoSize = true;
			this.lbl_dgvStep.Location = new System.Drawing.Point(263, 51);
			this.lbl_dgvStep.Name = "lbl_dgvStep";
			this.lbl_dgvStep.Size = new System.Drawing.Size(65, 13);
			this.lbl_dgvStep.TabIndex = 8;
			this.lbl_dgvStep.Text = "List of Steps";
			// 
			// lbl_stepNumber
			// 
			this.lbl_stepNumber.AutoSize = true;
			this.lbl_stepNumber.Location = new System.Drawing.Point(167, 193);
			this.lbl_stepNumber.Name = "lbl_stepNumber";
			this.lbl_stepNumber.Size = new System.Drawing.Size(69, 13);
			this.lbl_stepNumber.TabIndex = 9;
			this.lbl_stepNumber.Text = "Step Number";
			this.lbl_stepNumber.Visible = false;
			// 
			// textBox_stepNum
			// 
			this.textBox_stepNum.Location = new System.Drawing.Point(247, 190);
			this.textBox_stepNum.Name = "textBox_stepNum";
			this.textBox_stepNum.Size = new System.Drawing.Size(30, 20);
			this.textBox_stepNum.TabIndex = 10;
			this.textBox_stepNum.Visible = false;
			// 
			// lbl_note
			// 
			this.lbl_note.AutoSize = true;
			this.lbl_note.Location = new System.Drawing.Point(283, 193);
			this.lbl_note.Name = "lbl_note";
			this.lbl_note.Size = new System.Drawing.Size(30, 13);
			this.lbl_note.TabIndex = 11;
			this.lbl_note.Text = "Note";
			this.lbl_note.Visible = false;
			// 
			// textBox_actionNote
			// 
			this.textBox_actionNote.Location = new System.Drawing.Point(317, 190);
			this.textBox_actionNote.Name = "textBox_actionNote";
			this.textBox_actionNote.Size = new System.Drawing.Size(265, 20);
			this.textBox_actionNote.TabIndex = 12;
			this.textBox_actionNote.Visible = false;
			// 
			// btn_Insert
			// 
			this.btn_Insert.Location = new System.Drawing.Point(247, 216);
			this.btn_Insert.Name = "btn_Insert";
			this.btn_Insert.Size = new System.Drawing.Size(75, 23);
			this.btn_Insert.TabIndex = 13;
			this.btn_Insert.Text = "Insert";
			this.btn_Insert.UseVisualStyleBackColor = true;
			this.btn_Insert.Visible = false;
			this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
			// 
			// stepNumber
			// 
			this.stepNumber.HeaderText = "Step Number";
			this.stepNumber.Name = "stepNumber";
			this.stepNumber.ReadOnly = true;
			// 
			// description
			// 
			this.description.HeaderText = "Description";
			this.description.Name = "description";
			this.description.ReadOnly = true;
			this.description.Width = 450;
			// 
			// Form_InsertAction
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 246);
			this.Controls.Add(this.btn_Insert);
			this.Controls.Add(this.textBox_actionNote);
			this.Controls.Add(this.lbl_note);
			this.Controls.Add(this.textBox_stepNum);
			this.Controls.Add(this.lbl_stepNumber);
			this.Controls.Add(this.lbl_dgvStep);
			this.Controls.Add(this.lbl_stepInfo2);
			this.Controls.Add(this.dgv_steps);
			this.Controls.Add(this.textBox_ticketCode);
			this.Controls.Add(this.lbl_ticketCode);
			this.Controls.Add(this.textBox_techNum);
			this.Controls.Add(this.lbl_techNum);
			this.Controls.Add(this.lbl_mainInfo);
			this.Name = "Form_InsertAction";
			this.Text = "Insert Action";
			((System.ComponentModel.ISupportInitialize)(this.dgv_steps)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_mainInfo;
		private System.Windows.Forms.Label lbl_techNum;
		private System.Windows.Forms.TextBox textBox_techNum;
		private System.Windows.Forms.Label lbl_ticketCode;
		private System.Windows.Forms.TextBox textBox_ticketCode;
		private System.Windows.Forms.DataGridView dgv_steps;
		private System.Windows.Forms.Label lbl_stepInfo2;
		private System.Windows.Forms.Label lbl_dgvStep;
		private System.Windows.Forms.Label lbl_stepNumber;
		private System.Windows.Forms.TextBox textBox_stepNum;
		private System.Windows.Forms.Label lbl_note;
		private System.Windows.Forms.TextBox textBox_actionNote;
		private System.Windows.Forms.Button btn_Insert;
		private System.Windows.Forms.DataGridViewTextBoxColumn stepNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn description;
	}
}