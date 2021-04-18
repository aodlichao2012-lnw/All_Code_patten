//asp.net mvc

public ViewResult pagging(string sortOrder, string currentFilter, string searchString, int? page)
{
    ViewBag.CurrentSort = sortOrder;
    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

    if (searchString != null)
    {
        page = 1;
    }
    else
    {
        searchString = currentFilter;
    }

    ViewBag.CurrentFilter = searchString;

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
        default:  // Name ascending 
            students = students.OrderBy(s => s.LastName);
            break;
    }

    int pageSize = 3;
    int pageNumber = (page ?? 1);
    return View(students.ToPagedList(pageNumber, pageSize));

    //ถ้าจะ return ให้เป็น json
    //string output = JsonConvert.SerializeObject(ชื่อ list หรือ ชื่อ model ก็ได้);
    //JsonConvert.DeserializeObject<students>(output)
}


//winform

private void Paging(int pagenum, int pagesize)
{

    if (currentPage < 0) { currentPage = 0; return; }

    flowLayoutPanel1.Controls.OfType<Label>().Where(e => e.Tag.ToString() != (pagenum + 1).ToString())
        .ToList().ForEach((element) =>
        {
            element.ForeColor = Color.Black;
        });

    flowLayoutPanel1.Controls.OfType<Label>().Where(e => e.Tag.ToString() == (pagenum + 1).ToString())
        .First().ForeColor = Color.Red;



    textBox1.Text = "Page " + (pagenum + 1) + " of " + (int)(_sampleDataList.Count / pagesize);

    var products = from p in _sampleDataList.Skip(pagenum * pagesize).Take(pagesize)
                   select new { ID = p.ID, Name = p.Name, Age = p.Age, Address = p.Address };

    dataGridView1.DataSource = products.ToList();
}


private void button1_Click(object sender, EventArgs e)
{
    currentPage = 0;
    Paging(currentPage, currentSize);
}

private void button2_Click(object sender, EventArgs e)
{
    currentPage = (currentPage - currentSize) < 0 ? (currentPage - 1) : 0;
    Paging(currentPage, currentSize);
}

private void button3_Click(object sender, EventArgs e)
{
    currentPage = ((currentPage + 1) * currentSize) < _sampleDataList.Count() ?
        (currentPage + 1) : currentPage;
    Paging(currentPage, currentSize);
}

private void button4_Click(object sender, EventArgs e)
{
    currentPage = (_sampleDataList.Count() / currentSize) - 1;
    Paging(currentPage, currentSize);
}

//asp.net web form


protected void Page_Load(object sender, EventArgs e)
{
    BindData();
}
protected void BindData()
{
    string strConnection = "Data Source=.; uid=sa; pwd=wintellect;database=Rohatash;";
    SqlConnection con = new SqlConnection(strConnection);
    con.Open();
    SqlCommand cmd = new SqlCommand("select * from Userinfo", con);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(ds);
    GridView1.DataSource = ds;
    GridView1.DataBind();
    con.Close();
}

protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    GridView1.PageIndex = e.NewPageIndex;
    BindData();
}