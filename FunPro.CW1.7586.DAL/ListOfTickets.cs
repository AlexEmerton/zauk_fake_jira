using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW1._7586.DAL
{
    public class ListOfTickets
    {


        private List<Ticket> GetAllTickets => new AllTickets().GetAll();

        public List<Ticket> Sort(ByAttribute attribute)
        {
            var result = AllTickets;

            switch (attribute)
            {
                case ByAttribute.Priority:
                    result.Sort(new ByPriorityComparer());
                    return result;
                case ByAttribute.Status:
                    result.Sort(new ByStatusComparer());
                    return result;
            }

            return null;
        }

        private class ByPriorityComparer : IComparer<Ticket>
        {
            public int Compare(Ticket x, Ticket y)
            {
                return string.Compare(x.Priority, y.Priority);
            }
        }

        private class ByStatusComparer : IComparer<Ticket>
        {
            public int Compare(Ticket x, Ticket y)
            {
                return string.Compare(x.Status, y.Status);
            }
        }

        public List<Ticket> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Priority:
                    return AllTickets.Where(a => a.Priority.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Status:
                    return AllTickets.Where(a => a.Status.ToUpper().Contains(value.ToUpper())).ToList();
            }

            //hmm. Seems that something is going wrong
            return null;
        }
    }
}
