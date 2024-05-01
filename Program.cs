using System;

namespace MetodoDNI
{
    internal class Program
    {
        static string dni = " ";  // Aquí definimos dni a nivel de clase
        
        static void Main(string[] args)
        {
            Console.Write("Ingresa DNI: ");
            dni = Console.ReadLine(); // Asignamos el valor ingresado a la variable dni ya definida
            var (Letra, DNICompleto) = CalculoDNI(dni); 
            Console.Write("La letra es: ");
            Console.WriteLine(Letra);
            Console.Write("El DNI completo es: ");
            Console.WriteLine(DNICompleto);
        }
        
        static (string,string) CalculoDNI(string MiDNI)
        {
            string[] Letra = { "T", "R", "W", "A", "G", "M", "Y", "F",
            "P", "D", "X", "B", "N", "J","Z","S","Q","V","H","L","C","K","E" };
            int valor = 0;
            int Calculo = 0;
            string LetraDNI = " ";
            String DNICompleto= "";
            valor= Convert.ToInt32(MiDNI);
            Calculo = valor % 23;
            LetraDNI= Letra [Calculo];
            DNICompleto= valor.ToString("00,000,000-")+ LetraDNI;
            return (LetraDNI, DNICompleto);
        }
    }
}
