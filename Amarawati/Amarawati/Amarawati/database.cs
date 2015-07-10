using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
public class member
{
    public string House_no ;
    public string Name ;
    public string Phone_no = "NULL";
    public string Email = "NULL";
    
}
public class ret
{
    private object p1;
    private object p2;
    private object p3;
    private object p4;
    public ret( object p1,object p2, object p3, object p4)
    {
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
    }
    //ret() { }

}
public class Class1
{
    private SqlConnection sqlConnection = null;
    private SqlCommand sqlCommand = null;
    private SqlDataReader sqlReader = null;
    private string database_name = "amarawati_database.mdf";
    private string strQuery = null;
    
     public List<object[]> get()
    {
        List<object[]> reta=new List<object[]>();
        strQuery = "SELECT house_no, name, phone_no, email FROM Member_Table";
        try
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\"+database_name+";Integrated Security=True");
            sqlConnection.Open();
            sqlCommand = new SqlCommand(strQuery, sqlConnection);
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                object[] aa = { sqlReader[0], sqlReader[1], sqlReader[2], sqlReader[3] };

                reta.Add(aa);
            }
            //MessageBox.Show("ssss");
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            
            Cursor.Current = Cursors.Default;
            sqlConnection.Close();
            if (sqlReader != null)
            {
                sqlReader.Dispose();
                sqlReader = null;
            }
            if (sqlCommand != null)
            {
                sqlCommand.Dispose();
                sqlCommand = null;
            }
            
        }

        return reta;
    }
    
    public void add(member add) 
    {
        strQuery = "INSERT INTO [dbo].[Member_Table] ([house_no], [name], [phone_no], [email]) VALUES ('"+add.House_no+"', '" + add.Name + "','"+add.Phone_no+"','"+add.Email+"')";
        execute();
       // MessageBox.Show("sucess");
    }
    public void edit(member edit, string old)
    {
        strQuery = "UPDATE [dbo].[member_table] SET [house_no]='"+edit.House_no+"', [name]='"+edit.Name+"', [phone_no]='"+edit.Phone_no+"', [email]='"+edit.Email+"' WHERE ([house_no]='"+old+"')";
        execute();
    }

    public void delete(member delete,string old)
    {
        strQuery = "DELETE FROM [dbo].[member_table] WHERE ([house_no]='"+old+"')";
        execute();
    }
    public void execute()
    {
        try
        {
            
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\"+database_name+";Integrated Security=True");
            sqlConnection.Open();
            sqlCommand = new SqlCommand(strQuery, sqlConnection);
            int a= sqlCommand.ExecuteNonQuery();
           // MessageBox.Show(a.ToString());
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        finally
        {
            strQuery = null;
            Cursor.Current = Cursors.Default;
            sqlConnection.Close();
            if (sqlReader != null)
            {
                sqlReader.Dispose();
                sqlReader = null;
            }
            if (sqlCommand != null)
            {
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
    }



}
