
using EFconASPyMVC;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EFconASPyMVC
{
    public static class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente la base de datos sin necesidad de migraciones

            // Comprueba si hay algún Director
            if (context.CentrosDeportivos.Any())
            {
                return;   // BD ya ha sido inicializada
            }
            //Añado Centros deportivos
            var centros = new CentroDeportivo[]
            {
            new CentroDeportivo{Nombre="Fontanar",Direccion="C/ Fontanar"},
            new CentroDeportivo{Nombre="Vistalegre",Direccion="Plaza Vistalegre"},
            new CentroDeportivo{Nombre="Arcangel", Direccion = "Avd Campo"  },
            new CentroDeportivo{Nombre="Figueroa", Direccion = "Plaza Fifueroa"}
            };
            foreach (CentroDeportivo i in centros)
            {
                context.CentrosDeportivos.Add(i);
            }
            context.SaveChanges();
            //Añado directores
            var direc = new Director[]
            {
            new Director{Nombre="Antonio García",Empleados=5,CentroDeportivoId=1},
            new Director{Nombre="María Deportiva",Empleados=4,CentroDeportivoId=2},
            new Director{Nombre="Juana la Loca", Empleados = 6, CentroDeportivoId=3},
            new Director{Nombre="Felipe Gonzalez", Empleados = 4, CentroDeportivoId=4}

            };
            foreach (Director a in direc)
            {
                context.Directores.Add(a);
            }
            context.SaveChanges();
            //Añado pistas
            var pistas = new Pista[]
            {
            new Pista{Nombre= "Atletismo",Aforo=10,CentroDeportivoId=1},
            new Pista{Nombre= "Tenis",Aforo=4,CentroDeportivoId=1},
            new Pista{Nombre= "Baloncesto",Aforo=20,CentroDeportivoId=2},
            new Pista{Nombre= "Fútbol",Aforo=30,CentroDeportivoId=2},
            new Pista{Nombre= "Paddel",Aforo=4,CentroDeportivoId=3},
            new Pista{Nombre= "Petanca",Aforo=8,CentroDeportivoId=3},
            new Pista{Nombre= "Atletismo",Aforo=10,CentroDeportivoId=4},
            new Pista{Nombre= "Salto",Aforo=10,CentroDeportivoId=4}
            };
            foreach (Pista s in pistas)
            {
                context.Pistas.Add(s);
            }
            context.SaveChanges();

            //Añado usuarios
            var usu = new Usuario[]
            {
            new Usuario{Nombre="Antonio Pérez",Direccion="C/ Fontanar"},
            new Usuario{Nombre="Jose García",Direccion="C/ Fontaner"},
            new Usuario{Nombre="María García",Direccion="C/ Fontanir"},
            new Usuario{Nombre="Julia Gómez",Direccion="C/ Fontanor"},
            new Usuario{Nombre="Marcos Polos",Direccion="C/ Fontanur"},
            new Usuario{Nombre="Laura Villafuerte",Direccion="C/ Angel"},
            new Usuario{Nombre="Ana Séseamo",Direccion="C/ Ángeles"},
            new Usuario{Nombre="Thor Valhalla",Direccion="C/ Ángela"},
            };


            foreach (Usuario d in usu)
            {
                context.Usuarios.Add(d);
            }
            context.SaveChanges();

            //Añado CentroDeportivoUsuario
            var cu = new CentroDeportivoUsuario[]
            {
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=1},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=2},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=3},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=4},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=5},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=6},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioId=7},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=1},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=2},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=3},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=4},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=5},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=6},
            new CentroDeportivoUsuario{CentroDeportivoId=2,UsuarioId=7},
            new CentroDeportivoUsuario{CentroDeportivoId=3,UsuarioId=1},
            new CentroDeportivoUsuario{CentroDeportivoId=3,UsuarioId=2},
            new CentroDeportivoUsuario{CentroDeportivoId=4,UsuarioId=3},
            new CentroDeportivoUsuario{CentroDeportivoId=4,UsuarioId=4},
            };
            foreach (CentroDeportivoUsuario esC in cu)
            {
                context.CentrosUsuarios.Add(esC);
            }
            context.SaveChanges();
        }

    }

}
