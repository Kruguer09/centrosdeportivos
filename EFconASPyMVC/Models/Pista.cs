namespace EFconASPyMVC.Models
{
    public class Pista
    {
        //Clace principal
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Aforo { get; set; }
        
        //Foránea de centro deportivo
        public int CentroDeportivoId { get; set; }
        CentroDeportivo CentroDeportivo { get; set; }

    }
}
