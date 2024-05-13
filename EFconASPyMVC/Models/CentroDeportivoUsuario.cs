namespace EFconASPyMVC.Models
{
    public class CentroDeportivoUsuario
    {
        //Clave principal compuesta
        public int UsuarioId { get; set; }
        public int CentroDeportivoId { get; set; }
        //Navegacionales
        public CentroDeportivo CentroDeportivo {  get; set; }
        public Usuario Usuario { get; set; }
    }
}
