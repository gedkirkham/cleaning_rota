﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleaning_rota
{
    public class Calendar
    {
        public static List<String> calendar_date_array = new List<String>();
        static List<String> cleaner_list_temp = new List<String>();

        static public void Cleaner_andor_rooms_list_count_limit_check()
        {
            Console.WriteLine();

            if (Cleaner.Get_cleaner_list_count() == 0 && House.Get_room_list_count() == 0)
            {
                Console.WriteLine(Constants.cleaners_and_rooms_required);
                Cleaner.Cleaner_nothing_returned();
                House.House_nothing_returned();

                if (Cleaner.Get_cleaner_list_count() == 0 || House.Get_room_list_count() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(Constants.cleaners_and_rooms_required);
                }
            }
            else if (Cleaner.Get_cleaner_list_count() == 0 && House.Get_room_list_count() > 0)
            {
                Console.WriteLine(Constants.cleaners_required);
                Cleaner.Cleaner_nothing_returned();

                if (Cleaner.Get_cleaner_list_count() == 0 && House.Get_room_list_count() > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(Constants.cleaners_required);
                }
            }
            else if (Cleaner.Get_cleaner_list_count() > 0 && House.Get_room_list_count() == 0)
            {
                Console.WriteLine(Constants.rooms_required);
                House.House_nothing_returned();

                if (Cleaner.Get_cleaner_list_count() > 0 && House.Get_room_list_count() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(Constants.rooms_required);
                }
            }
        }

        static public void Room_list_count()
        {
            Console.WriteLine();
            Console.WriteLine(Constants.rooms_required);
            string _user_input = House.House_nothing_returned();
        }

        static public void Calendar_check()
        {
            Cleaner_andor_rooms_list_count_limit_check();

            if (Cleaner.Get_cleaner_list_count() > 0 && House.Get_room_list_count() > 0)
            {
                Display_calendar();
            }
            else
            {
                Menu.Main_menu();
            }
        }

        static public void Calendar_count(byte _months)
        {
            DateTime start_date = DateTime.Now;
            DateTime end_date = DateTime.Now.AddMonths(_months);

            TimeSpan diff = end_date - start_date;
            int days = diff.Days;

            for (int i = 0; i <= days; i++)
            {
                var weekend_date = start_date.AddDays(i);
                switch (weekend_date.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        calendar_date_array.Add(weekend_date.ToShortDateString());
                        break;
                }
            }
        }

        static public string[,] Calendar_2d_array
        {
            get;
            private set;
        }

        static public int Assign_cleaners_dependent_on_room_frequency(int cleaner_index, int room_incrementor, string room_frequency, List<string> exclusion_list)
        {
            string null_check = String.Empty;

            //increments cleaner so that it is +1 when compared with the previous room
            if (cleaner_list_temp.Count == 0 && room_incrementor != 0)
            {
                int null_shifter = 0;
                string previous_cleaner = Calendar_2d_array[null_shifter + 1, room_incrementor];

                if (previous_cleaner == null)
                {
                    null_shifter++;
                    previous_cleaner = Calendar_2d_array[null_shifter + 1, room_incrementor];
                }

                cleaner_index = Cleaner.Return_cleaner_index(previous_cleaner);
                cleaner_index++;
            }
            else if (cleaner_list_temp.Count != 0)
            {
                cleaner_index++;
            }

            cleaner_index = Cleaner_index_out_of_bounds_check(cleaner_index);

            //check exclusion list and skip cleaner if required
            int counter = 0;
            bool cleaner_null_flag = false;
            while (exclusion_list.Contains(Cleaner.Get_cleaner(cleaner_index)) && counter < Cleaner.Get_cleaner_list_count())
            {
                cleaner_index++;
                cleaner_index = Cleaner_index_out_of_bounds_check(cleaner_index);
                counter++;

                if(counter == 3)
                {
                    cleaner_null_flag = true;
                }
            }

            if(cleaner_null_flag == false)
            {
                cleaner_list_temp.Add(Cleaner.Get_cleaner(cleaner_index));
            }
            else
            {
                cleaner_list_temp.Add(null);
            }
            

            return cleaner_index;
        }

        static public int Cleaner_index_out_of_bounds_check(int cleaner_index)
        {
            if (cleaner_index >= Cleaner.Get_cleaner_list_count())
            {
                cleaner_index = 0;
            }

            return cleaner_index;
        }

        static public void Display_calendar()
        {
            Console.WriteLine();
            Console.WriteLine("Calendar:");

            Calendar_count(4);

            Calendar_2d_array = new string[calendar_date_array.Count + 1, House.Get_room_list_count() + 1];

            Calendar_2d_array[0, 0] = "Date";

            int calendar_index = 1;
            foreach (var date in calendar_date_array)
            {
                Calendar_2d_array[calendar_index, 0] = date;
                calendar_index++;
            }

            calendar_index = 1;
            foreach (var room in House.Get_room_list_array())
            {
                Calendar_2d_array[0, calendar_index] = room;
                calendar_index++;
            }

            int room_incrementor = 0;
            int duplicate_prevention_shifter = 0;
            int duplicate_prevention_cleaner_counter = 0;
            int duplicate_prevention_counter = 0;

            //assign cleaners to room dependent on room frequency
            foreach (var room in House.Get_room_list_array())
            {
                if(room_incrementor == 1)
                {
                    Console.Write("");
                }

                var house_list_array = House.Get_room_list_array();
                (string room_name, string room_frequency, List<string> exclusion_list) = House.Get_room(house_list_array[room_incrementor]);
                cleaner_list_temp.Clear();
                int cleaner_index = 0;
                int week_counter = 1;

                foreach (var date in calendar_date_array)
                {
                    if (room_frequency.Equals("1"))
                    {
                        cleaner_index = Assign_cleaners_dependent_on_room_frequency(cleaner_index, room_incrementor, room_frequency, exclusion_list);
                    }
                    else if (room_frequency.Equals("2") && week_counter != 2 && week_counter != 4)
                    {
                        cleaner_index = Assign_cleaners_dependent_on_room_frequency(cleaner_index, room_incrementor, room_frequency, exclusion_list);
                    }
                    else if (room_frequency.Equals("3") && week_counter == 1)
                    {
                        cleaner_index = Assign_cleaners_dependent_on_room_frequency(cleaner_index, room_incrementor, room_frequency, exclusion_list);
                    }
                    else
                    {
                        cleaner_list_temp.Add(null);
                    }

                    if (week_counter == 4)
                    {
                        week_counter = 1;
                    }
                    else
                    {
                        week_counter++;
                    }
                }

                //create a shift pattern so that work is distributed each time the cleaner cycle goes full circle
                if (duplicate_prevention_counter % 2 == 0)
                {
                    duplicate_prevention_shifter = 1;
                    duplicate_prevention_cleaner_counter++;
                } else
                {
                    duplicate_prevention_shifter = 0;
                    duplicate_prevention_cleaner_counter++;
                }

                if(duplicate_prevention_cleaner_counter >= Cleaner.Get_cleaner_list_count())
                {
                    duplicate_prevention_cleaner_counter = 0;
                    duplicate_prevention_counter++;
                }

                //generate calendar array
                for (int cleaner_list_counter = 0; cleaner_list_counter + duplicate_prevention_shifter < cleaner_list_temp.Count; cleaner_list_counter++)
                {
                    string cleaner = cleaner_list_temp[cleaner_list_counter];
                    Calendar_2d_array[cleaner_list_counter + duplicate_prevention_shifter + 1, room_incrementor + 1] = cleaner;
                }

                room_incrementor++;
            }

            //print calendar to screen
            int rowLength = Calendar_2d_array.GetLength(0);
            int colLength = Calendar_2d_array.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0},", Calendar_2d_array[i, j]));
                }
                Console.Write(Environment.NewLine);
            }

            Print_calendar_to_file(Calendar_2d_array);
        }

        static public void Print_calendar_to_file(string[,] calendar)
        {
            //print calendar to file
            string path = @"../../user_output/" + Login.Email + "_calendar.csv";
            using (StreamWriter sw = File.CreateText(path))
            {
                int rowLength = calendar.GetLength(0);
                int colLength = calendar.GetLength(1);
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        sw.Write(string.Format("{0},", calendar[i, j]));
                    }
                    sw.Write("\n");
                }
            }
        }
    }
}
