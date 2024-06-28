using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Estructura_de_Datos_V2_Versión_2;

namespace Proyecto_Estructura_de_Datos_V2__Versión_2_
{
    internal class Submenu
    {
        public static void SubMenu()
        {
            string opci = "";
            string men = "***Sub Menú Reportes***\n";
            men += "1.Ver todos los Pagos\n";
            men += "2.Ver Pagos por tipo de Servicio\n";
            men += "3.Ver Pagos por código de caja\n";
            men += "4.Ver Dinero Comisionado por servicios\n";
            men += "5.Regresar Menú Principal\n";
            men += "Digite una opción";

            do
            {

                Console.WriteLine(men);
                opci = Console.ReadLine();

                switch (opci)
                {
                    case "1":
                        VerPagos.VPagos();
                        break;

                    case "2":
                        VerPagos.VPagos();
                        break;

                    case "3":
                        CodigoCaja.MostrarPagosPorCodigoCaja();
                        break;

                    case "4":
                        DineroComision.MostrarDineroComisionadoPorServicios();
                        break;

                    case "5:":
                        menu.MostrarMenu();
                        break;
                }

            } while (opci != "5");

        }//Fin SubMenu

    }
}
