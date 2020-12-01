using System.Runtime.InteropServices;

namespace DA.BE
{
    /// <summary>
    /// Clase base para las entidades
    /// </summary>
    public class EntidadBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            [Columna("Id", "Id" ,typeof(long), true, false)]
            get;
            set;
        }

    }
}
