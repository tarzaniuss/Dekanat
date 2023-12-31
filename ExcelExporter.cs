using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dekanat
{
    internal class ExcelExporter
    {
        DataBase dataBase = new DataBase();

        public ExcelExporter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public static void ExportToExcel(DataGridView dataGridView)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);

                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                        // Write column headers with borders
                        for (int i = 1; i <= dataGridView.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
                            worksheet.Cells[1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        // Write data with borders
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value;
                                worksheet.Cells[i + 2, j + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            }
                        }

                        // Autofit columns
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        package.Save();
                    }

                    MessageBox.Show("Data Exported Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void ExportStudentsToExcel(DataGridView dataGridView)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);

                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                        // Write column headers with borders
                        int k = 1;
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView.Columns[j].DataPropertyName == "StudyData_id")
                            {
                                // Додаємо окремі стовпці для ФАКУЛЬТЕТ та СПЕЦІАЛЬНІСТЬ
                                worksheet.Cells[1, k].Value = "Факультет";
                                worksheet.Cells[1, k + 1].Value = "Спеціальність";
                                worksheet.Cells[1, k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[1, k + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                k += 2; // Збільшуємо лічильник, щоб пропустити наступний стовпець
                            }
                            else if (dataGridView.Columns[j].DataPropertyName == "ContactInfo_id")
                            {
                                // Додаємо окремі стовпці для Номеру телефону та Електронної пошти
                                worksheet.Cells[1, k].Value = "Номер телефону";
                                worksheet.Cells[1, k + 1].Value = "Електронна пошта";
                                worksheet.Cells[1, k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[1, k + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                k += 2; // Збільшуємо лічильник, щоб пропустити наступний стовпець
                            }
                            else
                            {
                                worksheet.Cells[1, k].Value = dataGridView.Columns[j].HeaderText;
                                worksheet.Cells[1, k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                k++;
                            }
                        }

                        // Write data with borders
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            int j = 0; // Лічильник для стовпців у dataGridView
                            k = 1; // Лічильник для стовпців у ексель-таблиці

                            while (k <= worksheet.Dimension.End.Column) // Ітеруємо по всіх стовпцях ексель-таблиці
                            {
                                object cellValue = dataGridView.Rows[i].Cells[j].Value;

                                if (dataGridView.Columns[j].DataPropertyName == "StudyData_id")
                                {
                                    int studyDataId = (int)cellValue;
                                    string faculty, specialty;

                                    // Create an instance of ExcelExporter
                                    ExcelExporter excelExporter = new ExcelExporter();

                                    // Call the non-static method with the instance
                                    excelExporter.GetStudyDataInfo(studyDataId, out faculty, out specialty);

                                    // Write data to the corresponding columns
                                    worksheet.Cells[i + 2, k].Value = faculty;
                                    worksheet.Cells[i + 2, k + 1].Value = specialty;
                                    worksheet.Cells[i + 2, k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                    worksheet.Cells[i + 2, k + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                    k += 2; // Збільшуємо лічильник, щоб пропустити наступний стовпець
                                }
                                else if (dataGridView.Columns[j].DataPropertyName == "ContactInfo_id")
                                {
                                    int contactInfoId = (int)cellValue;
                                    string phoneNumber, email;

                                    // Create an instance of ExcelExporter
                                    ExcelExporter excelExporter = new ExcelExporter();

                                    // Call the non-static method with the instance
                                    excelExporter.GetContactInfo(contactInfoId, out phoneNumber, out email);

                                    // Write data to the corresponding columns
                                    worksheet.Cells[i + 2, k].Value = FormatPhoneNumber(phoneNumber);
                                    worksheet.Cells[i + 2, k + 1].Value = email;
                                    worksheet.Cells[i + 2, k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                    worksheet.Cells[i + 2, k + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                    k += 2; // Збільшуємо лічильник, щоб пропустити наступний стовпець
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, k].Value = cellValue;
                                    worksheet.Cells[i + 2, k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                    k++;
                                }

                                j++; // Збільшуємо лічильник стовпців у dataGridView
                            }
                        }

                        // Autofit columns
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        package.Save();
                    }

                    MessageBox.Show("Data Exported Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        // ... (решта коду залишається незмінним)


        private void GetStudyDataInfo(int studyDataId, out string faculty, out string specialty)
        {
            faculty = "";
            specialty = "";

            try
            {
                dataBase.openConnection();

                // Отримати дані з таблиці StudyData за ID
                string query = "SELECT Faculty, Specialty FROM StudyData WHERE StudyData_id = @StudyDataId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@StudyDataId", studyDataId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            faculty = reader["Faculty"].ToString();
                            specialty = reader["Specialty"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting StudyData info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void GetContactInfo(int contactInfoId, out string phoneNumber, out string email)
        {
            phoneNumber = "";
            email = "";

            try
            {
                dataBase.openConnection();

                // Отримати дані з таблиці ContactInfo за ID
                string query = "SELECT Phone_number, Email FROM ContactInfo WHERE ContactInfo_id = @ContactInfoId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@ContactInfoId", contactInfoId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            phoneNumber = reader["Phone_number"].ToString();
                            email = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting ContactInfo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private static string FormatPhoneNumber(string phoneNumber)
        {
            return $"+380({phoneNumber.Substring(1, 2)}){phoneNumber.Substring(3, 3)}-{phoneNumber.Substring(6, 2)}-{phoneNumber.Substring(8, 2)}";
        }
    }
}
