using webappAPI.Models;

namespace webappAPI.Services
{
    public interface IStudentService
    {
        public Task<List<Students>> AllStudents();
        public Task<Students> GetStudent(int id);
        public Task AddStudent(Students students);
        public Task UpdateStudent(Students students);
        public Task DeleteStudent(int id);
    }
}
