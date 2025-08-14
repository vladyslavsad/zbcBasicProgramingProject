namespace zbs_gp_project.Models
{
    public class Labour
    {
        public string Id { get; set; } //FK
        public string UserId { get; set; } //PK
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }
    }
}
