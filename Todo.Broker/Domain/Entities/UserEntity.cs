using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Todo.Broker.Domain.Entities;

[Table("User")]
public class UserEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Website { get; set; }
    public required string Phone { get; set; }
    [ForeignKey("AddressId")]
    public required AddressEntity Address { get; set; }
    [InverseProperty("User")]
    public required IEnumerable<TodoEntity> Todos { get; set; }
}