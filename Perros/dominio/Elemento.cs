using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()//en el formulario en la columna tipo nos muestra la definicion del objeto, por lo que SOBREESCRIBIMOS EL METODO TO STRING
        {
            return Descripcion;
        }
    }
}
