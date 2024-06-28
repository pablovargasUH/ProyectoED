namespace Proyecto_Estructura_de_Datos_V2_Versión_2
{
    public class DineroComision
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
        public static void MostrarDineroComisionadoPorServicios()
        {

            double comisionElectricidad = 0;
            double comisionTelefono = 0;
            double comisionAgua = 0;
            int countElectricidad = 0;
            int countTelefono = 0;
            int countAgua = 0;


            for (int i = 1; i < indice; i++)
            {
                switch (tipoServicio[i])
                {
                    case 1: // Recibo de Luz
                        comisionElectricidad += comision[i];
                        countElectricidad++;
                        break;
                    case 2: // Recibo Telefónico
                        comisionTelefono += comision[i];
                        countTelefono++;
                        break;
                    case 3: // Recibo de Agua
                        comisionAgua += comision[i];
                        countAgua++;
                        break;
                    default:
                        break;
                }
            }

            // Mostrar el reporte
            Console.WriteLine("Dinero Comisionado por Servicios:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Recibo de Luz: {comisionElectricidad:C} - Transacciones: {countElectricidad}");
            Console.WriteLine($"Recibo Telefónico: {comisionTelefono:C} - Transacciones: {countTelefono}");
            Console.WriteLine($"Recibo de Agua: {comisionAgua:C} - Transacciones: {countAgua}");
            Console.WriteLine("---------------------------------");
        }
    }
}