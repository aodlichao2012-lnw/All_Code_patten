static void Converttojson(string[] args)
{
    List<Employee> lstemployee = new List<Employee>();
    lstemployee.Add(new Employee()
    {
        EmployeeID = 100,
        EmployeeName = "Pradeep",
        DeptWorking = "OnLineBanking",
        Salary = 10000
    });
    lstemployee.Add(new Employee()
    {
        EmployeeID = 101,
        EmployeeName = "Mark",
        DeptWorking = "OnLineBanking",
        Salary = 20000
    });
    lstemployee.Add(new Employee()
    {
        EmployeeID = 102,
        EmployeeName = "Smith",
        DeptWorking = "Mobile banking",
        Salary = 10000
    });
    lstemployee.Add(new Employee()
    {
        EmployeeID = 103,
        EmployeeName = "John",
        DeptWorking = "Testing",
        Salary = 7000
    });
    string output = JsonConvert.SerializeObject(lstemployee);
    Console.WriteLine(output);
    Console.ReadLine();
    List<Employee> deserializedProduct = JsonConvert.DeserializeObject<List<Employee>>(output);
}



static void Main()
{
    var obj = new Lad
    {
        firstName = "Markoff",
        lastName = "Chaney",
        dateOfBirth = new MyDate
        {
            year = 1901,
            month = 4,
            day = 30
        }
    };
    var json = new JavaScriptSerializer().Serialize(obj);
    Console.WriteLine(json);
}