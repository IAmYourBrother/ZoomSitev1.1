﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
/*
 *Collection of SQL Commands 
 * made easier through classes
 */
namespace IT191P_Project.App_Code
{
    public class SQLManager
    {
        //=========ADD========//
        public static void SQLAdd(_User U)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO [USER] VALUES(@LNAME, @FNAME, @MNAME, @SEX, @MOBILENO, @PASSWORD, @USERNAME, @TYPE, @EMAIL)", sqlconnect);

            add.Parameters.AddWithValue("LNAME", U.Lname);
            add.Parameters.AddWithValue("FNAME", U.Fname);
            add.Parameters.AddWithValue("MNAME", U.Mname);
            add.Parameters.AddWithValue("SEX", U.Sex);
            add.Parameters.AddWithValue("MOBILENO", U.MobileNo);
            add.Parameters.AddWithValue("PASSWORD", U.Password);
            add.Parameters.AddWithValue("USERNAME", U.Username);
            add.Parameters.AddWithValue("TYPE", U.Type);
            add.Parameters.AddWithValue("EMAIL", U.Email);

            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();

        }
        //=========END_ADD========//

        //=========LOGIN VALIDATE========//
        public static string SQLValidate(int id)
        {
                string usertype;
                var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
                string connection = cs.ConnectionString;

                SqlConnection sqlconnect = new SqlConnection(connection);
                string validate = "SELECT [USERTYPE] FROM [USER] WHERE ID = '" + id.ToString() + "'";

                SqlDataAdapter ad = new SqlDataAdapter(validate, sqlconnect);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                usertype = dt.Rows[0]["USERTYPE"].ToString();
                return usertype;

        }
        //=========END_LOGINVALIDATE=====//


        //=========EDIT========//
        public static void SQLEdit(_User u)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand edit = new SqlCommand("UPDATE [USER] SET [LNAME]=@LNAME, [FNAME]=@FNAME, [MNAME]=@MNAME, [SEX]=@SEX, [EMAIL_ADD]=@EMAIL, [MOBILE_NO]=@MOBILE, [USERNAME]=@USERNAME, [PASSWORD]=@PASS WHERE [ID] = @ID", sqlconnect);

            edit.Parameters.AddWithValue("LNAME", u.Lname);
            edit.Parameters.AddWithValue("FNAME", u.Fname);
            edit.Parameters.AddWithValue("MNAME", u.Mname);
            edit.Parameters.AddWithValue("SEX", u.Sex);
            edit.Parameters.AddWithValue("EMAIL", u.Email);
            edit.Parameters.AddWithValue("MOBILE", u.MobileNo);
            edit.Parameters.AddWithValue("USERNAME", u.Username);
            edit.Parameters.AddWithValue("PASS", u.Password);
            edit.Parameters.AddWithValue("ID", u.UserID);

            sqlconnect.Open();

            edit.ExecuteNonQuery();

            sqlconnect.Close();
        }
        //=========END_EDIT========//

        //=========VIEW========//        
        //RETRIEVE USERDATA THROUGH SESSION LOGIN ID
        public static _User SQLRetrieveUserData(int id)
        {
            _User u;
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(connection);

            SqlCommand com = new SqlCommand("SELECT * FROM [USER] WHERE ID=@ID", con);

            com.Parameters.AddWithValue("ID", id);

            con.Open();

            reader = com.ExecuteReader();
            reader.Read();

            string ln = reader["LNAME"].ToString();
            string fn = reader["FNAME"].ToString();
            string mn = reader["MNAME"].ToString();
            string mobile = reader["MOBILE_NO"].ToString();
            string email = reader["EMAIL_ADD"].ToString();
            string user = reader["USERNAME"].ToString();
            string pass = reader["PASSWORD"].ToString();
            string type = reader["USERTYPE"].ToString();
            char sex = Convert.ToChar(reader["SEX"].ToString());


            u = new _User(ln, fn, mn, mobile, email, user, pass, type, sex);

            con.Close();
            return u;
        }

        //FOR USER CHECKING ONLY, IMPROVE CODE WHEN POSSIBLE (SECURITY)
        public static List<string[]> SQLUserVerification()
        {
            List <string[]> user=new List<string[]>();
            
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(connection);

            SqlCommand com = new SqlCommand("SELECT [USER].ID, [USER].[USERNAME], [USER].[PASSWORD] FROM [USER]", con);


            con.Open();

            reader = com.ExecuteReader();
            while(reader.Read())
            {
                string[] info = new string[3];

                info[0] = reader["ID"].ToString();
                info[1] = reader["USERNAME"].ToString();
                info[2] = reader["PASSWORD"].ToString();
                user.Add(info);
            }

            con.Close();

            return user;
        }
        //=========END_VIEW========//


        //=========Get ID========//
        public static int SQLLastID()
        {
            int lastInsID;
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            string validate = "SELECT IDENT_CURRENT('USER') as LastID";

            SqlDataAdapter ad = new SqlDataAdapter(validate, sqlconnect);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            lastInsID = Convert.ToInt32(dt.Rows[0]["LastID"]);

            return lastInsID;
        }
        //=========END_Get ID=====//

        //=========Add Role=========//
        public static void SQLAdd(_AdminUser AU)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO [USER] VALUES(@LNAME, @FNAME, @MNAME, @SEX, @MOBILENO, @PASSWORD, @USERNAME, @TYPE, @EMAIL)", sqlconnect);

            add.Parameters.AddWithValue("LNAME", AU.Lname);
            add.Parameters.AddWithValue("FNAME", AU.Fname);
            add.Parameters.AddWithValue("MNAME", AU.Mname);
            add.Parameters.AddWithValue("SEX", AU.Sex);
            add.Parameters.AddWithValue("MOBILENO", AU.MobileNo);
            add.Parameters.AddWithValue("PASSWORD", AU.Password);
            add.Parameters.AddWithValue("USERNAME", AU.Username);
            add.Parameters.AddWithValue("TYPE", AU.Type);
            add.Parameters.AddWithValue("EMAIL", AU.Email);

            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();

        }
        //=========END_Add_ROLE=====//

        //================ADD BRANCH================//
        public static void SQLAddBranch(_Branch B)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO BRANCH VALUES(@LOC, @BOWNER)", sqlconnect);

            add.Parameters.AddWithValue("LOC", B.Location);
            add.Parameters.AddWithValue("BOWNER", B.BranchOwnerID);
            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();
        }
        //==============END ADD BRANCH==============//

        //================ADD BRANCH(w/ branch manager)================//
        public static void SQLAddBranchManager(_Branch B)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO BRANCH VALUES(@BMNGR)", sqlconnect);

            add.Parameters.AddWithValue("BMNGR", B.BranchManagerID);
            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();
        }
        //==============END ADD BRANCH(w/ branch manager)==============//


        //============= Generate Package Transac ID====================//
        public string GenerateTransIDPackage()
        {
            string transactionID;
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            sqlconnect.Open();

            string sel = @"SELECT TOP 1 * FROM [PACKAGE_TRANSACTION] ORDER BY [TRANSACT_ID] DESC";
            SqlCommand cmd = new SqlCommand(sel, sqlconnect);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                string id = rd["TRANSACT_ID"].ToString();
                int num = Convert.ToInt32(id.TrimStart('P'));
                int zerolength;
                num++;
                if (num > 0 && num < 10)
                    zerolength = 4;
                else if (num >= 10 && num < 99)
                    zerolength = 3;
                else if (num >= 100 && num < 999)
                    zerolength = 2;
                else if (num >= 1000 && num < 9999)
                    zerolength = 1;
                else
                    zerolength = 0;
                    
                
                string newid = null;
                for (int i = 0; i < zerolength; i++)
                {
                    newid = newid + "0";
                }
                newid = newid + num.ToString();
                transactionID = "P" + newid;
            }
            else
                transactionID = "P00001";

            rd.Close();
            sqlconnect.Close();

            return transactionID;
        }
        //======================== END GENERATE TRANSACT ID ============================//


        //============= Generate Money Transac ID====================//
        public string GenerateTransIDMoney()
        {
            string transactionID;
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            sqlconnect.Open();

            string sel = @"SELECT TOP 1 * FROM [MONEY_TRANSACTION] ORDER BY [TRANSACT_ID] DESC";
            SqlCommand cmd = new SqlCommand(sel, sqlconnect);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                string id = rd["TRANSACT_ID"].ToString();
                int num = Convert.ToInt32(id.TrimStart('M'));
                int zerolength;
                num++;
                if (num > 0 && num < 10)
                    zerolength = 4;
                else if (num >= 10 && num < 99)
                    zerolength = 3;
                else if (num >= 100 && num < 999)
                    zerolength = 2;
                else if (num >= 1000 && num < 9999)
                    zerolength = 1;
                else
                    zerolength = 0;

                string newid = null;
                for (int i = 0; i < zerolength; i++)
                {
                    newid = newid + "0";
                }
                newid = newid + num.ToString();
                transactionID = "M" + newid;
            }
            else
                transactionID = "M00001";

            rd.Close();
            sqlconnect.Close();

            return transactionID;
        }
        //======================== END GENERATE TRANSACT ID ============================//

        //==================Add Package transaction to [PACKAGE_TRANSACTION]===================//
        public void SQLAddPackageTrans(_PackageTransaction pt)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO [PACKAGE_TRANSACTION] VALUES(@TRANSAC_ID, @NET_WEIGHT, @AMOUNT, @source_addr, @desti_addr, @packDesc)", sqlconnect);

            add.Parameters.AddWithValue("TRANSAC_ID", pt.PackageTransactionID);
            add.Parameters.AddWithValue("NET_WEIGHT", pt.Weight);
            add.Parameters.AddWithValue("AMOUNT", pt.Amount);
            add.Parameters.AddWithValue("source_addr", pt.SourceAddr);
            add.Parameters.AddWithValue("desti_addr", pt.DestinationAddr + pt.City);
            add.Parameters.AddWithValue("packDesc", pt.PackageDesc);

            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();
        }
        //==================End add package=========================//

        //==================Add money transaction to [MONEY_TRANSACTION]===================//
        public void SQLAddMoneyTrans(_MoneyTransaction mt)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO [USER] VALUES(@TRANSACT_ID, @AMOUNT, @DEST_BRANCH ,@RECEIVER_NAME, CHARGE" , sqlconnect);

            add.Parameters.AddWithValue("TRANSACT_ID", mt.TransactionID);
            add.Parameters.AddWithValue("AMOUNT", mt.Amount);
            add.Parameters.AddWithValue("DEST_BRANCH", mt.Destination);
            add.Parameters.AddWithValue("RECEIVER_NAME", mt.Amount);
            add.Parameters.AddWithValue("CHARGE", mt.Charge);

            sqlconnect.Open();
            add.ExecuteNonQuery();
            sqlconnect.Close();
        }
        //==================End add MONEY=========================//

        //==================Check if there is duplicate tracking number=========================//
        public bool ValidateTrackNo(string path)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            sqlconnect.Open();

            string select = "SELECT COUNT(*) FROM [TRANSACTION] WHERE TRACKING_NO = '" + path + "'";
            SqlCommand cmd = new SqlCommand(select, sqlconnect);
            int temp = (int)cmd.ExecuteScalar();
            if (temp > 0)
                return true;
            else
                return false;
        }
        //==================End check=========================//

        internal static void SQLRequestFranchise(_ReqFranchise R)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO ReqFranchise VALUES(@franchisee, @location, @citycode, @years)", sqlconnect);

            add.Parameters.AddWithValue("franchisee", R.franchisee);
            add.Parameters.AddWithValue("location", R.location);
            add.Parameters.AddWithValue("citycode", R.citycode);
            add.Parameters.AddWithValue("years", R.years);

            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();
        }

        public static void SQLCustomerAddr(_CustomerAddress C)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO customerAddress VALUES(@custID, @addr, @cityCode)", sqlconnect);

            add.Parameters.AddWithValue("custID", C.custID);
            add.Parameters.AddWithValue("addr", C.addr);
            add.Parameters.AddWithValue("cityCode", C.cityCode);

            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();
        }

        public bool ValidateCity(string destCity)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            sqlconnect.Open();

            string select = "SELECT COUNT(*) FROM [CITYTOWN] WHERE CODE = '" + destCity + "'";
            SqlCommand cmd = new SqlCommand(select, sqlconnect);
            int temp = (int)cmd.ExecuteScalar();
            if (temp > 0)
                return true;
            else
                return false;
        }

        //========================Add Transaction=========================//
        public void SQLAddTransaction(_Transaction tr)
        {
            var cs = ConfigurationManager.ConnectionStrings["ZoomDB"];
            string connection = cs.ConnectionString;

            SqlConnection sqlconnect = new SqlConnection(connection);
            SqlCommand add = new SqlCommand("INSERT INTO [TRANSACTION] VALUES(@transID, @trackNo, @custID, @source, @destination, @status, @type, @payment)", sqlconnect);

            add.Parameters.AddWithValue("transID", tr.TransactionId);
            add.Parameters.AddWithValue("trackNo", tr.TrackingNo);
            add.Parameters.AddWithValue("custID", tr.CustomerId);
            add.Parameters.AddWithValue("source", tr.Source);
            add.Parameters.AddWithValue("destination", tr.Destination);
            add.Parameters.AddWithValue("status", tr.Status);
            add.Parameters.AddWithValue("type", tr.Type);
            add.Parameters.AddWithValue("payment", tr.Amount);

            sqlconnect.Open();

            add.ExecuteNonQuery();

            sqlconnect.Close();
        }
        //======================End Add transac===========================//
    }
}