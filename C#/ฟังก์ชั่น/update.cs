//web form or winform


protected void btnupdate_Click(object sender, EventArgs e)
{
    con.Open();
    string str = "update tblemp set name='" + txtname.Text + "', mno='" + txtmno.Text + "'where empid='" + Session["id"] + "'";
    SqlCommand cmd = new SqlCommand(str, con);
    cmd.ExecuteNonQuery();
    lblmsg.Text = "Record Updated Successfully";
    con.Close();
    display();
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
public static void UpdateCustomer(int customerId, string name, string country)
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE Customers SET Name = @Name, Country = @Country WHERE CustomerId = @CustomerId"))
        {
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
