using System.Runtime.InteropServices;

namespace DA.BE
{
    public class EntidadBase
    {
        public int Id
        {
            [Columna("Id", "Id" ,typeof(long), true, false)]
            get;
            set;
        }

    }
}
