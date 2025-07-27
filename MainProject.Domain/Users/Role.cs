using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using System.Collections.Generic;

namespace MainProject.Domain.Users;

public class Role : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
