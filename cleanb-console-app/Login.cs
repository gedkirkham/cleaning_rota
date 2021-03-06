﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace cleaning_rota
{
    public class Login
    {
        static public void User_login()
        {
            Console.Write("Email: ");
            string user_email = Console.ReadLine() ?? string.Empty;
            Set_user_email(user_email);

            Console.Write("Password: ");
            Password = Console.ReadLine() ?? string.Empty;

            string login_hash = Email + Password;
            int _hash = login_hash.GetHashCode();
            string hash = _hash.ToString();

            Console.Write(hash);
            if (Verify_hash(hash))
            {
                Set_user_data(Email);
            }
        }

        static public void Set_user_email(string _email)
        {
            Email = _email;
        }

        static public string Password
        {
            get;
            private set;
        }

        static public string Email
        {
            get;
            private set;
        }

        static public void Set_user_data(string _email) {
            List<string> exclusion_list = new List<string>();

            if (_email.Equals("user01"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom", "2", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
            }
            else if (_email.Equals("user02"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");
                Cleaner.Add_cleaner_to_list("Peter");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom", "3", exclusion_list);
            }
            else if (_email.Equals("user03"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom", "2", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
            }
            else if (_email.Equals("user04"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom", "2", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
                House.Add_room_to_list("Master Bedroom", "1", exclusion_list);
            }
            else if (_email.Equals("user05"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");
                
                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_1", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_2", "3", exclusion_list);
                House.Add_room_to_list("Bedroom_3", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_4", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_5", "3", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
                House.Add_room_to_list("Master Bedroom", "1", exclusion_list);
            }
            else if (_email.Equals("single_exclusion_01"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_1", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_2", "3", exclusion_list);
                House.Add_room_to_list("Bedroom_3", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_4", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_5", "3", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
                House.Add_room_to_list("Master Bedroom", "1", exclusion_list);
            }
            else if (_email.Equals("single_exclusion_02"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_1", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_2", "3", exclusion_list);
                House.Add_room_to_list("Bedroom_3", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_4", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_5", "3", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
                House.Add_room_to_list("Master Bedroom", "1", exclusion_list);
            }
            else if (_email.Equals("multiple_exclusion_01"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_1", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_2", "3", exclusion_list);
                House.Add_room_to_list("Bedroom_3", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_4", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_5", "3", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
                House.Add_room_to_list("Master Bedroom", "1", exclusion_list);
            }
            else if (_email.Equals("multiple_exclusion_02"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_1", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_2", "3", exclusion_list);
                House.Add_room_to_list("Bedroom_3", "1", exclusion_list);
                House.Add_room_to_list("Bedroom_4", "2", exclusion_list);
                House.Add_room_to_list("Bedroom_5", "3", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
                House.Add_room_to_list("Master Bedroom", "1", exclusion_list);
            }
            else if (_email.Equals("negative_test"))
            {
                Cleaner.Add_cleaner_to_list("Ged");
                Cleaner.Add_cleaner_to_list("Razvan");
                Cleaner.Add_cleaner_to_list("Ali");

                House.Add_room_to_list("Kitchen", "1", exclusion_list);
                House.Add_room_to_list("Bedroom", "2", exclusion_list);
                House.Add_room_to_list("Lounge", "3", exclusion_list);
                House.Add_room_to_list("Garage", "3", exclusion_list);
            }
        }


        static public bool Verify_hash(string _hash)
        {
            List<string> hash_description = new List<string>();
            List<string> login_hash_array = new List<string>();

            using (var reader = new StreamReader(@"../../login_hash.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    hash_description.Add(values[0]);
                    login_hash_array.Add(values[1]);
                }
            }

            if (login_hash_array.Contains(_hash))
            {
                Console.Write("Welcome back " + Email + ".");
                return true;
            }
            else
            {
                Console.Write("Incorrect log-in.");
                return false;
            }
        }
    }
}
