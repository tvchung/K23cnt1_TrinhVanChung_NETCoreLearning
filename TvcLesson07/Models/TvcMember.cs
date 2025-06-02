using System.ComponentModel.DataAnnotations;

namespace TvcLesson07.Models
{
    public class TvcMember
    {
        public int tvcId { get; set; }

        public string tvcName { get; set; }
        public string tvcUserName { get; set; }

        public string tvcPassword { get; set; }

        public string tvcEmail { get; set; }

        public bool tvcStatus { get; set; }
    }
}
