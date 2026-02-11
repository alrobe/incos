namespace GradodeEficiencia
{
    class GradodeEficiencia
    {
        static void Main(string[] args)
        {
            // Diseñe un algoritmo para obtener el grado de eficiencia de un operario de una fábrica
            // de tornillos, de acuerdo a las siguientes condiciones, que se le imponen para un
            // período de prueba:
            //  Menos de 200 tornillos defectuosos. V
            //  Más de 10000 tornillos producidos. V
            // El grado de eficiencia se determina de la siguiente manera:
            //  Si no cumple ninguna de las condiciones, grado 5.
            //  Si sólo cumple la primera condición, grado 6.
            //  Si sólo cumple la segunda condición, grado 7.
            //  Si cumple las dos condiciones, grado 8.

            int tornillosDefectuosos, tornillosProducidos;
            int minimoTornillosProducidos = 10000;
            int maximoTornillosDefectuosos = 200;
            int gradodeEficiencia = 0;

            Console.WriteLine("Ingrese la cantidad de tornillos defectuosos: ");
            tornillosDefectuosos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de tornillos producidos: ");
            tornillosProducidos = Convert.ToInt32(Console.ReadLine());

            if (tornillosDefectuosos > maximoTornillosDefectuosos && tornillosProducidos < minimoTornillosProducidos) {
                gradodeEficiencia = 5;
            } else if (tornillosDefectuosos <= maximoTornillosDefectuosos && tornillosProducidos < minimoTornillosProducidos) {
                gradodeEficiencia = 6;
            } else if (tornillosDefectuosos > maximoTornillosDefectuosos && tornillosProducidos >= minimoTornillosProducidos) {
                gradodeEficiencia = 7;
            } else if (tornillosDefectuosos <= maximoTornillosDefectuosos && tornillosProducidos >= minimoTornillosProducidos) {
                gradodeEficiencia = 8;
            } 

            Console.WriteLine("El grado de eficiencia es: " + gradodeEficiencia);
        }
    }
}