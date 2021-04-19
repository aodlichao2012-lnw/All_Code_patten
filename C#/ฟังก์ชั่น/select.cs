
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


//Nssql

  public static object get_data_pm_traf()
        {
            object res = null;
            DataTable dt = new DataTable();

            string connstring = WebConfigurationManager.ConnectionStrings["pkk_conection"].ConnectionString;

            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();

            string strsql;

            strsql = "SELECT * FROM pkk_warning.v_pm_traf_val  ";

            NpgsqlCommand objcmd = new NpgsqlCommand(strsql, conn);
            objcmd.CommandType = CommandType.Text;

            NpgsqlDataReader dr = objcmd.ExecuteReader();

            List<sc_pm_traf_chart> ldata = new List<sc_pm_traf_chart>();
            sc_pm_traf_chart tmp_data = new sc_pm_traf_chart();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    tmp_data = new sc_pm_traf_chart();
                    //tmp_data.yy = Convert.ToInt32(dr["yy"]); 
                    //tmp_data.mm = Convert.ToInt32(dr["mm"]);
                    tmp_data.station = dr["station_name"].ToString();
                    tmp_data.pm = Convert.ToInt32(dr["pm25_val"]);
                    tmp_data.traf = Convert.ToInt32(dr["trafic_val"]);

                    ldata.Add(tmp_data);
                };


            }
            sc_pm_traf_chart[] arr_data = ldata.ToArray();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            res = serializer.Serialize(arr_data);

            return res;
        }
}