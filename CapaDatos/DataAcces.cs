using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using UserCredentials;

namespace CapaDatos
{
    public class DataAcces
    {
        public void Register(string name, string email, string password, string rol)
        {
            SqlConnection conn = DBConnections.Instance.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (name,email,password,rol) VALUES (@name, @email, @password, @rol)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@rol", rol);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
        }
        public void Login(string name, string password)
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE name = @name AND password = @password", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        UserSession.Instance.Username = reader["name"].ToString();
                        UserSession.Instance.Password = reader["password"].ToString();
                        UserSession.Instance.Rol = reader["rol"].ToString();
                        UserSession.Instance.Email = reader["email"].ToString();
                        UserSession.Instance.id = reader["user_id"].ToString();
                        UserSession.Instance.Session = true;
                    }
                }
                else
                {
                    UserSession.Instance.Session = false;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        public void BookService(string userId, int service, string date)
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO bookings (user_id, service, date, state) VALUES (@userId, @serviceId, @date, @state)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@serviceId", service);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@state", "En espera");
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadUser(string name, string password)
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE name = @name AND password = @password", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserSession.Instance.Username = reader["name"].ToString();
                    UserSession.Instance.Password = reader["password"].ToString();
                    UserSession.Instance.Rol = reader["rol"].ToString();
                    UserSession.Instance.Email = reader["email"].ToString();
                    UserSession.Instance.id = reader["user_id"].ToString();
                    UserSession.Instance.Session = true;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        public List<BookingEntity> GetServices()
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            List<BookingEntity> booking = new List<BookingEntity>();

            string query = UserSession.Instance.Rol == "admin" ? "SELECT * FROM reservations" : "SELECT * FROM reservations WHERE user_id = @userId";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", UserCredentials.UserSession.Instance.id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookingEntity entity = new BookingEntity();
                    entity.id = reader["booking_id"].ToString();
                    entity.date = reader["date"].ToString();
                    entity.service = reader["service_name"].ToString();
                    entity.state = reader["state"].ToString();
                    entity.userName = reader["name"].ToString();
                    booking.Add(entity);
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }

            return booking;
        }

        public void DeleteReservation(string id)
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            int bookingId = int.Parse(id);
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM bookings WHERE booking_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", bookingId);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateBookingState(string id, string state)
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            int bookingId = int.Parse(id);
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE bookings SET state = @state WHERE booking_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", bookingId);
                cmd.Parameters.AddWithValue("state", state);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        public List<UserEntity> GetUsers()
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            List<UserEntity> users = new List<UserEntity>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserEntity
                    {
                        id = reader["user_id"].ToString(),
                        name = reader["name"].ToString(),
                        email = reader["email"].ToString(),
                        rol = reader["rol"].ToString()
                    });
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
            return users;
        }
        public void RemoveUser(string id)
        {
            SqlConnection conn = DBConnections.Instance.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE user_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
    }
