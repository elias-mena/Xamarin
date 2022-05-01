using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora
{
    public class Operacion
    {
        public string Resultado { get; set; }
        public Operacion(string r)
        {
            Resultado = r;
        }
        public override string ToString()
        {
            return Resultado;
        }
    }
}
