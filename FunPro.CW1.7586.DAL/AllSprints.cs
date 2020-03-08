using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW1._7586.DAL
{
    public class AllSprints
    {
        public List<Sprint> GetAllSprints()
        {
            return new AllSprints().GetAll();
        }

        private List<Sprint> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
