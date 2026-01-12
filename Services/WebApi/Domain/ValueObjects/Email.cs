using System.Net.Mail;

namespace WebApi.Domain.ValueObjects;

public sealed record Email
{
    public string Address { get; }

    private Email() { }

    private Email(string address)
    {
        Address = address;
    }

    public static Email Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException("Email cannot be empty");
        }
        var addressFormated = address.Trim().ToLowerInvariant();
        var mailAddress = new MailAddress(addressFormated);
        if (!mailAddress.Address.Equals(addressFormated))
        {
            throw new ArgumentException("Invalid email format");
        }
        return new Email(mailAddress.Address);
    }

    public override string ToString() => Address;

    public static Email Empty => new();
}
