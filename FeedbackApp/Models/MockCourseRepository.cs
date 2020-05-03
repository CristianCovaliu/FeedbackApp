using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public class MockCourseRepository : ICourseRepository
    {
        private readonly ITeacherRepository _teacherRepository = new MockTeacherRepository();
        public IEnumerable<Course> AllCourses => 
            new List<Course> 
            {//de cautat imagini adecvate
                new Course
                {
                    CourseId= 1, 
                    Title="English Course", 
                    Price=200.00M, 
                    Teacher = _teacherRepository.AllTeachers.ToList()[0], 
                    ShortDescription="Basic Level", 
                    LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere. Vestibulum aliquet tincidunt dolor, nec varius velit. Nullam fringilla gravida eleifend. Cras at mauris nisl. Pellentesque bibendum est ac lorem dictum sagittis. Nunc eu aliquam nunc. Nam lacinia, ex vel porttitor ornare, arcu justo fringilla neque, quis feugiat nisl magna ac nisl. Maecenas pellentesque ante quis ipsum vestibulum scelerisque.", 
                    ImageUrl="https://freestocks.org/fs/wp-content/uploads/2015/11/stack_of_dictionaries.jpg"
                },
                new Course
                {
                    CourseId= 2, 
                    Title="Italian Course", 
                    Price=250.00M, 
                    Teacher = _teacherRepository.AllTeachers.ToList()[1], 
                    ShortDescription="Basic Level", 
                    LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere. Vestibulum aliquet tincidunt dolor, nec varius velit. Nullam fringilla gravida eleifend. Cras at mauris nisl. Pellentesque bibendum est ac lorem dictum sagittis. Nunc eu aliquam nunc. Nam lacinia, ex vel porttitor ornare, arcu justo fringilla neque, quis feugiat nisl magna ac nisl. Maecenas pellentesque ante quis ipsum vestibulum scelerisque.", 
                    ImageUrl="https://freestocks.org/fs/wp-content/uploads/2015/11/stack_of_dictionaries.jpg"
                },
                new Course
                {
                    CourseId= 3, 
                    Title="Spanish Course", 
                    Price=300.00M, 
                    Teacher = _teacherRepository.AllTeachers.ToList()[2], 
                    ShortDescription="Basic Level", 
                    LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere. Vestibulum aliquet tincidunt dolor, nec varius velit. Nullam fringilla gravida eleifend. Cras at mauris nisl. Pellentesque bibendum est ac lorem dictum sagittis. Nunc eu aliquam nunc. Nam lacinia, ex vel porttitor ornare, arcu justo fringilla neque, quis feugiat nisl magna ac nisl. Maecenas pellentesque ante quis ipsum vestibulum scelerisque.", 
                    ImageUrl="https://freestocks.org/fs/wp-content/uploads/2015/11/stack_of_dictionaries.jpg"
                }
            };

        public Course GetCourseById(int courseId)
        {
            return AllCourses.FirstOrDefault(c => c.CourseId == courseId);
        }
    }
}
