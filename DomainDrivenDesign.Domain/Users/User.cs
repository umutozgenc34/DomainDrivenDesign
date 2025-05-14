namespace DomainDrivenDesign.Domain.Users;

public sealed class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Country { get; set; }
    public string FullAdress { get; set; }
    public string PostalCode { get; set; }
}
