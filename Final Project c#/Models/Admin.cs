

namespace Admins.Models
{
    internal class Admin
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Login: {Login}, Password: {Password}";
        }
    }
}
