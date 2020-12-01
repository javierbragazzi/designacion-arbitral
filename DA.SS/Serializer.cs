using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace DA.SS
{
    public static class Serializer
    {
        public static void XmlSerialization(object obj, string nombreArchivo)
        {
            string directorio = ConfigurationManager.AppSettings["PathSerializer"];

            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            var x = new XmlSerializer(obj.GetType());
            var archivo = File.Create(directorio + nombreArchivo + ".xml");
            x.Serialize(archivo, obj);
            archivo.Close();
        }
    }
}
