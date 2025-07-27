using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class Lesson : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign key for the Branch
    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;

    // Collection of education levels for this lesson
    public ICollection<LessonEducationLevel> LessonEducationLevels { get; set; } = new List<LessonEducationLevel>();
}
