using System;

namespace MetodoDNI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear(); // Limpia la consola al iniciar el programa

            MostrarEncabezado();

            string dni;
            do
            {
                Console.Write("Ingrese el número de DNI (8 dígitos, sin letra): ");
                dni = Console.ReadLine(); // Asignamos el valor ingresado a la variable dni

                // Validar si el DNI ingresado es válido
                if (!ValidarDNI(dni))
                {
                    Console.WriteLine("\nDNI inválido. Asegúrate de ingresar un número de 8 dígitos.");
                    Console.WriteLine("Presiona Enter para intentar de nuevo...");
                    Console.ReadLine();
                }
                else
                {
                    break; // Salir del bucle si el DNI es válido
                }
            } while (true);

            var (Letra, DNICompleto) = CalculoDNI(dni);

            MostrarResultados(dni, Letra, DNICompleto);
        }

        static (string, string) CalculoDNI(string MiDNI)
        {
            string[] Letras = { "T", "R", "W", "A", "G", "M", "Y", "F",
                                "P", "D", "X", "B", "N", "J", "Z", "S",
                                "Q", "V", "H", "L", "C", "K", "E" };

            int valor = int.Parse(MiDNI); // Convertir el DNI a número
            int Calculo = valor % 23; // Calcular el índice para la letra
            string LetraDNI = Letras[Calculo]; // Obtener la letra correspondiente
            string DNICompleto = $"{valor:D8}-{LetraDNI}"; // Formato del DNI completo

            return (LetraDNI, DNICompleto);
        }

        static bool ValidarDNI(string dni)
        {
            // Verifica que el DNI ingresado tenga exactamente 8 dígitos
            return dni.Length == 8 && int.TryParse(dni, out _);
        }

        static void MostrarEncabezado()
        {
            Console.WriteLine(@"    
        *********************************************
        *             CALCULADORA DE DNI            *
        *********************************************
            Calcula la letra del DNI español         
            basado en el número proporcionado.       
            Ingresa un número de 8 dígitos para       
            obtener la letra correspondiente.         
                                                
            Para comenzar, introduce el DNI sin la   
            letra final.                             
        *********************************************
        ");
        }

        static void MostrarResultados(string dni, string letra, string dniCompleto)
        {
            Console.WriteLine(@"
        *********************************************
        *              RESULTADOS DEL DNI           *
        *********************************************
                                                
            Número de DNI: {0,-8}                   
            Letra: {1,-5}                           
            DNI Completo: {2,-12}                  
                                                
            Gracias por usar la calculadora de DNI. 
                                                
            Presiona Enter para salir...            
        *********************************************
        ", dni, letra, dniCompleto);

            Console.ReadLine(); // Pausar para que el usuario vea el resultado
        }
    }
}
