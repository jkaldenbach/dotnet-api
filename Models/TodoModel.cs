namespace dotnet_api.Models
{
    public class Todo
    {
        public string id { get; set; }
        public string task { get; set; }
        public string dueDate { get; set; }
        public bool isComplete { get; set; }
    }
}