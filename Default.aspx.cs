using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//資料庫所需之函式庫
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //將要連結的資料庫的資訊進行設定
        string strConn = "server = .\\TOWN20218;database = Test1224;User ID = sa;Password = HAMAstar;Trusted_Connection = True;";

        //建立連線
        SqlConnection myConn = new SqlConnection(strConn);

        //打開連結
        myConn.Open();

        //SQL:選擇某一表單
        string strSQL = @"select * from TableDay";

        //建立SQL命令對象
        SqlCommand myCommand = new SqlCommand(strSQL, myConn);

        //得到Data結果集
        SqlDataReader myDataReader = myCommand.ExecuteReader();

        while (myDataReader.Read())
        {
            if (myDataReader["Year"].ToString() != "")
            {
                TextBox1.Text += myDataReader["Year"].ToString();
                TextBox1.Text += " \\ ";
                TextBox1.Text += myDataReader["Mouth"].ToString();
                TextBox1.Text += " \\ ";
                TextBox1.Text += myDataReader["Day"].ToString();
                TextBox1.Text += Environment.NewLine;                 //跳行
            }
        }

        //取消 myCommadn(SqlCommand)SQL指令的執行
        myCommand.Cancel();

        //關閉 myDataReader(SqlDataReader)物件
        myDataReader.Close();

        //關閉資料庫
        myConn.Close();
    }
}