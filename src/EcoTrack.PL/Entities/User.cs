using EcoTrack.PL.Enums;

namespace EcoTrack.PL.Entities
{

    public class User
    {
        public long UserId { get; set; }    
        public string Username { set; get; } 
        public string Password { set; get; } 
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public long LocationId { set; get; }    
        public Location Location { set; get; }
        public DateTime BirthDate { get; set; }
        public string Email { set; get; }
        public bool Deleted { set; get; }
        public UserLevel UserLevel { set; get; } = UserLevel.User;
        public List<EnviromentalReport> enviromentalReports { set; get; } = new List<EnviromentalReport>();
        public List<EnviromentalThreshold> enviromentalThresholds { set; get; }  = new List<EnviromentalThreshold>();
    }
}
