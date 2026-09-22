
namespace Student_Registry.Models
{
    public class StudentRegistry
    {
        public int Id {get; set; }// Every item needs a unique id so clients can address it
        public string Name {get; set; }// get allows you to give this property value, set allows us to change it//Pascal Case
        public int Year {get; set; }
        public double Grade {get; set; }
        public bool IsPresent {get; set; }
    }
}