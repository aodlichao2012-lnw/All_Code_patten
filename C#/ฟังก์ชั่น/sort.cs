
//asp.net mvc
public ActionResult sort(string sortOrder)
{
    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
    var students = from s in db.Students
                   select s;
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

    //asp.net webform

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = getdata();//here getdata() method returns data from database;
            Session["data"] = dt;
        }
    }

    protected void ComponentGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = Session["data"] as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirection(e.SortDirection);

            ComponentGridView.DataSource = dataView;
            ComponentGridView.DataBind();
        }
    }

    private string ConvertSortDirection(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }
}


protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
{
    DataTable dtbl = new DataTable();
    dtbl = ;//here get the datatable from db
    if (ViewState["Sort Order"] == null)
    {
        dtbl.DefaultView.Sort = e.SortExpression + " DESC";
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
        ViewState["Sort Order"] = "DESC";
    }
    else
    {
        dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
        ViewState["Sort Order"] = null;
    }
}