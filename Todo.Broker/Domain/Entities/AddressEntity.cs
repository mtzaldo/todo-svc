using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Broker.Domain.Entities;

[Table("Address")]
public class AddressEntity
{
    public int Id { get; set; }
    public required string Line1 { get; set; }
    public required string Line2 { get; set; }
    public required string City { get; set; }
    public required string Zipcode { get; set; }
    [InverseProperty("Address")]
    public required UserEntity User { get; set; }
}