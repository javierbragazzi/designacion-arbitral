using System.Windows.Controls;
using DA.BE;

namespace DA.SS
{
    /// <summary>
    /// Clase que valido los campos nulos
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ValidationRule" />
    public class ValorNoNulo : ValidationRule
    {
        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult" /> object.
        /// </returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = value as string;

            if (!string.IsNullOrEmpty(str))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                
                var idioma = SingletonIdioma.Instancia.IdiomaSubject.Idioma;
                if (idioma != null)
                {
                    return new ValidationResult(false, idioma.Leyendas.Find(delegate (Leyenda leye) { return leye.Etiqueta.Equals("ValidationRuleNoNulo"); }).Traduccion.TextoTraducido);
                }
                else
                {
                    return new ValidationResult(false, "Campo requerido");
                }

               
                
            }
        }

       
    }
}
