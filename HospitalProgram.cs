using System;
using Microsoft.Data.SqlClient;

namespace HospitalManagement
{
    class HospitalProgram
    {
        static string conStr =
            @"Server=localhost;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== DOCTOR APPOINTMENT SYSTEM =====");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. Cancel Appointment");
                Console.WriteLine("3. View Appointments");
                Console.WriteLine("4. Monthly Report");
                Console.WriteLine("5. Exit");

                Console.Write("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BookAppointment();
                        break;

                    case 2:
                        CancelAppointment();
                        break;

                    case 3:
                        ViewAppointments();
                        break;

                    case 4:
                        MonthlyReport();
                        break;

                    case 5:
                        Console.WriteLine("Thank You!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 5);
        }

        static void BookAppointment()
        {
            Console.Write("Patient Name: ");
            string patient = Console.ReadLine();

            Console.Write("Doctor Id: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Appointment Date (yyyy-mm-dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string check =
                    "SELECT COUNT(*) FROM Appointments WHERE DoctorId=@did AND AppointmentDate=@dt AND Status='Booked'";

                SqlCommand cmd1 = new SqlCommand(check, con);
                cmd1.Parameters.AddWithValue("@did", doctorId);
                cmd1.Parameters.AddWithValue("@dt", date);

                int count = (int)cmd1.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine("Doctor Not Available");
                    return;
                }

                string insert =
                    "INSERT INTO Appointments(PatientName,DoctorId,AppointmentDate,Status) VALUES(@p,@d,@dt,'Booked')";

                SqlCommand cmd2 = new SqlCommand(insert, con);
                cmd2.Parameters.AddWithValue("@p", patient);
                cmd2.Parameters.AddWithValue("@d", doctorId);
                cmd2.Parameters.AddWithValue("@dt", date);

                cmd2.ExecuteNonQuery();

                Console.WriteLine("Appointment Booked Successfully");
            }
        }

        static void CancelAppointment()
        {
            Console.Write("Appointment Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string query =
                    "UPDATE Appointments SET Status='Cancelled' WHERE AppointmentId=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Appointment Cancelled");
                else
                    Console.WriteLine("Appointment Not Found");
            }
        }

        static void ViewAppointments()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM Appointments", con);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nID\tPatient\tDoctor\tDate\t\tStatus");

                while (dr.Read())
                {
                    Console.WriteLine(
                        dr["AppointmentId"] + "\t" +
                        dr["PatientName"] + "\t" +
                        dr["DoctorId"] + "\t" +
                        Convert.ToDateTime(dr["AppointmentDate"]).ToShortDateString() + "\t" +
                        dr["Status"]);
                }
            }
        }

        static void MonthlyReport()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string query =
                    @"SELECT MONTH(AppointmentDate) AS MonthNo,
                      COUNT(*) AS TotalAppointments,
                      SUM(CASE WHEN Status='Cancelled'
                      THEN 1 ELSE 0 END) AS CancelledAppointments
                      FROM Appointments
                      GROUP BY MONTH(AppointmentDate)
                      ORDER BY MonthNo";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nMonth\tTotal\tCancelled");

                while (dr.Read())
                {
                    Console.WriteLine(
                        dr["MonthNo"] + "\t" +
                        dr["TotalAppointments"] + "\t" +
                        dr["CancelledAppointments"]);
                }
            }
        }
    }
}