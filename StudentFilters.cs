using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dekanat
{
    internal class StudentFilters
    {
        private DataBase dataBase;

        public StudentFilters()
        {
            dataBase = new DataBase();
        }

        public List<string> GetFaculties()
        {
            List<string> faculties = new List<string>();

            try
            {
                dataBase.openConnection();

                string query = "SELECT DISTINCT Faculty FROM StudyData";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string faculty = reader["Faculty"].ToString();
                            faculties.Add(faculty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting faculties: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return faculties;
        }

        public List<string> GetGroups(string faculty, string specialty, int? course)
        {
            List<string> groups = new List<string>();

            try
            {
                dataBase.openConnection();

                string query = "SELECT DISTINCT [Group] FROM Student s INNER JOIN StudyData sd ON s.StudyData_id = sd.StudyData_id";

                if (!string.IsNullOrEmpty(faculty))
                {
                    query += $" WHERE sd.Faculty = '{faculty}'";

                    if (course.HasValue)
                    {
                        query += $" AND s.Course = {course}";
                    }

                    if (!string.IsNullOrEmpty(specialty))
                    {
                        query += $" AND sd.Specialty = '{specialty}'";
                    }



                }

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string group = reader["Group"].ToString();
                            groups.Add(group);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting groups: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return groups;
        }




        public List<int> GetCourses()
        {
            List<int> courses = new List<int>();

            try
            {
                dataBase.openConnection();

                string query = "SELECT DISTINCT Course FROM Student";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int course = Convert.ToInt32(reader["Course"]);
                            courses.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting courses: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return courses;
        }

        public List<string> GetSpecialties(string faculty)
        {
            List<string> specialties = new List<string>();

            try
            {
                dataBase.openConnection();

                string query = $"SELECT DISTINCT Specialty FROM StudyData WHERE Faculty = '{faculty}'";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string specialty = reader["Specialty"].ToString();
                            specialties.Add(specialty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting specialties: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return specialties;
        }

        public List<string> GetContractFaculties()
        {
            List<string> faculties = new List<string>();

            try
            {
                dataBase.openConnection();

                string query = "SELECT DISTINCT Faculty FROM StudyData sd " +
                               "INNER JOIN Student s ON sd.StudyData_id = s.StudyData_id " +
                               "WHERE s.Funding_type = 'Контракт'";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string faculty = reader["Faculty"].ToString();
                            faculties.Add(faculty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting faculties for contract students: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return faculties;
        }

        public List<string> GetContractGroups(string faculty, string specialty, int? course)
        {
            List<string> groups = new List<string>();

            try
            {
                dataBase.openConnection();

                string query = "SELECT DISTINCT [Group] FROM Student s INNER JOIN StudyData sd ON s.StudyData_id = sd.StudyData_id " +
                               $"WHERE s.Funding_type = 'Контракт' AND sd.Faculty = '{faculty}'";

                if (course.HasValue)
                {
                    query += $" AND s.Course = {course}";
                }

                if (!string.IsNullOrEmpty(specialty))
                {
                    query += $" AND sd.Specialty = '{specialty}'";
                }

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string group = reader["Group"].ToString();
                            groups.Add(group);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting groups for contract students: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return groups;
        }

        public List<string> GetContractSpecialties(string faculty)
        {
            List<string> specialties = new List<string>();

            try
            {
                dataBase.openConnection();

                string query = $"SELECT DISTINCT Specialty FROM StudyData WHERE Faculty = '{faculty}'";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string specialty = reader["Specialty"].ToString();
                            specialties.Add(specialty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting specialties for contract students: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return specialties;
        }


        public List<int> GetContractCourses()
        {
            List<int> courses = new List<int>();

            try
            {
                dataBase.openConnection();

                string query = "SELECT DISTINCT Course FROM Student Where Funding_type = 'Контракт'";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int course = Convert.ToInt32(reader["Course"]);
                            courses.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting courses: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }

            return courses;
        }
    }
}
