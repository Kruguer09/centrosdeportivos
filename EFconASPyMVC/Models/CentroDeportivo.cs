namespace EFconASPyMVC.Models
{
    public class CentroDeportivo
    {
        //Clave primaria
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        
        //Navegacional con Director 1:1
        public Director Director { get; set; }


        //Navegacional con Pista, con relación 1:N
        public List<Pista> Pistas { get; set; }

        //Navegacional N:N
        public List<CentroDeportivoUsuario> CentroDeportivoUsuarios { get; set; }
    }
}
