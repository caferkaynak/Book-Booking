namespace bookbooking.Entity.Model
{
    public class User:BaseEntity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Tc { get; set; }
        public string Phone { get; set; }
        public int BirthYear { get; set; }
    }
}
