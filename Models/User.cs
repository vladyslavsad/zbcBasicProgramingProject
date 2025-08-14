namespace zbs_gp_project.Models
{
    public class User
    {
        public string Id { get; set; } //PK
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime UserTimeStamp { get; set; }

        public ICollection<Labour> Labours { get; set; }
    }
}
