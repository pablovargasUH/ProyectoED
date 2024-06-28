using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Estructura_de_Datos_V2__Versión_2_
{
    internal class RealizarPago
    {
        public static int[] numeroPago { get; set; } = new int[10];
        public static int[] numeroFactura { get; set; } = new int[10];
        public static int[] numeroCaja { get; set; } = new int[10];
        public static float[] montoPagar { get; set; } = new float[10];
        public static double[] comision { get; set; } = new double[10];
        public static double[] montoDeducido { get; set; } = new double[10];
        public static float[] pagoCliente { get; set; } = new float[10];
        public static float[] vuelto { get; set; } = new float[10];
        public static int[] tipoServicio { get; set; } = new int[10];

        public static string[] cedula { get; set; } = new string[10];
        public static string[] nombre { get; set; } = new string[10];
        public static string[] apellido1 { get; set; } = new string[10];
        public static string[] apellido2 { get; set; } = new string[10];
        public static string[] fecha { get; set; } = new string[10];
        public static string[] hora { get; set; } = new string[10];

        private static int indice = 0;

        public static void InicializarVectores()
        {
            for (int i = 0; i < 10; i++)
            {
                numeroPago[i] = 0;
                numeroFactura[i] = 0;
                montoPagar[i] = 0;
                comision[i] = 0;
                montoDeducido[i] = 0;
                pagoCliente[i] = 0;
                vuelto[i] = 0;
                numeroCaja[i] = 0;
                tipoServicio[i] = 0;

                cedula[i] = String.Empty;
                nombre[i] = String.Empty;
                apellido1[i] = String.Empty;
                apellido2[i] = String.Empty;
                fecha[i] = String.Empty;
                hora[i] = String.Empty;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vectores inicializados correctamente");
            Console.ResetColor();
        }

        public static void HacerPago()
        {
            char op = 'n';

            do
            {
                if (indice >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vectores Llenos. No se pueden agregar más pagos.");
                    Console.ResetColor();
                    break;
                }

                // Generar número de pago
                numeroPago[indice] = indice + 1;

                Console.WriteLine("Número de pago: " + numeroPago[indice]);
                Console.WriteLine("Ingrese la fecha: ");
                fecha[indice] = Console.ReadLine();
                Console.WriteLine("Ingrese la hora: ");
                hora[indice] = Console.ReadLine();
                Console.WriteLine("Digite su cédula: ");
                cedula[indice] = Console.ReadLine();
                Console.WriteLine("Digite su nombre: ");
                nombre[indice] = Console.ReadLine();
                Console.WriteLine("Digite su Primer Apellido: ");
                apellido1[indice] = Console.ReadLine();
                Console.WriteLine("Digite su Segundo Apellido: ");
                apellido2[indice] = Console.ReadLine();
                NumCaja();
                Console.WriteLine("Digite el tipo de servicio: 1 - Recibo de Luz, 2 - Recibo Telefónico, " +
                                  "3 - Recibo de Agua");
                int.TryParse(Console.ReadLine(), out tipoServicio[indice]);
                Console.WriteLine("Digite el número de Factura: ");
                int.TryParse(Console.ReadLine(), out numeroFactura[indice]);
                Console.WriteLine("Digite el monto a pagar: ");
                float.TryParse(Console.ReadLine(), out montoPagar[indice]);
                Comi();
                Deducido();
                Pago();
                Vuel();
                indice++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("El pago ha sido agregado correctamente");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¿Desea agregar otro pago? (s/n)");
                Console.ForegroundColor = ConsoleColor.White;
                op = Convert.ToChar(Console.ReadLine());
            } while (op != 'n');
        }

        private static void NumCaja()
        {
            // Generar número de caja aleatorio entre 1 y 3
            Random rnd = new Random();
            numeroCaja[indice] = rnd.Next(1, 4);
            Console.WriteLine("Número de caja: " + numeroCaja[indice]);
        }

        private static void Comi()
        {
            if (tipoServicio[indice] == 1)
            {
                comision[indice] = montoPagar[indice] * 0.04;
                Console.WriteLine("Comisión autorizada: " + comision[indice]);
            }
            else if (tipoServicio[indice] == 2)
            {
                comision[indice] = montoPagar[indice] * 0.055;
                Console.WriteLine("Comisión autorizada: " + comision[indice]);
            }
            else if (tipoServicio[indice] == 3)
            {
                comision[indice] = montoPagar[indice] * 0.065;
                Console.WriteLine("Comisión autorizada: " + comision[indice]);
            }
        }

        private static void Deducido()
        {
            montoDeducido[indice] = montoPagar[indice] - comision[indice];
            Console.WriteLine("El monto deducido es: " + montoDeducido[indice]);
        }

        private static void Pago()
        {
            Console.WriteLine("Ingrese la cantidad con la que paga: ");
            float.TryParse(Console.ReadLine(), out pagoCliente[indice]);

            if (pagoCliente[indice] < montoPagar[indice])
            {
                Console.WriteLine("El pago no puede ser procesado, saldo insuficiente");
            }
            else
            {
                Console.WriteLine("Paga con: " + pagoCliente[indice]);
            }
        }

        private static void Vuel()
        {
            vuelto[indice] = pagoCliente[indice] - montoPagar[indice];
            Console.WriteLine("Vuelto: " + vuelto[indice]);
        }

        public static void ConsultarPago()
        {
            Console.WriteLine("Ingrese el número de pago que desea consultar:");
            int numConsulta;
            bool esNumero = int.TryParse(Console.ReadLine(), out numConsulta);

            if (esNumero && numConsulta >= 1 && numConsulta <= indice)
            {
                bool pagoEncontrado = false;

                for (int i = 0; i < indice; i++)
                {
                    if (numeroPago[i] == numConsulta)
                    {
                        Console.WriteLine("\nDatos del Pago:");
                        Console.WriteLine($"Número de Pago: {numeroPago[i]}");
                        Console.WriteLine($"Fecha: {fecha[i]}");
                        Console.WriteLine($"Hora: {hora[i]}");
                        Console.WriteLine($"Cédula: {cedula[i]}");
                        Console.WriteLine($"Nombre: {nombre[i]}");
                        Console.WriteLine($"Primer Apellido: {apellido1[i]}");
                        Console.WriteLine($"Segundo Apellido: {apellido2[i]}");
                        Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                        Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                        Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                        Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                        Console.WriteLine($"Monto Comisión: {comision[i]}");
                        Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                        Console.WriteLine($"Monto Pagado por Cliente: {pagoCliente[i]}");
                        Console.WriteLine($"Vuelto: {vuelto[i]}");

                        pagoEncontrado = true;
                        break;
                    }
                }

                if (!pagoEncontrado)
                {
                    Console.WriteLine("Pago no se encuentra registrado.");
                }
            }
            else
            {
                Console.WriteLine("Número de pago inválido o fuera de rango.");
            }

            Console.ReadLine();
        }

        public static void ModificarPago()
        {
            Console.WriteLine("Ingrese el número de pago que desea modificar:");
            int numModificacion;
            bool esNumero = int.TryParse(Console.ReadLine(), out numModificacion);

            if (esNumero && numModificacion >= 1 && numModificacion <= indice)
            {
                int indicePago = -1;

                // Buscar la posición del pago a modificar
                for (int i = 0; i < indice; i++)
                {
                    if (numeroPago[i] == numModificacion)
                    {
                        indicePago = i;
                        break;
                    }
                }

                if (indicePago != -1)
                {
                    // Mostrar datos actuales del pago
                    Console.WriteLine("\nDatos del Pago a Modificar:");
                    Console.WriteLine($"Número de Pago: {numeroPago[indicePago]}");
                    Console.WriteLine($"Fecha: {fecha[indicePago]}");
                    Console.WriteLine($"Hora: {hora[indicePago]}");
                    Console.WriteLine($"Cédula: {cedula[indicePago]}");
                    Console.WriteLine($"Nombre: {nombre[indicePago]}");
                    Console.WriteLine($"Primer Apellido: {apellido1[indicePago]}");
                    Console.WriteLine($"Segundo Apellido: {apellido2[indicePago]}");
                    Console.WriteLine($"Número de Caja: {numeroCaja[indicePago]}");
                    Console.WriteLine($"Tipo de Servicio: {tipoServicio[indicePago]}");
                    Console.WriteLine($"Número de Factura: {numeroFactura[indicePago]}");
                    Console.WriteLine($"Monto a Pagar: {montoPagar[indicePago]}");
                    Console.WriteLine($"Monto Comisión: {comision[indicePago]}");
                    Console.WriteLine($"Monto Deducido: {montoDeducido[indicePago]}");
                    Console.WriteLine($"Monto Pagado por Cliente: {pagoCliente[indicePago]}");
                    Console.WriteLine($"Vuelto: {vuelto[indicePago]}");

                    // Menú para modificar datos
                    Console.WriteLine("\nSeleccione el dato que desea modificar:");
                    Console.WriteLine("1. Fecha");
                    Console.WriteLine("2. Hora");
                    Console.WriteLine("3. Cédula");
                    Console.WriteLine("4. Nombre");
                    Console.WriteLine("5. Primer Apellido");
                    Console.WriteLine("6. Segundo Apellido");
                    Console.WriteLine("7. Tipo de Servicio");
                    Console.WriteLine("8. Número de Factura");
                    Console.WriteLine("9. Monto a Pagar");
                    Console.WriteLine("10. Pago del Cliente");

                    int opcion;
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Ingrese la nueva fecha:");
                                fecha[indicePago] = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Ingrese la nueva hora:");
                                hora[indicePago] = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Ingrese la nueva cédula:");
                                cedula[indicePago] = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Ingrese el nuevo nombre:");
                                nombre[indicePago] = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Ingrese el nuevo primer apellido:");
                                apellido1[indicePago] = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Ingrese el nuevo segundo apellido:");
                                apellido2[indicePago] = Console.ReadLine();
                                break;
                            case 7:
                                Console.WriteLine("Ingrese el nuevo tipo de servicio (1, 2 o 3):");
                                int.TryParse(Console.ReadLine(), out tipoServicio[indicePago]);
                                break;
                            case 8:
                                Console.WriteLine("Ingrese el nuevo número de factura:");
                                int.TryParse(Console.ReadLine(), out numeroFactura[indicePago]);
                                break;
                            case 9:
                                Console.WriteLine("Ingrese el nuevo monto a pagar:");
                                float.TryParse(Console.ReadLine(), out montoPagar[indicePago]);
                                Comi(); // Recalcular comisión y monto deducido
                                Deducido();
                                break;
                            case 10:
                                Console.WriteLine("Ingrese el nuevo monto pagado por el cliente:");
                                float.TryParse(Console.ReadLine(), out pagoCliente[indicePago]);
                                Vuel(); // Recalcular vuelto
                                break;
                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pago modificado correctamente.");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Pago no se encuentra registrado.");
                }
            }
            else
            {
                Console.WriteLine("Número de pago inválido o fuera de rango.");
            }

            Console.ReadLine();
        }
public static void EliminarPago()
{
    Console.WriteLine("Ingrese el número de pago que desea eliminar:");
    int numEliminacion;
    bool esNumero = int.TryParse(Console.ReadLine(), out numEliminacion);

    if (esNumero && numEliminacion >= 1 && numEliminacion <= indice)
    {
        int indicePago = -1;

        // Buscar la posición del pago a eliminar
        for (int i = 0; i < indice; i++)
        {
            if (numeroPago[i] == numEliminacion)
            {
                indicePago = i;
                break;
            }
        }

        if (indicePago != -1)
        {
            // Mostrar los datos del pago que se va a eliminar
            Console.WriteLine("\nDatos del Pago a Eliminar:");
            Console.WriteLine($"Número de Pago: {numeroPago[indicePago]}");
            Console.WriteLine($"Fecha: {fecha[indicePago]}");
            Console.WriteLine($"Hora: {hora[indicePago]}");
            Console.WriteLine($"Cédula: {cedula[indicePago]}");
            Console.WriteLine($"Nombre: {nombre[indicePago]}");
            Console.WriteLine($"Primer Apellido: {apellido1[indicePago]}");
            Console.WriteLine($"Segundo Apellido: {apellido2[indicePago]}");
            Console.WriteLine($"Número de Caja: {numeroCaja[indicePago]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[indicePago]}");
            Console.WriteLine($"Número de Factura: {numeroFactura[indicePago]}");
            Console.WriteLine($"Monto a Pagar: {montoPagar[indicePago]}");
            Console.WriteLine($"Monto Comisión: {comision[indicePago]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[indicePago]}");
            Console.WriteLine($"Monto Pagado por Cliente: {pagoCliente[indicePago]}");
            Console.WriteLine($"Vuelto: {vuelto[indicePago]}");

            // Confirmar eliminación
            Console.WriteLine("\n¿Está seguro de eliminar el dato? (S/N)");
            string respuesta = Console.ReadLine().Trim().ToUpper();

            if (respuesta == "S")
            {
                // Desplazar los elementos en los vectores para eliminar el pago
                for (int i = indicePago; i < indice - 1; i++)
                {
                    numeroPago[i] = numeroPago[i + 1];
                    numeroFactura[i] = numeroFactura[i + 1];
                    montoPagar[i] = montoPagar[i + 1];
                    comision[i] = comision[i + 1];
                    montoDeducido[i] = montoDeducido[i + 1];
                    pagoCliente[i] = pagoCliente[i + 1];
                    vuelto[i] = vuelto[i + 1];
                    numeroCaja[i] = numeroCaja[i + 1];
                    tipoServicio[i] = tipoServicio[i + 1];

                    cedula[i] = cedula[i + 1];
                    nombre[i] = nombre[i + 1];
                    apellido1[i] = apellido1[i + 1];
                    apellido2[i] = apellido2[i + 1];
                    fecha[i] = fecha[i + 1];
                    hora[i] = hora[i + 1];
                }

                // Limpiar el último elemento
                numeroPago[indice - 1] = 0;
                numeroFactura[indice - 1] = 0;
                montoPagar[indice - 1] = 0;
                comision[indice - 1] = 0;
                montoDeducido[indice - 1] = 0;
                pagoCliente[indice - 1] = 0;
                vuelto[indice - 1] = 0;
                numeroCaja[indice - 1] = 0;
                tipoServicio[indice - 1] = 0;

                cedula[indice - 1] = String.Empty;
                nombre[indice - 1] = String.Empty;
                apellido1[indice - 1] = String.Empty;
                apellido2[indice - 1] = String.Empty;
                fecha[indice - 1] = String.Empty;
                hora[indice - 1] = String.Empty;

                // Decrementar el índice total
                indice--;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("La información ha sido eliminada.");
                Console.ResetColor();
            }
            else if (respuesta == "N")
            {
                Console.WriteLine("La información no fue eliminada.");
            }
            else
            {
                Console.WriteLine("Respuesta inválida. La información no fue eliminada.");
            }
        }
        else
        {
            Console.WriteLine("Pago no se encuentra registrado.");
        }
    }
    else
    {
        Console.WriteLine("Número de pago inválido o fuera de rango.");
    }

    Console.ReadLine();
}

    }
}