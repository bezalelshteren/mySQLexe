public class agants
{
    public int Id { get; set; }
    public string CodeName { get; set; }
    public string RealName { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public int MissionsCompleted { get; set; }

    public agants() { }

    public agants(int id, string codename, string realname, string location, string status, int missionscompleted)
    {
        this.Id = id;
        this.CodeName = codename;
        this.RealName = realname;
        this.Location = location;
        this.Status = status;
        this.MissionsCompleted = missionscompleted;
    }
}
