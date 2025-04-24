using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CapaDatos;
using UserCredentials;
using Entity;

namespace CapaNegocio
{
    public class BussinessLogic
    {
        public bool RegisterUser(string name, string email, string password, string rol)
        {
            bool success = false;
            DataAcces logic = new DataAcces();
            try
            {
                logic.Register(name, email, password, rol);
                Console.WriteLine("User registered successfully.");

                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                success = false;
            }

            return success;
        }
        public bool LoginUser(string name, string password)
        {
            bool success = false;
            DataAcces logic = new DataAcces();

            try
            {
                logic.Login(name, password);

                if(UserSession.Instance.Session)
                {
                    success = true;
                    Console.WriteLine("User logged in successfully.");
                } else
                {
                success = false;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                success = false;
            }
            return success;
        }

        public bool CreateReservation(string date, int service)
        {
            bool success = false;
            DataAcces logic = new DataAcces();
            string userId = UserSession.Instance.id;
            try
            {
                logic.BookService(userId, service, date);
                Console.WriteLine("Reservation created successfully.");
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                success = false;
            }
            return success;
        }

        public List<BookingEntity> GetReservations()
        {
            DataAcces logic = new DataAcces();
            List<BookingEntity> reservations = new List<BookingEntity>();
            try
            {
                reservations = logic.GetServices();
                return reservations;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public bool DeleteRervation(string id)
        {
            DataAcces logic = new DataAcces();
            bool success = false;
            try
            {
                logic.DeleteReservation(id);
                success = true;
                Console.WriteLine("Reservation deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return success;
        }

        public void SetServicesState(string id, string state)
        {
            DataAcces logic = new DataAcces();
            try
            {
                logic.UpdateBookingState(id, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        public List<UserEntity> FetchUsers()
        {
            DataAcces logic = new DataAcces();
            try
            {
                List<UserEntity> users = logic.GetUsers();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public void DeleteUser (string id)
        {

            DataAcces logic = new DataAcces();
            try
            {
                logic.RemoveUser(id);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
        }
    }
    }
