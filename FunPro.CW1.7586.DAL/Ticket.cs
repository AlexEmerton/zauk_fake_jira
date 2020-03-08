using System;

namespace FunPro.CW1._7586.DAL
{
    public class Ticket : IComparable<Ticket>
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public Sprint Sprint { get; set; }



        public Ticket()
        {
        }


        public int CompareTo(Ticket other)
        {
            if (Status == "Showstopper" && other.Status == "Showstopper" || Status == "High" && other.Status == "High" || Status == "High" && other.Status == "High" ||
                Status == "Normal" && other.Status == "Normal" || Status == "Low" && other.Status == "Low")
            {
                return 0;
            }
            else if (Status == "Showstopper" && other.Status == "High" || other.Status == "Normal" || other.Status == "Low" || Status == "High" && other.Status == "Normal" || other.Status == "Low")
            {
                return 1;
            }
            else if (Status == "High" && other.Status != "High")
            {
                return 1;
            }
            else if (Status == "High" && other.Status == "High")
            {
                return 0;
            }
            else if (Status == "Normal" && other.Status == "Low")
            {
                return 1;
            }
            else if (Status == "Normal" && other.Status != "Normal")
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }



        public Ticket(string summary, string description, int estimation, string priority, string status, Sprint Id)
        {
            Summary = summary;
            Description = description;
            Estimation = estimation;
            Priority = priority;
            Status = status;
            Sprint = Id;
        }
    }
}
