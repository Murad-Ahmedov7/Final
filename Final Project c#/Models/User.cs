

namespace Users.Models
{
    internal class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Email: {Email}, DateOfBirth: {DateOfBirth}";
        }

    }
}
