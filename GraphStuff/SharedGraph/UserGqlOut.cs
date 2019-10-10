namespace hotchocolate_issue_1120.GraphStuff.SharedGraph
{
    public class UserGqlOut
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ForAdminEyesOnly { get; set; } // private api only
        public string RelationToMe { get; set; } // public api only
    }
}