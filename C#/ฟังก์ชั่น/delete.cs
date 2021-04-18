//in web form or winform

protected void btndelete_Click(object sender, EventArgs e)
{
    con.Open();
    SqlCommand cmd = new SqlCommand("delete from tblemp where empid='" + Session["id"] + "'", con);
    cmd.ExecuteNonQuery();
    lblmsg.Text = "Record Deleted";
    con.Close();
    display();
}

public void cleartxt()
{
    txtmno.Text = "";
    txtname.Text = "";
}

public void display() //read
{
    con.Open();
    SqlCommand cmd = new SqlCommand("select * from tblemp", con);
    DataTable dt = new DataTable();
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    adp.Fill(dt);
    GridView1.DataSource = dt;
    GridView1.DataBind();
    con.Close();
}


//web method

[WebMethod]
public static void DeleteCustomer(int customerId)
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId"))
        {
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}