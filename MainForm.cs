﻿/*
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
		public static Sqldb db=new Sqldb();
		public static BindingList<KeyValuePair<int, string>> customerBL;
		public DataTable billsDT;
		
		public CustomerForm customerForm;
		public MainForm()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			loadCustomerList();
			
			

		}
		
		//overloaded to allow CustomerForm to call MainForms controls - most likely the wrong way to do it
		
		//TODO Learn how to structure form controls between classes.
		
		public MainForm(bool reload)
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			
			

		}
		
		void MainFormLoad(object sender, EventArgs e)
		{

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
		
		public void loadCustomerList(int index){
			//TODO fix loadcustomerlist so that it picks the previously selected item for after the edit.

//			MessageBox.Show(customerBL[index].ToString());
//			MessageBox.Show(customerList.SelectedItem.ToString());
			//overloaded for saving current customer so customerlist selected index is for current customer
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
//			MessageBox.Show(customerList.SelectedIndex.ToString());
//				MessageBox.Show(customerList.SelectedValue.ToString());
			if(Convert.ToInt32(customerList.SelectedValue)<0){return;}
			
			if(checkCustomerForm()==true)
			{customerForm.Close();}
			else
			{
				customerForm=new CustomerForm(Convert.ToInt32(customerList.SelectedValue));
				customerForm.CustomerListIndex=customerList.SelectedIndex;
				customerForm.Text="Edit Customer Info";
				Customer currentCustomer=db.getCustomer(Convert.ToInt32(customerForm.CustomerIndex));
				customerForm.customerName.Text=currentCustomer.Name;
				customerForm.customerEmail.Text=currentCustomer.Email;
				customerForm.customerPhone.Text=currentCustomer.Phone;
				customerForm.CustomerIndex=currentCustomer.ID;
				customerForm.Show();}
			
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
			//billsGrid.Columns["customer_id"].Visible=false;
			billsGrid.Columns["date"].HeaderText="Date";
			//billsGrid.Columns["amount"].HeaderText="Amount";
			billsGrid.Columns["amount"].Visible=false;
			billsGrid.Columns["amountstring"].HeaderText="Amount";
			billsGrid.Columns["complete"].Visible=false;
			
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
		
		void MainFormEnter(object sender, EventArgs e)
		{
			
		}
	}
}
