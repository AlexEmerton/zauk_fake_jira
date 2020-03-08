using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW1._7586.DAL
{
    class ListOfSprints
    {
        public List<Sprint> GetAllSprints()
        {
            return new ManagerOfSprints().GetAll();
        }
    }
}
