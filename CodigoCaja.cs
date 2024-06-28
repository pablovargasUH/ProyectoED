namespace Proyecto_Estructura_de_Datos_V2_Versión_2;

public class CodigoCaja
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

    public static int indice = 1;
    public static int codigoCaja = 1;

    public static void MostrarPagosPorCodigoCaja()
    {
        Console.WriteLine($"Mostrando pagos para el código de caja {codigoCaja}:");
        Console.WriteLine("-------------------------------------------------------");

        for (int i = 1; i < indice; i++)
        {
            if (numeroCaja[i] == codigoCaja)
            {
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
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]:C}");
                Console.WriteLine($"Comisión: {comision[i]:C}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]:C}");
                Console.WriteLine($"Monto Paga Cliente: {pagoCliente[i]:C}");
                Console.WriteLine($"Vuelto: {vuelto[i]:C}");
                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}