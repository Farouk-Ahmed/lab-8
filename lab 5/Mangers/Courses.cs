using App.Mangers;
using App.Models;
using Microsoft.EntityFrameworkCore;

public class CourseManger : Manger<Course>, ICourseManger
{
    public CourseManger(DbSet<Course> courses) : base(courses)  
    {
        
    }
}