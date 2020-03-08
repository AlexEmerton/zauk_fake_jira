using System;

namespace FunPro.CW1._7586.DAL
{
    class Ticket
    {


        public class Tickets
        {
           
            private string ti_summary;
            private string ti_description;
            private int ti_estimation;
            private string ti_priority;
            private string ti_status;
          
         
          /// Id should not be shown to the end user. Adapted from Mr.Vasiliy Kuznetsov's seminars


            public int Id { get; set; }


            public string Summary
            {
                get => ti_summary;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Summary cannot be empty");
                    ti_summary = value;
                }
            }



            public string Description
            {
                get => ti_description;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Ladies and gentlemen, description field can not be empty");
                    ti_description = value;
                }
            }



            public int Estimation
            {
                get => ti_estimation;
                set
                {
                    if (value < 0 && value < 6)
                        throw new Exception("This value should be between 1 and 5");
                    ti_estimation = value;
                }
            }



            public string Priority
            {
                get => ti_priority;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("You dont have any priorities? That's not right. Please, write something");
                    ti_priority = value;
                }
            }




            public string Status
            {
                get => ti_status;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Everyone has a status. That's why your can not be empty");
                    ti_status = value;
                }
            }


            public Sprint Sprint { get; set; }

            public Tickets()
            {
            }

            public Tickets(string ti_summary, string ti_description, int ti_estimation, string ti_priority, string ti_status, Sprint ti_sprint)
            {
                Summary = ti_summary;
                Description = ti_description;
                Estimation = ti_estimation;
                Priority = ti_priority;
                Status = ti_status;
                Sprint = ti_sprint;
            }
        }
    }
}
