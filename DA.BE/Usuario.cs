using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DA.BE.Composite;

namespace DA.BE
{

    [Tabla( "Usuario")]
    public class Usuario : EntidadBase, IComparable
    {

        [XmlIgnore]
        public string Apellido
        {
            [Columna("Apellido", "Apellido", typeof(string), false, false)]
            get;
            set;
        }

        [XmlIgnore]
        public string Nombre
        {
            [Columna("Nombre", "Nombre", typeof(string), false, false)]
            get;
            set;
        }

        [XmlIgnore]
        public string NombreUsuario
        {
            [Columna("NombreUsuario", "NombreUsuario", typeof(string), false, false)]
            get;
            set;
        }


        [XmlIgnore]
        public string Password
        {
            [Columna("Password", "Password", typeof(string), false, false)]
            get;
            set;
        }

        [XmlIgnore]
        public bool? Activo
        {
            [Columna("Activo", "Activo", typeof(bool?), false, false)]
            get;
            set;
        }

        [XmlIgnore]
        public string DVH
        {
            [Columna("DVH", "DVH", typeof(string), false, false)]
            get;
            set;
        }

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
