using SQLite;
using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;
        public StudentService()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }

        public Task<int> AddStudent(StudentModel studentModel)
        {
            return _dbConnection.InsertAsync(studentModel);
        }

        public Task<int> DeleteStudent(StudentModel studentModel)
        {
            return _dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }

        public Task<int> UpdateStudent(StudentModel studentModel)
        {
            return _dbConnection.UpdateAsync(studentModel);
        }
    }
}
