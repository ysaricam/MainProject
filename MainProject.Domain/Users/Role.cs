using MainProject.Domain.Common;
using System.Collections.Generic;

namespace MainProject.Domain.Users;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
