namespace DomainDrivenDesign.Domain.Users;

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Email alanı boş olamaz!");
        }

        if (value.Length < 10)
        {
            throw new ArgumentException("Email alanı 10 karakterden küçük olamaz!");
        }

        if (!value.Contains("@"))
        {
            throw new ArgumentException("Geçerli bir mail adresi girin!");
        }

        Value = value;
    }
}
