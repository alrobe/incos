namespace PesoIdeal
{
    class PesoIdeal
    {
        static void Main(string[] args)
        {

            // Suponga que usted es un vendedor de la línea de productos para adelgazar Reduce
            // Fast. Es usted un empresario exitoso, y ha instalado
            // una tienda en el centro de la ciudad, donde puede
            // atender a sus clientes, ofrecerles su línea de
            // productos, evaluar su estado de salud, conversar con
            // ellos, etc. Usted tiene muchos clientes, y también
            // llegan muchos clientes nuevos, dado lo efectivo de
            // los productos que vende en su tienda. Lo primero que usted debe hacer cuando llega
            // un potencial cliente, es evaluarlo para saber si su peso corresponde al de una persona
            // delgada, normal, con sobrepeso u obesa. Para ello, usted cuenta con la fórmula del
            // peso ideal:

            // IMC = peso / (altura * altura)

            double peso, altura;
            double imc;

            Console.WriteLine("Ingrese su peso en kilogramos: ");
            peso = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese su altura en metros: ");
            altura = Convert.ToDouble(Console.ReadLine());

            imc = peso / (altura * altura);

            if (imc < 18.5) {
                Console.WriteLine("Usted tiene un peso inferior al normal");
            } else if (imc >= 18.5 && imc <= 24.9) {
                Console.WriteLine("Usted tiene un peso normal");
            } else if (imc >= 25 && imc <= 29.9) {
                Console.WriteLine("Usted tiene sobrepeso");
            } else if (imc >= 30 && imc <= 39.9) {
                Console.WriteLine("Usted tiene obesidad");
            } else {
                Console.WriteLine("Usted tiene obesidad morbica");
            }

        }
    }
}