
namespace Student_Registry.Models
{
    public class StudentRegistry
    {
        public int Id {get; set; }// Every item needs a unique id so clients can address it
        public string Firstname {get; set; }// get allows you to give this property value, set allows us to change it//Pascal Case
        public string Lastname {get; set; }
        public string Hobby {get; set; }
        public string Email {get; set; }
        public string Slackname {get; set; }
    }
}