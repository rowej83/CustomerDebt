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

namespace CustomerDebt
{
	/// <summary>
	/// Description of CustomerForm.
	/// </summary>
	public partial class CustomerForm : Form
	{
		ToolTip customerFormToolTip=new ToolTip();
		

		int customerIndex;
		
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
		}
		
		void CustomerCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
		void CustomerSaveClick(object sender, EventArgs e)
		{
//			MessageBox.Show(customerPhone.Text.ToString());
//			
//			if(checkIfEmail(this.customerEmail.Text.ToString()))
//				
//			{
//				MessageBox.Show("Is valid Email");
//			}else{
//				MessageBox.Show("Not valid email");
//			}
			
			
			
			
		}
		
		void CustomerPhoneMaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
			
		}
	}
}
