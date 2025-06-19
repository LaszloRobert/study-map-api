namespace StudyMapAPI.Data
{
    public class UserCounty : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public string County { get;set; }
    }
}
