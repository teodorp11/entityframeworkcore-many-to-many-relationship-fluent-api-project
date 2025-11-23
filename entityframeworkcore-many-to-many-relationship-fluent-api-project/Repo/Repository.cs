using entityframeworkcore_many_to_many_relationship_fluent_api_project.Models;
using entityframeworkcore_many_to_many_relationship_project.Data;
using entityframeworkcore_many_to_many_relationship_project.Models;
using Microsoft.EntityFrameworkCore;

namespace entityframeworkcore_many_to_many_relationship_project.Repo
{
    public class Repository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await _appDbContext.Subjects.Include(s => s.StudentSubjects).ToListAsync();
        }

        public async Task AddSubject(Subject subject)
        {
            await _appDbContext.Subjects.AddAsync(subject);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _appDbContext.Students.Include(s => s.StudentSubjects).ToListAsync();
        }

        public async Task AddStudent(Student student)
        {
            await _appDbContext.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddStudentSubject(StudentIDSubjectID studentIDSubjectID)
        {
            await _appDbContext.AddAsync(new StudentSubject { StudentID = studentIDSubjectID.StudentID, SubjectID = studentIDSubjectID.SubjectID });
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<StudentSubject>> GetStudentSubjects()
        {
            return await _appDbContext.Set<StudentSubject>()
                .Include(ss => ss.Student)
                .Include(ss => ss.Subject)
                .ToListAsync();
        }
    }
}