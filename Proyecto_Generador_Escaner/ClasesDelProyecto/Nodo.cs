using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Generador_Escaner.ClasesDelProyecto
{
    public class Nodo
    {
        public string simbolo;
        public int indice;
        public List<int> First = new List<int>();
        public List<int> Last = new List<int>();
        public bool Nulo;
    }
}
