namespace EFconASPyMVC.Models
{
    public class Director
    {
        //Clave primaria
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Empleados { get; set; }
        //Foránea
        public int CentroDeportivoId { get; set; }

        public CentroDeportivo CentroDeportivo {  get; set; }

    }
}
