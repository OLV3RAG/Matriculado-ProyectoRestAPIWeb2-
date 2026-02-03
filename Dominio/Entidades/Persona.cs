using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Persona
    {
        public int ID { get; set; }

            [Required(ErrorMessage ="Escribe un nombre valido")]
            [StringLength (50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Escribe un apellido valido")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Escribe un apellido valido")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Escribe un CURP válido")]
        [StringLength(18, ErrorMessage = "La CURP debe tener 18 caracteres.")]
        [RegularExpression(@"^[A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HMX](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[A-Z0-9]\d$",
        ErrorMessage = "El CURP no tiene un formato válido.")]
        public string CURP { get; set; }
        public int TipoPersonaID { get; set; }
        public int GeneroID { get; set; }
    }
}
