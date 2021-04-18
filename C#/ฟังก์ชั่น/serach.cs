//in asp .net mvc
public ViewResult Search(string sortOrder, string searchString)
{
    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
    var students = from s in db.Students
                   select s;
    if (!String.IsNullOrEmpty(searchString))
    {
        students = students.Where(s => s.LastName.Contains(searchString)
                               || s.FirstMidName.Contains(searchString));
    }
    switch (sortOrder)
    {
        case "name_desc":
            students = students.OrderByDescending(s => s.LastName);
            break;
        case "Date":
            students = students.OrderBy(s => s.EnrollmentDate);
            break;
        case "date_desc":
            students = students.OrderByDescending(s => s.EnrollmentDate);
            break;
        default:
            students = students.OrderBy(s => s.LastName);
            break;
    }

    return View(students.ToList());
}


//in web form

private void rep_bind()
{
    connection();
    string query = "select * from emp where Name like '" + TextBox1.Text + "%'";
    SqlDataAdapter da = new SqlDataAdapter(query, con);
    DataSet ds = new DataSet();
    da.Fill(ds);
    GridView1.DataSource = ds;
    GridView1.DataBind();
}


private void Button_Click(sender dr )
{
    if (dr.HasRows)
    {
        dr.Read();
        rep_bind();
        GridView1.Visible = true;
        TextBox1.Text = "";
        Label1.Text = "";
    }
    else
    {
        GridView1.Visible = false;
        Label1.Visible = true;
        Label1.Text = "The search Term " + TextBox1.Text + " Is Not Available in the Records";
    }
}