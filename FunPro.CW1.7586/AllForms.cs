using System.Linq;
using System.Windows.Forms;

namespace FunPro.CW1._7586
{
    class AllForms
    {
        public static T GetForm<T>() where T : class, new()
        {
            return Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
        }
    }
}
