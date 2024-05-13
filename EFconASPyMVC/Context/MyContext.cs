using EFconASPyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFconASPyMVC.Context
{
    public class MyContext : DbContext
    {
        //Establecemos el motor de la base de datos
        //especificando su cadena de conexión
        //Implementación del constructor
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Con esto estamos utilizando ApiFluent y le estamos diciendo que la entidad
            //Estudiante curso va a tener una clave primaria compuesta por CursoId y EstudianteId
            modelBuilder.Entity<CentroDeportivoUsuario>().HasKey(x => new { x.UsuarioId, x.CentroDeportivoId });
        }       
        //creamos una tabla llamada Direcciones
        //a partir de nuestra clase Direccion
        public DbSet<CentroDeportivo> CentrosDeportivos { get; set; }
        //creamos una tabla llamada Estudiantes
        //a partir de nuestra clase Estudiante
        public DbSet<Director> Directores { get; set; }

        //creamos una tabla llamada Institutos
        //a partir de nuestra clase Instituto
        public DbSet<Pista> Pistas { get; set; }

        //creamos una tabla llamada Cursos
        //a partir de nuestra clase Curso
        public DbSet<Usuario> Usuarios { get; set; }

        //creamos una tabla llamada EstudiantesCursos
        //a partir de nuestra clase EstudianteCurso
        public DbSet<CentroDeportivoUsuario> CentrosUsuarios { get; set; }
    }
}
