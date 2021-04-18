
//web form or win form
protected void lnkselect_Click(object sender, EventArgs e)
{
    LinkButton btn = (LinkButton)sender;
    Session["id"] = btn.CommandArgument;
    con.Open();
    SqlCommand cmd = new SqlCommand("select * from tblemp", con);
    DataTable dt = new DataTable();
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    adp.Fill(dt);
    if (dt.Rows.Count >= 0)
    {
        txtname.Text = dt.Rows[0]["name"].ToString();
        txtmno.Text = dt.Rows[0]["mno"].ToString();

    }
    con.Close();
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
public static string GetCustomers()
{
    string query = "SELECT CustomerId, Name, Country FROM Customers";
    SqlCommand cmd = new SqlCommand(query);
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            using (DataSet ds = new DataSet())
            {
                sda.Fill(ds);
                return ds.GetXml();
            }
        }
    }
}