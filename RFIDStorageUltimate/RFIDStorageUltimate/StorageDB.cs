using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

namespace RFIDStorageUltimate
{
    public class StorageDB
    {
        private DataSet dataSet;
        private String connectionString = Properties.Settings.Default.db_StorageConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        public DataTable GoodsTable
        {
            get
            {
                return dataSet.Tables["GoodsTable"];
            }
        }
        public DataTable RegisterTable
        {
            get
            {
                return dataSet.Tables["RegisterTable"];
            }
        }
        public DataTable DetailedRegisterTable
        {
            get
            {
                return dataSet.Tables["DetailedRegisterTable"];
            }
        }
        public DataTable InTable
        {
            get
            {
                return dataSet.Tables["InTable"];
            }
        }
        public DataTable OutTable
        {
            get
            {
                return dataSet.Tables["OutTable"];
            }
        }
        public DataTable UserTable
        {
            get
            {
                return dataSet.Tables["UserTable"];
            }
        }
        private DataTable searchRegisterTable;
        public DataTable SearchRegisterTable
        {
            get
            {
                return searchRegisterTable;
            }
        }
        private DataTable searchInTable;
        public DataTable SearchInTable
        {
            get
            {
                return searchInTable;
            }
        }
        private DataTable searchOutTable;
        public DataTable SearchOutTable
        {
            get
            {
                return searchOutTable;
            }
        }
        public StorageDB()
        {
            dataSet = new DataSet();
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.CommandTimeout = 15;
            command.UpdatedRowSource = UpdateRowSource.Both;
            adapter = new SqlDataAdapter();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataSet.Tables.Add("GoodsTable");
            dataSet.Tables.Add("RegisterTable");
            dataSet.Tables.Add("DetailedRegisterTable");
            dataSet.Tables.Add("InTable");
            dataSet.Tables.Add("OutTable");
            dataSet.Tables.Add("UserTable");
            searchRegisterTable = new DataTable();
            searchInTable = new DataTable();
            searchOutTable = new DataTable();
            searchRegisterTable.Columns.Add(new DataColumn("GoodsNumber", typeof(String)));
            searchRegisterTable.Columns.Add(new DataColumn("GoodsName", typeof(String)));
            searchRegisterTable.Columns.Add(new DataColumn("GoodsDescription", typeof(String)));
            searchInTable.Columns.Add(new DataColumn("GoodsName", typeof(String)));
            searchInTable.Columns.Add(new DataColumn("Datetime", typeof(String)));
            searchInTable.Columns.Add(new DataColumn("UserName", typeof(String)));
            searchInTable.Columns.Add(new DataColumn("GoodsDescription", typeof(String)));
            searchOutTable.Columns.Add(new DataColumn("GoodsName", typeof(String)));
            searchOutTable.Columns.Add(new DataColumn("Datetime", typeof(String)));
            searchOutTable.Columns.Add(new DataColumn("UserName", typeof(String)));
            searchOutTable.Columns.Add(new DataColumn("GoodsDescription", typeof(String)));
            GetTable("GoodsTable");
            GetTable("RegisterTable");
            GetTable("DetailedRegisterTable");
            GetTable("InTable");
            GetTable("OutTable");
            GetTable("UserTable");
        }

        public void GetTable(String TableName)
        {
            try
            {
                //connection.Open();
                switch (TableName)
                {
                    case "GoodsTable":
                        command.CommandText = "GetGoodsTableProcedure";
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet, "GoodsTable");
                        break;
                    case "RegisterTable":
                        command.CommandText = "GetRegisterTableProcedure";
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet, "RegisterTable");
                        break;
                    case "DetailedRegisterTable":
                        command.CommandText = "GetDetailedRegisterTableProcedure";
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet, "DetailedRegisterTable");
                        break;
                    case "InTable":
                        command.CommandText = "GetInTableProcedure";
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet, "InTable");
                        break;
                    case "OutTable":
                        command.CommandText = "GetOutTableProcedure";
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet, "OutTable");
                        break;
                    case "UserTable":
                        command.CommandText = "GetUserTableProcedure";
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet, "UserTable");
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                
            }
            finally
            {
                //connection.Close();
                //command.Parameters.Clear();
            }
        }

        public String LoginCheck(String Username, String Password)
        {
            try
            {
                if (UserTable.Rows.Contains(Username) && UserTable.Rows.Find(Username)[1].ToString() == Password)
                {
                    if (UserTable.Rows.Find(Username)[2].ToString() == "True")
                    {
                        return "MANAGER";
                    }
                    else
                    {
                        return "USER";
                    }
                }
                else
                {
                    return "NO";
                }
            }
            catch
            {
                return "ERROR";
            }
        }

        public Boolean UpdateTable(String TableName)
        {
            try
            {
                switch (TableName)
                {
                    case "GoodsTable":
                        command.CommandText = "GetGoodsTableProcedure";
                        adapter.SelectCommand = command;
                        SqlCommandBuilder GoodsTableBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet.Tables["GoodsTable"]);
                        return true;
                    case "RegisterTable":
                        command.CommandText = "GetRegisterTableProcedure";
                        adapter.SelectCommand = command;
                        SqlCommandBuilder RegisterTableBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet.Tables["RegisterTable"]);
                        return true;
                    case "InTable":
                        command.CommandText = "GetInTableProcedure";
                        adapter.SelectCommand = command;
                        SqlCommandBuilder InTableBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet.Tables["InTable"]);
                        return true;
                    case "OutTable":
                        command.CommandText = "GetOutTableProcedure";
                        adapter.SelectCommand = command;
                        SqlCommandBuilder OutTableBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet.Tables["OutTable"]);
                        return true;
                    case "UserTable":
                        command.CommandText = "GetUserTableProcedure";
                        adapter.SelectCommand = command;
                        SqlCommandBuilder UserTableBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet.Tables["UserTable"]);
                        return true;
                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }

        public Boolean AddGoods()
        {
            try
            {
                dataSet.Tables["GoodsTable"].Rows.Add(new object[] { "???", "???", 0, "???" });
                if (UpdateTable("GoodsTable"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean DeleteGoods(String GoodsNumber)
        {
            try
            {
                dataSet.Tables["GoodsTable"].Rows.Find(GoodsNumber).Delete();
                if (UpdateTable("GoodsTable"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean UpdateGoods()
        {
            if (UpdateTable("GoodsTable"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean AddUser()
        {
            try
            {
                dataSet.Tables["UserTable"].Rows.Add(new object[] { "???", "???", false });
                if (UpdateTable("UserTable"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean DeleteUser(String UserName)
        {
            try
            {
                if (!(Boolean)((DataRow)(UserTable.Rows.Find(UserName)))[2])
                {
                    dataSet.Tables["UserTable"].Rows.Find(UserName).Delete();
                    if (UpdateTable("UserTable"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean UpdateUser()
        {
            if (UpdateTable("UserTable"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean RegisterLabel(String UID,String GoodsNumber)
        {
            try
            {
                if (RegisterTable.Rows.Contains(UID))
                {
                    RegisterTable.Rows.Find(UID)[1] = GoodsNumber;
                    if (UpdateTable("RegisterTable"))
                    {
                        GetTable("DetailedRegisterTable");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    dataSet.Tables["RegisterTable"].Rows.Add(new object[] { UID, GoodsNumber });
                    if (UpdateTable("RegisterTable"))
                    {
                        GetTable("DetailedRegisterTable");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean DeleteLabel(String UID)
        {
            try
            {
                if (dataSet.Tables["RegisterTable"].Rows.Contains(UID))
                {
                    dataSet.Tables["RegisterTable"].Rows.Find(UID).Delete();
                    if (UpdateTable("RegisterTable"))
                    {
                        GetTable("DetailedRegisterTable");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean InOperate(Hashtable UIDToGoodsNumber, String UserName)
        {
            String UID;
            String GoodsNumber;
            String GoodsName;
            String GoodsDescription;
            foreach (DictionaryEntry diction in UIDToGoodsNumber)
            {
                UID = diction.Key.ToString();
                GoodsNumber = diction.Value.ToString();
                if (GoodsNumber == "没注册")
                {
                    break;
                }
                else
                {
                    GoodsName = ((DataRow)(GoodsTable.Rows.Find(GoodsNumber)))[1].ToString();
                    GoodsDescription = ((DataRow)(GoodsTable.Rows.Find(GoodsNumber)))[3].ToString();
                    dataSet.Tables["InTable"].Rows.Add(new object[] { null, UID, DateTime.Now,UserName, GoodsNumber, GoodsName, GoodsDescription});
                    (GoodsTable.Rows.Find(GoodsNumber))[2] = Convert.ToInt32((GoodsTable.Rows.Find(GoodsNumber))[2]) + 1;
                }
            }
            try
            {

                if (UpdateTable("InTable") && UpdateTable("GoodsTable"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Boolean OutOperate(Hashtable UIDToGoodsNumber, String UserName)
        {
            String UID;
            String GoodsNumber;
            String GoodsName;
            String GoodsDescription;
            foreach (DictionaryEntry diction in UIDToGoodsNumber)
            {
                UID = diction.Key.ToString();
                GoodsNumber = diction.Value.ToString();
                if (GoodsNumber == "没注册")
                {
                    break;
                }
                else
                {
                    GoodsName = ((DataRow)(GoodsTable.Rows.Find(GoodsNumber)))[1].ToString();
                    GoodsDescription = ((DataRow)(GoodsTable.Rows.Find(GoodsNumber)))[3].ToString();
                    dataSet.Tables["OutTable"].Rows.Add(new object[] { null, UID, DateTime.Now, UserName, GoodsNumber, GoodsName, GoodsDescription });
                    if (Convert.ToInt32((GoodsTable.Rows.Find(GoodsNumber))[2]) <= 0)
                    {
                        return false;
                    }
                    (GoodsTable.Rows.Find(GoodsNumber))[2] = Convert.ToInt32((GoodsTable.Rows.Find(GoodsNumber))[2]) - 1;
                }
            }
            try
            {

                if (UpdateTable("OutTable") && UpdateTable("GoodsTable"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Search(String UID)
        {
            SearchRegisterTable.Clear();
            SearchInTable.Clear();
            searchOutTable.Clear();
            String GoodsNumber;
            String GoodsName;
            String GoodsDescription;
            if (RegisterTable.Rows.Contains(UID))
            {
                GoodsNumber = ((DataRow)(RegisterTable.Rows.Find(UID)))[1].ToString();
                GoodsName = ((DataRow)(GoodsTable.Rows.Find(GoodsNumber)))[1].ToString();
                GoodsDescription = ((DataRow)(GoodsTable.Rows.Find(GoodsNumber)))[3].ToString();
                DataRow dr = SearchRegisterTable.NewRow();
                dr[0] = GoodsNumber;
                dr[1] = GoodsName;
                dr[2] = GoodsDescription;
                SearchRegisterTable.Rows.Add(dr);
            }
            DataRow[] IndataRows = dataSet.Tables["InTable"].Select("In_UID = '" + UID + "'");
            DataRow[] OutdataRows = dataSet.Tables["OutTable"].Select("Out_UID = '" + UID + "'");
            DataRow temp;
            foreach (DataRow r in IndataRows)
            {
                temp = SearchInTable.NewRow();
                temp[0] = r[5];
                temp[1] = r[2];
                temp[2] = r[3];
                temp[3] = r[6];
                SearchInTable.Rows.Add(temp);
            }
            foreach (DataRow r in OutdataRows)
            {
                temp = SearchOutTable.NewRow();
                temp[0] = r[5];
                temp[1] = r[2];
                temp[2] = r[3];
                temp[3] = r[6];
                SearchOutTable.Rows.Add(temp);
            }
        }
    }
}
