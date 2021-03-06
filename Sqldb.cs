﻿/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 2/18/2014
 * Time: 11:51 AM
 * 
 * 
 */
using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using  System.Collections.Generic;



namespace CustomerDebt
{
	
	
	/// <summary>
	/// Use to connect to local SQLite file da2.db and provide query result for datagridview
	/// </summary>
	///
	public class Sqldb
		
	{
		public BindingList<KeyValuePair<int, string>> customerBL=new BindingList<KeyValuePair<int, string>>();
		//public BindingList<KeyValuePair<int, string>> customerBL=new BindingList<KeyValuePair<int, string>>();
		
		//	public MainForm form;
//		const string fileName = "customerDebt.db";
//		private string connectionString="Data Source=" + fileName + ";Version=3;";
//		public SQLiteConnection sqlConnection;
//		public BindingSource bs;
//		public SQLiteDataAdapter da;
//		public DataTable dt;
//		public SQLiteCommandBuilder cBuilder;
//		public DataSet ds;
		public Sqldb()
		{
			
		}
		
		public BindingList<KeyValuePair<int, string>> GetCustomerNames(){
			customerBL.Clear();
			
			
			
			
			string filename2="customerDebt.db";
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			string mySelectQuery = "select * from customers order by name asc";
			string myBillSelectQuery="select sum(amount) as amountsum,count(id) as billqty from bills where customer_id=@id and complete=0"; 
		string name="";
		int id;
			SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
			//SQLiteConnection sqConnection2 = new SQLiteConnection(myConnString);
			//	SQLiteCommand sqBillCommand=new SQLiteCommand(sqConnection2);
				
			SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery,sqConnection);
			sqCommand.CommandText=mySelectQuery;
			sqConnection.Open();
			//sqConnection2.Open();
			SQLiteDataReader sqReader = sqCommand.ExecuteReader();
			//SQLiteDataReader sqBillReader=null;
			Console.WriteLine("getcustomernames running");
			//form.EditCustomer.Enabled=false;
			try
			{
				while (sqReader.Read())
				{
					//	Console.WriteLine(sqReader.GetInt32(0) + ", " + sqReader.GetString(1));
					//	Console.WriteLine(sqReader["name"] + ", " + sqReader.GetString(1));
				id=Convert.ToInt32(sqReader.GetInt32(0));
				name=sqReader["name"].ToString();
//					sqBillCommand.CommandText=myBillSelectQuery;
//					sqBillCommand.Parameters.AddWithValue("@id",id);
//					sqBillReader=sqBillCommand.ExecuteReader();
//					if(sqBillReader.Read()){
//					//has entry TODO change below tostring to include # of bills and total
//						name=sqReader["name"].ToString();
//					}else{
//					//no entry
//	
//					name=sqReader["name"].ToString();
//					}
//					 
					customerBL.Add(new KeyValuePair<int, string>(id, name));
					//Console.WriteLine("test");
				}
			}
			finally
			{
				// always call Close when done reading.
				sqReader.Close();
				//sqBillReader.Close();
				// always call Close when done reading.
				sqConnection.Close();
				//sqConnection2.Close();
				
			}
			return customerBL;
			
		}
		public void testselect(){
			string filename2="customerDebt.db";
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			string mySelectQuery = "select * from customers where id=2";
			SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
			SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery,sqConnection);
			sqCommand.CommandText=mySelectQuery;
			
			sqConnection.Open();
			SQLiteDataReader sqReader = sqCommand.ExecuteReader();
			Console.WriteLine("test select running");
			//form.EditCustomer.Enabled=false;
			try
			{
				while (sqReader.Read())
				{
					//	Console.WriteLine(sqReader.GetInt32(0) + ", " + sqReader.GetString(1));
					Console.WriteLine(sqReader["name"] + ", " + sqReader.GetString(1));
					
					
				}
			}
			finally
			{
				// always call Close when done reading.
				sqReader.Close();
				// always call Close when done reading.
				sqConnection.Close();
				
			}
		}
		
		public Customer getCustomer(int index){
			Customer returnCustomer=null;
			string filename2="customerDebt.db";
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			string mySelectQuery = "select * from customers where id=@id";
			SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
			SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery,sqConnection);
			sqCommand.CommandText=mySelectQuery;
			sqCommand.Parameters.AddWithValue("@id",index);
			sqConnection.Open();
			//Console.WriteLine("get customer ran");
			SQLiteDataReader sqReader = sqCommand.ExecuteReader();
			try
			{
				if (sqReader.Read())
				{
					//	Console.WriteLine(sqReader.GetInt32(0) + ", " + sqReader.GetString(1));
					//	Console.WriteLine(sqReader["name"] + ", " + sqReader.GetInt32(0)+sqReader["address"]);
					returnCustomer=new Customer(index,sqReader["name"].ToString(),sqReader["email"].ToString(),sqReader["phone"].ToString());
					
				}
			}
			finally
			{
				// always call Close when done reading.
				sqReader.Close();
				// always call Close when done reading.
				sqConnection.Close();
				
			}
			return returnCustomer;
		}
		
		
		public void editCustomer(Customer editCustomer){
			int id=editCustomer.ID;
			string name=editCustomer.Name;
			
			string phone=editCustomer.Phone;
			string email=editCustomer.Email;
			string filename2="customerDebt.db";
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			string mySelectQuery = "update customers set name=@name,phone=@phone,email=@email where id=@id";
			SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
			SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery,sqConnection);
			sqCommand.CommandText=mySelectQuery;
			sqCommand.Parameters.AddWithValue("@id",id);
			sqCommand.Parameters.AddWithValue("@name",name);
		sqCommand.Parameters.AddWithValue("@email",email);
			sqCommand.Parameters.AddWithValue("@phone",phone);
			sqConnection.Open();
			Console.WriteLine("edit  customer ran");
			sqCommand.ExecuteNonQuery();
			sqConnection.Close();
			
		}
		
		public int addCustomer(Customer newCustomer){
			string name=newCustomer.Name;

			string phone=newCustomer.Phone;
			string email=newCustomer.Email;
			string filename2="customerDebt.db";
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			string mySelectQuery = "insert into customers(name,phone,email)  values(@name,@phone,@email);"+"Select last_insert_rowid();";
			SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
			SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery,sqConnection);
			sqCommand.CommandText=mySelectQuery;
			sqCommand.Parameters.AddWithValue("@name",name);
			
			sqCommand.Parameters.AddWithValue("@email",email);
			sqCommand.Parameters.AddWithValue("@phone",phone);
			sqConnection.Open();
			Console.WriteLine("add customer ran");
			int returnInt=Convert.ToInt32(sqCommand.ExecuteScalar())	;
			
			sqConnection.Close();
			return returnInt;
		}
		
		
		
		public void deleteCustomer(int id){

			string filename2="customerDebt.db";
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			
			string myQuery="delete from customers where id=@id";
			string myQuery2="delete from bills where customer_id=@id";
			SQLiteConnection sqConnection = new SQLiteConnection(myConnString);
			SQLiteCommand sqCommand = new SQLiteCommand(myQuery,sqConnection);
			SQLiteCommand sqCommand2=new SQLiteCommand(myQuery2,sqConnection);
			sqCommand2.CommandText=myQuery2;
			sqCommand.CommandText=myQuery;
			sqCommand2.Parameters.AddWithValue("@id",id);
			sqCommand.Parameters.AddWithValue("@id",id);
			
			
			sqConnection.Open();
			
			sqCommand.ExecuteNonQuery();
			sqCommand2.ExecuteNonQuery();
			sqConnection.Close();
			
		}
		
		public DataTable getBills(int index)
		{
			string filename2="customerDebt.db";
			DataTable returnDT=new DataTable();
			string myConnString="Data Source=" + filename2 + ";Version=3;";
			string myQuery="select id,date,amount,complete from bills where customer_id=@id and complete=0";
			SQLiteConnection conn=new SQLiteConnection(myConnString);
			conn.Open();
			
			SQLiteDataAdapter da=new SQLiteDataAdapter(myQuery,conn);
			da.SelectCommand.Parameters.AddWithValue("@id",index);
			da.Fill(returnDT);
			returnDT.Columns.Add("amountstring",typeof(string));
			foreach (DataRow row in returnDT.Rows)
{
				double newAmount=Convert.ToDouble(row["amount"]);
			row["amountstring"] = newAmount.ToString("C");
	
			}
	
			conn.Close();
			conn.Dispose();
			return returnDT;
			
		}
		
		
		
	} // end of class


	

} // end of namespace