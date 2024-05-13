namespace EFconASPyMVC.Models
{
    public class Usuario
    {
        //Clace principal
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }


        public List<CentroDeportivoUsuario> CentroDeportivoUsuarios { get; set; }
    }
}
