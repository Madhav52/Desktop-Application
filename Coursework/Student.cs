using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class Student
    {
        private string _filepath = "student.json";
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string ContactNo { get; set; }

        public string Gender { get; set; }

        public DateTime RegisterDate { get; set; }

        public string Courses { get; set; }

        public string Status { get; set; }

        public void Add(Student info)
        {
            Random r = new Random();
            info.Id = r.Next(100, 999);
            string data = JsonConvert.SerializeObject(info, Formatting.None);
            Utility.WriteToTextFile(_filepath, data);
        }

        public void Edit(Student info)
        {
            List<Student> list = List();
            Student s = list.Where(x => x.Id == info.Id).FirstOrDefault();
            list.Remove(s);
            list.Add(info);
            string data = JsonConvert.SerializeObject(list, Formatting.None);
            Utility.WriteToTextFile(_filepath, data, false);


        }
        public Student Edit(int id)
        {
            Student obj = new Student();
            return obj;
        }
        public void Delete(int id)
        {
            
        }
        public Student Detail(int id)
        {
            Student obj = new Student();
            return obj;
        }

        public List<Student> List()
        {
            string d = Utility.ReadFromTextFile(_filepath);
            if (d != null)
            {
                List<Student> lst = JsonConvert.DeserializeObject<List<Student>>(d);
                return lst;
            }
            return null;
            
        }
        public List<Student> Sort(List<Student> listStudents, string sortType)
        {
            if (sortType == "Name")
            {
                string[] list = new string[listStudents.Count];

                //Adding names of the student to the list
                for (var i = 0; i < listStudents.Count; i++)
                {
                    list[i] = listStudents[i].firstName;
                }

                //implementing bubble sort algorithm
                for (int i = list.Length - 1; i > 0; i--)
                {
                    for (int j = 0; j <= i - 1; j++)
                    {
                        //comparing the names from the list with each other
                        if (list[j].CompareTo(list[j + 1]) > 0)
                        {
                            //swapping names if current element is greater than next element
                            string name = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = name;

                            //swapping the whole list of students in ascending order according to the name 
                            Student nameLists = listStudents[j];
                            listStudents[j] = listStudents[j + 1];
                            listStudents[j + 1] = nameLists;
                        }
                    }
                }
            }
            else
            {
                DateTime[] list = new DateTime[listStudents.Count];

                //Adding registration dates of the student to the list
                for (var i = 0; i < listStudents.Count; i++)
                {
                    list[i] = listStudents[i].RegisterDate;
                }

                //implementing bubble sort algorithm
                for (int i = list.Length - 1; i > 0; i--)
                {
                    for (int j = 0; j <= i - 1; j++)
                    {
                        //comparing the registration dates of students from the list with each other
                        if (list[j].CompareTo(list[j + 1]) > 0)
                        {
                            //swapping if current element is greater than next element
                            DateTime registerDate = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = registerDate;

                            //swapping the whole list of student in ascending order according to the student registration date
                            Student regDateList = listStudents[j];
                            listStudents[j] = listStudents[j + 1];
                            listStudents[j + 1] = regDateList;
                        }
                    }
                }
            }
            // returns the sorted list
            return listStudents;
        }

        public DateTime[] FindWeek(DateTime registeredDate)
        {
            //creating and initializing an array to store start and end day of the week
            DateTime[] dayArray = new DateTime[2];
            string[] days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            // converting the registered date to day and getting the index of that day
            int index = Array.IndexOf(days, registeredDate.DayOfWeek.ToString());

            // lowering the index from the registered date to get week start day 
            DateTime startDay = registeredDate.AddDays(-index);

            // adding the remaining index to registered date to get the week end day
            int remainingIndex = 6 - index;
            DateTime endDay = registeredDate.AddDays(remainingIndex);

            //add the start and end day to the array
            dayArray[0] = startDay;
            dayArray[1] = endDay;

            //return start and end day of the week
            return dayArray;
        }

        public List<Student> WeeklyStudent(DateTime[] dayArray, List<Student> listStudents)
        {
            // creating and initializing new list to store enrolled students according to the week
            List<Student> weeklyStudents = new List<Student>();

            //iterating each list of student
            for (int j = 0; j < listStudents.Count(); j++)
            {
                //checking whether the registration date is in between week start and end date
                if (listStudents[j].RegisterDate > dayArray[0] && listStudents[j].RegisterDate < dayArray[1])
                {
                    // if the student has enroled in that week then add student to the new list
                    weeklyStudents.Add(listStudents[j]);
                }
            }
            //return the new list of students
            return weeklyStudents;
        }

    }
}
