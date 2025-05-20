using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TermTracker.Models.TermTrackerCore;

namespace TermTracker.Services
{
    public static class DatabaseService
    {
        private static SQLiteAsyncConnection _db;

        public static async Task<SQLiteAsyncConnection> GetConnection()
        {
            if (_db != null)
                return _db;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "termtracker.db");
            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<Term>();
            await _db.CreateTableAsync<Course>();
            await _db.CreateTableAsync<Assessment>();

            return _db;
        }

        public static async Task SeedSampleData()
        {
            var db = await GetConnection();

            // Prevent duplicates
            if ((await db.Table<Term>().CountAsync()) == 0)
            {
                var sampleTerm = new Term
                {
                    Title = "Term 5",
                    StartDate = new DateTime(2025, 2, 1),
                    EndDate = new DateTime(2025, 7, 31)
                };

                await db.InsertAsync(sampleTerm);

                var sampleCourse = new Course
                {
                    TermId = sampleTerm.Id,
                    Title = "C971 Mobile App Dev",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(1),
                    Status = "In Progress",
                    Notes = "Start with dashboard screen"
                };

                await db.InsertAsync(sampleCourse);

                var sampleAssessment = new Assessment
                {
                    CourseId = sampleCourse.Id,
                    Title = "Performance Assessment",
                    Type = "Performance",
                    DueDate = DateTime.Today.AddDays(10),
                    HasNotification = false
                };

                await db.InsertAsync(sampleAssessment);
            }
        }
    }
}
