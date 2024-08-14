using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Helper
{
    public static class Validacion
    {
        public static bool validarTextoVacio(string control)
        {
            if (string.IsNullOrEmpty(control))
            {
              
                    return true;
            
            }
            else
                    return false;   
        }
    }
}
