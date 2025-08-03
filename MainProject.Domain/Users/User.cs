using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Postings;
using System.Collections.Generic;
using System.Linq;

namespace MainProject.Domain.Users;

public class User : BaseEntity, IAggregateRoot
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    // Roles assigned to the user
    private readonly List<UserRole> _userRoles = new();
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();

    // Postings created by the user (as a teacher)
    public ICollection<Posting> PostingsAsTeacher { get; set; } = new List<Posting>();

    // Postings the user is enrolled in (as a student)
    public ICollection<PostingEnrollment> EnrollmentsAsStudent { get; set; } = new List<PostingEnrollment>();

    public void AddRole(Role role)
    {
        if (role is null)
        {
            throw new ArgumentNullException(nameof(role));
        }

        if (_userRoles.Any(ur => ur.RoleId == role.Id))
        {
            // Role is already assigned, do nothing.
            return;
        }

        _userRoles.Add(new UserRole { UserId = this.Id, RoleId = role.Id });
    }

    public void RemoveRole(Guid roleId)
    {
        var userRoleToRemove = _userRoles.FirstOrDefault(ur => ur.RoleId == roleId);
        if (userRoleToRemove != null)
        {
            _userRoles.Remove(userRoleToRemove);
        }
    }
}
