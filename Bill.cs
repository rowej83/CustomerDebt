/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/20/2014
 * Time: 9:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CustomerDebt
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Bill
	{
		public int CustomerID{get;set;}
		public string Amount{get;set;}
		public string Partial{get;set;}
		public string Date{get;set;}
		public int Complete{get;set;}
		
		public Bill(int customerID,string amount, string partialamount, string date, int complete)
		{
			this.CustomerID=customerID;
			this.Amount=amount;
			this.Partial=partialamount;
			this.Date=date;
			this.Complete=complete;
			
			
		}
	}
}
