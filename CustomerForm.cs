/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/20/2014
 * Time: 9:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.ComponentModel;
using  System.Collections.Generic;

namespace CustomerDebt
{
	/// <summary>
	/// Description of CustomerForm.
	/// </summary>
	public partial class CustomerForm : Form
	{
		ToolTip customerFormToolTip=new ToolTip();
		

		int customerIndex;
		int customerListIndex;
		
		public int CustomerListIndex {
			get { return customerListIndex; }
			set { customerListIndex = value; }
		}
		
		public int CustomerIndex {
			get { return customerIndex; }
			set { customerIndex = value; }
		}
		public CustomerForm()
		{

			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.CustomerIndex=-1;
			//customerindex==-1 if new user
			
		}
		
//		public setCustomerList(){
//		foreach (Form f in Application.OpenForms)
//			{
//				if (f.Text == "MainForm")
//				{
//					//  IsOpen = true;
//				//	IsOpen=true;
//
//					// break;
//
//				}
//
//			}
//		}
		
		public CustomerForm( int customerIndex){
			
			
			InitializeComponent();
			
			this.customerIndex=customerIndex;
			
		}
		
		void CustomerFormLoad(object sender, EventArgs e)
		{
			
		}
		
		public bool checkIfEmail(string checkemail){
			
			//if(this.customerEmail.Text.ToString()==string.Empty){return false;}
			string regex=@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$";
			return Regex.IsMatch(checkemail,regex,RegexOptions.IgnoreCase);
			
			
			
		}
		
		void CustomerClearClick(object sender, EventArgs e)
		{
			customerName.Text="";
			customerPhone.Text="";
			customerEmail.Text="";
			customerName.Focus();
		}
		
		void CustomerCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
		void CustomerSaveClick(object sender, EventArgs e)
		{
			//check if fields are filled out
			if(this.customerName.MaskCompleted && this.customerName.Text.Trim() != string.Empty && this.customerEmail.MaskCompleted && checkIfEmail(this.customerEmail.Text.Trim()) && this.customerPhone.MaskCompleted)
			{
				
				//all fields are filled out
				if(this.CustomerIndex<0)
				{
					//new customer
					
					Customer newCustomer=new Customer(UppercaseWords(this.customerName.Text.Trim()),this.customerEmail.Text.Trim(),this.customerPhone.Text.Trim());
					int returnedInt=MainForm.db.addCustomer(newCustomer);
					//MainForm.customerBL.Add(new KeyValuePair<int, string>(returnedInt, newCustomer.Name));
					
					this.CustomerIndex=returnedInt;
							ResetCustomerList( new MainForm(true));
						
					this.Close();
				}
				else
				{
					//current customer..update
					Customer editCustomer=new Customer(this.CustomerIndex,UppercaseWords(this.customerName.Text.Trim()),this.customerEmail.Text.Trim(),this.customerPhone.Text.Trim());
					MainForm.db.editCustomer(editCustomer);
					MainForm myMainForm=(MainForm)Application.OpenForms["MainForm"];
					//ResetCustomerList( new MainForm(true),this.CustomerListIndex);
									ResetCustomerList( myMainForm,this.CustomerListIndex);
					
					this.Close();
				}


			}else{

				//fields missing
MessageBox.Show("Please check input and retry.","Customer Input Error");
				this.customerName.Focus();

				return;
			}
			
			
			
			
			
			
			
		}
		
		void CustomerPhoneMaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
			
		}
		void ResetCustomerList(MainForm myForm){
	
			myForm.loadCustomerList();
	
		}
		
			void ResetCustomerList(MainForm myForm, int customerListIndex){
	
			myForm.loadCustomerList(customerListIndex);
		
			myForm.customerList.SelectedItem=MainForm.customerBL[customerListIndex];
//		myForm.customerList.SetSelected(CustomerListIndex,true);
//			myForm.customerList.SelectedIndex=CustomerListIndex;
		
		}
		
		void CustomerPhoneEnter(object sender, EventArgs e)
		{
			
			//	customerPhone.Select(1,customerPhone.Text.Length);
			
		}
		
		void CustomerPhoneMouseUp(object sender, MouseEventArgs e)
		{
			//customerPhone.Select(0,0);
		}
		
		void CustomerEmailMouseUp(object sender, MouseEventArgs e)
		{
			//customerEmail.Select(0,customerEmail.Text.Length);
		}
		
		void CustomerNameKeyUp(object sender, KeyEventArgs e)
		{
		}
		
		void CustomerNameMouseUp(object sender, MouseEventArgs e)
		{
			
			//customerName.Select(0,customerName.Text.Length);
		}
		
		void CustomerPhoneTabStopChanged(object sender, EventArgs e)
		{
			//	customerPhone.Select(0,customerPhone.Text.Length);
		}
		
		void CustomerPhoneTabIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void CustomerNameMaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
			
		}
		
		void CustomerNameKeyPress(object sender, KeyPressEventArgs e)
		{
			if(!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar)){
				e.Handled=true;
			}
			
		}
		
		
		
		static string UppercaseWords(string value)
		{
			char[] array = value.ToCharArray();
			// Handle the first letter in the string.
			if (array.Length >= 1)
			{
				if (char.IsLower(array[0]))
				{
					array[0] = char.ToUpper(array[0]);
				}
			}
			// Scan through the letters, checking for spaces.
			// ... Uppercase the lowercase letters following spaces.
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i - 1] == ' ')
				{
					if (char.IsLower(array[i]))
					{
						array[i] = char.ToUpper(array[i]);
					}
				}
			}
			return new string(array);
		}
	}
}
