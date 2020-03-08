using System.Collections.Generic;

namespace FunPro.CW1._7586.DAL
{
    public class AllSprints
    {
        public List<Sprint> GetAllSprints()
        {
            return new SprintManager().GetAll();
        }
    }
}
