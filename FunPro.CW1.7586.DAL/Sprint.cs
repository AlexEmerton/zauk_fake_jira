using System;

namespace FunPro.CW1._7586.DAL
{

    public class Sprint
    {
        private string name;
        private string status;


        public int ID { get; set; }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("You should write here something, dear lecturer. This field can not be empty. Sincerely yours, Lachs God");
                name = value;

            }
        }
        public DateTime Date { get; set; }



        public int NumberOfDevelopers { get; set; }

        public string Status
        {
            get => status;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("I am confused. Status cannot be empty");
                status = value;
            }
        }

        public Sprint()
        {

        }
        

        public Sprint(string name, DateTime date, int no_of_developers, string status)
        {
            Name = name;
            Date = date;
            NumberOfDevelopers = no_of_developers;
            Status = status;
        }

    }
}
