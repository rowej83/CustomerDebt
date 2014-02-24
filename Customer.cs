/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/20/2014
 * Time: 9:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CustomerDebt
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Customer
	{
		public int ID{get;set;}
		public string Name{get;set;}
		public string Email{get;set;}
		public string Phone{get;set;}
		
		public Customer(string name,string email, string phone="")
		{
			//used to save new customer whom doesn't have a ID yet
			this.Name=name;	
			this.Email=email;
			this.Phone=phone;
		}
		public Customer(int id,string name,string email, string phone="")
		{
			//used to edit customer who already has a ID
			this.ID=id;
			this.Name=name;
		
			this.Email=email;
			this.Phone=phone;
		}
	}
}
