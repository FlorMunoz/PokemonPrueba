using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon//es lo que contiene la tabla, las columnas
    {
        public int Id { get; set; }

        [DisplayName("Número")]//"anotacion ", se escribe arriba de lo que quemos modificar, en este caso que salga con acento la palabra
        public int Numero { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]//"anotacion "
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; }
    }
}
