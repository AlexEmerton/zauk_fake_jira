using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW1._7586.DAL
{
    public class TicketList
    {
        public List<Ticket> GetAllTickets()
        {
            return new TicketManager().GetAll();
        }


        public List<Ticket> GetBacklogTickets()
        {
            return new TicketManager().GetBacklog();
        }



        public List<Ticket> SortLinq(ByAttribute attribute)
        {
            Dictionary<string, int> OrderP = new Dictionary<string, int> { { "Showstopper", 0 }, { "High", 1 }, { "Normal", 2 }, { "Low", 3 } };
            switch (attribute)
            {
                case ByAttribute.Status:
                    return null;
                case ByAttribute.Priority:
                    return GetAllTickets().OrderBy(a => a.Priority).ToList();
            }

            //if we are here - something went wrong
            return null;
        }



        public List<Ticket> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Id:
                    return GetAllTickets().Where(a => a.Id.ToString().Contains(value)).ToList();
            }

            //if we are here - something went wrong
            return null;
        }
    }
}
