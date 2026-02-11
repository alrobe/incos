namespace EcuacionCuadratica
{
    class EcuacionCuadratica
    {
        static void Main(string[] args)
        {
            // Realizar un algoritmo que permita obtener las raíces de una ecuación cuadrática. Las
            // condiciones y restricciones son que A no puede valer 0 y el contenido dentro de la raíz
            // no puede ser negativo.

            double a, b, c;
            double discriminante;
            Console.WriteLine("Este programa resuelve ecuaciones cuadráticas de la forma ax^2 + bx + c = 0");

            Console.WriteLine("Ingrese el valor de a: ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el valor de b: ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el valor de c: ");
            c = Convert.ToDouble(Console.ReadLine()); 

            if (a == 0) {
                Console.WriteLine("El valor de a no puede ser 0");
                return;
            }

            discriminante = (b * b) - (4 * a * c);

            if (discriminante < 0) {
                Console.WriteLine("La ecuación no tiene solución real");
            } else if (discriminante == 0) {
                double x = -b / (2 * a);
                Console.WriteLine("La ecuación tiene una solución real: " + x);
            } else {
                double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                Console.WriteLine("La ecuación tiene dos soluciones reales: " + x1 + " y " + x2);
            }

        }
    }
}