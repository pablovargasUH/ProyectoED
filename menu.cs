using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Estructura_de_Datos_V2__Versión_2_
{
    internal class menu
    {

        public static void MostrarMenu()
        {
           
            string opcion = "";
            string menu = "***Aplicación pago de servicios públicos***\n";
            menu += "1. Inicializar Vectores\n";
            menu += "2. Realizar Pagos\n";
            menu += "3. Consultar Pagos\n";
            menu += "4. Modificar Pagos\n";
            menu += "5. Eliminar Pagos\n";
            menu += "6. Submenú Reportes\n";
            menu += "7. Salir\n";
            menu += "Digite una opción: ";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(menu);
                opcion = Console.ReadLine();
                //Validar

                switch (opcion)
                {

                    case "1":
                        RealizarPago.InicializarVectores();
                        break;

                    case "2":
                        RealizarPago.HacerPago();
                        break;

                    case "3":
                        RealizarPago.ConsultarPago();
                        break;

                    case "4":
                        RealizarPago.ModificarPago();
                        break;

                    case "5":
                        RealizarPago.EliminarPago();
                        break;

                    case "6":
                        Submenu.SubMenu();
                        break;


                    case "7":
                        Environment.Exit(0);
                        break;

                }


            } while (opcion != "7");

        }//Fin mostrar menu





    }
}
