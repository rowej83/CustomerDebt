/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/19/2014
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.ComponentModel;
using System.Data;

namespace CustomerDebt
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public BindingList<KeyValuePair<int, string>> customerBL;
		public DataTable billsDT;
		Sqldb db=new Sqldb();
		public CustomerForm customerForm;
		public MainForm()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			loadCustomerList();
			
			

		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
			//customerList.DisplayName="Value";
			//db.testselect();
//			if(CustomerList.Items.Count==0){
			//EditCustomer.Enabled=false;
//			DeleteCustomer.Enabled=false;
//			}
		}
		
		public void loadCustomerList(){
			
			
			
			customerList.ValueMember="Key";
			customerList.DisplayMember="Value";
			customerBL=db.GetCustomerNames();
			customerList.DataSource=customerBL;
			
			if(customerList.SelectedValue!=null){
				editCustomer.Enabled=true;
				deleteCustomer.Enabled=true;
				
			}else{
				editCustomer.Enabled=false;
				deleteCustomer.Enabled=false;
			}
		}
		public void nullCustomerList(){
			
			customerList.DataSource=null;
		}
		
		void CustomerListSelectedIndexChanged(object sender, EventArgs e)
		{
			//MessageBox.Show(customerList.SelectedValue.ToString());
			if(customerList.Items.Count!=0){
				loadBills(Convert.ToInt32(customerList.SelectedValue));
				editCustomer.Enabled=true;
				deleteCustomer.Enabled=true;
			}
			
		}
		
		void EditCustomerClick(object sender, EventArgs e)
		{
			
			if(Convert.ToInt32(customerList.SelectedValue)<0){return;}
			
			if(checkCustomerForm()==true)
			{customerForm.Close();}
			else
			{
				customerForm=new CustomerForm(Convert.ToInt32(customerList.SelectedValue));
				customerForm.Text="Edit Customer Info";
				Customer currentCustomer=db.getCustomer(Convert.ToInt32(customerForm.CustomerIndex));
				customerForm.customerName.Text=currentCustomer.Name;
				customerForm.customerEmail.Text=currentCustomer.Email;
				customerForm.customerPhone.Text=currentCustomer.Phone;
				customerForm.Show();}
			//customerForm=new CustomerForm();
			//customerForm.Show();
		}
		
		public bool checkCustomerForm(){
			
			bool IsOpen = false;
			foreach (Form f in Application.OpenForms)
			{
				if (f.Text == "CustomerForm")
				{
					//  IsOpen = true;
					IsOpen=true;
					
					// break;
					
				}
				
			}
			return IsOpen;
		}
		
		public void loadBills(int index){
			billsDT=db.getBills(index);
			billsGrid.DataSource=billsDT;
			billsGrid.Columns["id"].Visible=false;
			billsGrid.Columns["customer_id"].Visible=false;
			billsGrid.Columns["amount"].HeaderText="Amount";
			billsGrid.Columns["complete"].Visible=false;
			billsGrid.Columns["partial"].HeaderText="Partial";
			billsGrid.Columns["date"].HeaderText="Date";
			
		}
		
		
		public void DeleteCustomerClick(object sender, EventArgs e)
		{
			int deleteIndex =Convert.ToInt32(customerList.SelectedValue);
			DialogResult result=MessageBox.Show("Are you sure you want to delete this customer?","Confirm Deletion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if(result==DialogResult.Yes){
				db.deleteCustomer(deleteIndex);
				if ( customerList.SelectedIndex != -1 ){
					customerBL.RemoveAt(customerList.SelectedIndex );
					
					if(customerList.Items.Count==0){
						deleteCustomer.Enabled=false;
						editCustomer.Enabled=false;
					}
				}
				//loadCustomerList();
			}
		}
		
		void BillsGridDataSourceChanged(object sender, EventArgs e)
		{
			
		}
		
		void CustomerListDataSourceChanged(object sender, EventArgs e)
		{
			
		}
		
		void CreateCustomerClick(object sender, EventArgs e)
		{
			
			if(checkCustomerForm()==true)
			{
				customerForm.Close();
				
			}
			else
			{
				customerForm=new CustomerForm();
				customerForm.Text="Create Customer";
				
				customerForm.Show();
			}
			
			
		}
	}
}
