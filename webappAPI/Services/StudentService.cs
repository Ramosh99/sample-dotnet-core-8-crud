using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using webappAPI.Models;

namespace webappAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext _context) {
            this._context = _context;
        }
        public async Task<List<Students>> AllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetStudent(int Id)
        {
            return await _context.Students.FindAsync(Id);
        }
        public async Task AddStudent(Students students)
        {
            _context.Students.Add(students);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudent(int id)
        {
            var obj = await GetStudent(id);
            if (obj != null)
            {
                _context.Students.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateStudent(Students students)
        {
            _context.Students.Update(students);
            await _context.SaveChangesAsync();
        }
    }
}
