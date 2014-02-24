/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/19/2014
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CustomerDebt
{
	partial class MainForm
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
			this.billsGrid = new System.Windows.Forms.DataGridView();
			this.createCustomer = new System.Windows.Forms.Button();
			this.editCustomer = new System.Windows.Forms.Button();
			this.deleteCustomer = new System.Windows.Forms.Button();
			this.customerList = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.billsGrid)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// billsGrid
			// 
			this.billsGrid.AllowUserToAddRows = false;
			this.billsGrid.AllowUserToDeleteRows = false;
			this.billsGrid.AllowUserToResizeRows = false;
			this.billsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.billsGrid.Location = new System.Drawing.Point(13, 23);
			this.billsGrid.Name = "billsGrid";
			this.billsGrid.ReadOnly = true;
			this.billsGrid.RowHeadersVisible = false;
			this.billsGrid.RowTemplate.Height = 24;
			this.billsGrid.Size = new System.Drawing.Size(356, 180);
			this.billsGrid.TabIndex = 5;
			this.billsGrid.DataSourceChanged += new System.EventHandler(this.BillsGridDataSourceChanged);
			// 
			// createCustomer
			// 
			this.createCustomer.Location = new System.Drawing.Point(13, 210);
			this.createCustomer.Margin = new System.Windows.Forms.Padding(4);
			this.createCustomer.Name = "createCustomer";
			this.createCustomer.Size = new System.Drawing.Size(175, 50);
			this.createCustomer.TabIndex = 1;
			this.createCustomer.Text = "&Create Customer";
			this.createCustomer.UseVisualStyleBackColor = true;
			this.createCustomer.Click += new System.EventHandler(this.CreateCustomerClick);
			// 
			// editCustomer
			// 
			this.editCustomer.Location = new System.Drawing.Point(196, 210);
			this.editCustomer.Margin = new System.Windows.Forms.Padding(4);
			this.editCustomer.Name = "editCustomer";
			this.editCustomer.Size = new System.Drawing.Size(98, 50);
			this.editCustomer.TabIndex = 2;
			this.editCustomer.Text = "&Edit Customer";
			this.editCustomer.UseVisualStyleBackColor = true;
			this.editCustomer.Click += new System.EventHandler(this.EditCustomerClick);
			// 
			// deleteCustomer
			// 
			this.deleteCustomer.Location = new System.Drawing.Point(302, 210);
			this.deleteCustomer.Margin = new System.Windows.Forms.Padding(4);
			this.deleteCustomer.Name = "deleteCustomer";
			this.deleteCustomer.Size = new System.Drawing.Size(98, 50);
			this.deleteCustomer.TabIndex = 3;
			this.deleteCustomer.Text = "&Delete Customer";
			this.deleteCustomer.UseVisualStyleBackColor = true;
			this.deleteCustomer.Click += new System.EventHandler(this.DeleteCustomerClick);
			// 
			// customerList
			// 
			this.customerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customerList.FormattingEnabled = true;
			this.customerList.ItemHeight = 22;
			this.customerList.Location = new System.Drawing.Point(13, 23);
			this.customerList.Name = "customerList";
			this.customerList.Size = new System.Drawing.Size(387, 180);
			this.customerList.TabIndex = 4;
			this.customerList.SelectedIndexChanged += new System.EventHandler(this.CustomerListSelectedIndexChanged);
			this.customerList.DataSourceChanged += new System.EventHandler(this.CustomerListDataSourceChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.customerList);
			this.groupBox1.Controls.Add(this.deleteCustomer);
			this.groupBox1.Controls.Add(this.editCustomer);
			this.groupBox1.Controls.Add(this.createCustomer);
			this.groupBox1.Location = new System.Drawing.Point(12, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(412, 273);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Customers";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.billsGrid);
			this.groupBox2.Location = new System.Drawing.Point(430, 28);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox2.Size = new System.Drawing.Size(382, 273);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bills";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(823, 457);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CustomerDebt";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.billsGrid)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView billsGrid;
		private System.Windows.Forms.ListBox customerList;
		private System.Windows.Forms.Button deleteCustomer;
		private System.Windows.Forms.Button editCustomer;
		private System.Windows.Forms.Button createCustomer;
	}
}
