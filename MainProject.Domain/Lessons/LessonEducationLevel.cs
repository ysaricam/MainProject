namespace MainProject.Domain.Lessons;

public class LessonEducationLevel
{
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }

    public Guid EducationLevelId { get; set; }
    public EducationLevel EducationLevel { get; set; }
}
