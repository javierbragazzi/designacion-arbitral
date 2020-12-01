using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DA.BE.Composite;

namespace DA.BE
{
    /// <summary>
    /// Clase Usuario
    /// </summary>
    /// <seealso cref="DA.BE.EntidadBase" />
    [Tabla( "Usuario")]
    public class Usuario : EntidadBase, IComparable
    {
        /// <summary>
        /// Gets or sets the apellido.
        /// </summary>
        /// <value>
        /// The apellido.
        /// </value>
        [XmlIgnore]
        public string Apellido
        {
            [Columna("Apellido", "Apellido", typeof(string), false, false)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        [XmlIgnore]
        public string Nombre
        {
            [Columna("Nombre", "Nombre", typeof(string), false, false)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the nombre usuario.
        /// </summary>
        /// <value>
        /// The nombre usuario.
        /// </value>
        [XmlIgnore]
        public string NombreUsuario
        {
            [Columna("NombreUsuario", "NombreUsuario", typeof(string), false, false)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [XmlIgnore]
        public string Password
        {
            [Columna("Password", "Password", typeof(string), false, false)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Usuario"/> is activo.
        /// </summary>
        /// <value>
        ///   <c>false</c> if activo; otherwise, <c>false</c>.
        /// </value>
        [XmlIgnore]
        public bool? Activo
        {
            [Columna("Activo", "Activo", typeof(bool?), false, false)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DVH.
        /// </summary>
        /// <value>
        /// The DVH.
        /// </value>
        [XmlIgnore]
        public string DVH
        {
            [Columna("DVH", "DVH", typeof(string), false, false)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the permisos.
        /// </summary>
        /// <value>
        /// The permisos.
        /// </value>
        [XmlIgnore]
        public List<PermisoComponente> Permisos { get; set; }

        [XmlIgnore]
        public string NombreCompleto { get; set; }

        [XmlIgnore]
        public Idioma Idioma
        {
            [Columna("IdIdioma", "Idioma", typeof(long), false, false)]
            get;
            set;
        }

        [XmlIgnore]
        public string Perfil
        {
            get
            {
                foreach (PermisoComponente permisoComponente in Permisos)
                {
                    if (permisoComponente.EsPermiso == false || permisoComponente.EsPermiso == null)
                    {
                        return permisoComponente.Descripcion;
                    }
                }

                return "";
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                //if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public Usuario()
        {
            Permisos = new List<PermisoComponente>();
        }

        public int CompareTo(object obj)
        {
            Usuario usuario = (Usuario)obj;

            return String.CompareOrdinal(this.NombreUsuario, usuario.NombreUsuario);
        }
    }


}
