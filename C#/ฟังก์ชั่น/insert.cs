//in web form or win form


protected void btnadd_Click(object sender, EventArgs e)
{
    con.Open();
    string str = "insert into tblemp values('" + txtname.Text + "','" + txtmno.Text + "')";
    SqlCommand cmd = new SqlCommand(str, con);
    cmd.ExecuteNonQuery();
    lblmsg.Text = "Record Inserted Successfully";
    con.Close();
    display();
    cleartxt();
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
public static int InsertCustomer(string name, string country)
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES(@Name, @Country) SELECT SCOPE_IDENTITY()"))
        {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Connection = con;
            con.Open();
            int customerId = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return customerId;
        }
    }
}