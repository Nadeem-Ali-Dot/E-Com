namespace E_Com
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
        public string Role { get; set; }
        public DateTime CreateAt { get; set; }= DateTime.Now;
    }
}
