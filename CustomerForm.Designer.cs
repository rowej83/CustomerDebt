/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/20/2014
 * Time: 9:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CustomerDebt
{
	partial class CustomerForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.customerClear = new System.Windows.Forms.Button();
			this.customerCancel = new System.Windows.Forms.Button();
			this.customerSave = new System.Windows.Forms.Button();
			this.customerPhone = new System.Windows.Forms.MaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.customerEmail = new System.Windows.Forms.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.customerName = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.customerClear);
			this.groupBox1.Controls.Add(this.customerCancel);
			this.groupBox1.Controls.Add(this.customerSave);
			this.groupBox1.Controls.Add(this.customerPhone);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.customerEmail);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.customerName);
			this.groupBox1.Location = new System.Drawing.Point(21, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(389, 314);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Customer Info";
			// 
			// customerClear
			// 
			this.customerClear.Location = new System.Drawing.Point(186, 242);
			this.customerClear.Name = "customerClear";
			this.customerClear.Size = new System.Drawing.Size(62, 34);
			this.customerClear.TabIndex = 7;
			this.customerClear.Text = "Clea&r";
			this.customerClear.UseVisualStyleBackColor = true;
			this.customerClear.Click += new System.EventHandler(this.CustomerClearClick);
			// 
			// customerCancel
			// 
			this.customerCancel.Location = new System.Drawing.Point(254, 242);
			this.customerCancel.Name = "customerCancel";
			this.customerCancel.Size = new System.Drawing.Size(62, 34);
			this.customerCancel.TabIndex = 8;
			this.customerCancel.Text = "&Cancel";
			this.customerCancel.UseVisualStyleBackColor = true;
			this.customerCancel.Click += new System.EventHandler(this.CustomerCancelClick);
			// 
			// customerSave
			// 
			this.customerSave.Location = new System.Drawing.Point(78, 238);
			this.customerSave.Name = "customerSave";
			this.customerSave.Size = new System.Drawing.Size(95, 43);
			this.customerSave.TabIndex = 6;
			this.customerSave.Text = "&Save";
			this.customerSave.UseVisualStyleBackColor = true;
			this.customerSave.Click += new System.EventHandler(this.CustomerSaveClick);
			// 
			// customerPhone
			// 
			this.customerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customerPhone.HidePromptOnLeave = true;
			this.customerPhone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.customerPhone.Location = new System.Drawing.Point(170, 178);
			this.customerPhone.Mask = "(999) 000-0000";
			this.customerPhone.Name = "customerPhone";
			this.customerPhone.Size = new System.Drawing.Size(144, 27);
			this.customerPhone.TabIndex = 5;
			this.customerPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			this.customerPhone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.CustomerPhoneMaskInputRejected);
			this.customerPhone.TabIndexChanged += new System.EventHandler(this.CustomerPhoneTabIndexChanged);
			this.customerPhone.TabStopChanged += new System.EventHandler(this.CustomerPhoneTabStopChanged);
			this.customerPhone.Enter += new System.EventHandler(this.CustomerPhoneEnter);
			this.customerPhone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomerPhoneMouseUp);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(78, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 27);
			this.label3.TabIndex = 4;
			this.label3.Text = "Phone";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// customerEmail
			// 
			this.customerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customerEmail.Location = new System.Drawing.Point(170, 114);
			this.customerEmail.Name = "customerEmail";
			this.customerEmail.Size = new System.Drawing.Size(144, 27);
			this.customerEmail.TabIndex = 3;
			this.customerEmail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomerEmailMouseUp);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(78, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 27);
			this.label2.TabIndex = 2;
			this.label2.Text = "Email";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(78, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 27);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// customerName
			// 
			this.customerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customerName.HidePromptOnLeave = true;
			this.customerName.Location = new System.Drawing.Point(170, 49);
			this.customerName.Name = "customerName";
			this.customerName.Size = new System.Drawing.Size(144, 27);
			this.customerName.TabIndex = 0;
			this.customerName.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			this.customerName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.CustomerNameMaskInputRejected);
			this.customerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerNameKeyPress);
			this.customerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CustomerNameKeyUp);
			this.customerName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomerNameMouseUp);
			// 
			// CustomerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 341);
			this.Controls.Add(this.groupBox1);
			this.Name = "CustomerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CustomerForm";
			this.Load += new System.EventHandler(this.CustomerFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button customerSave;
		private System.Windows.Forms.Button customerCancel;
		private System.Windows.Forms.Button customerClear;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.MaskedTextBox customerPhone;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.MaskedTextBox customerEmail;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.MaskedTextBox customerName;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
