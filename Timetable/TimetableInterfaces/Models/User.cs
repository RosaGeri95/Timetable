using System;
using System.Collections.Generic;
using System.Text;

namespace TimetableInterfaces.Models
{
    public class User
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("Username is too long!");
                }
                else if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Username cannot be empty!");
                }
                else
                {
                    username = value;
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("Password is too long!");
                }
                else if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Password cannot be empty!");
                }
                else
                {
                    password = value;
                }
            }
        }


        public DateTime ParitySourceDate { get; set; }
        
    }
}







