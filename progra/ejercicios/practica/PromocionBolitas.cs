namespace PromocionBolitas
{
    class PromocionBolitas
    {
        static void Main(string[] args)
        {
            // En un supermercado se va a poner en marcha la “Promoción Bolitas”, la cual consiste
            // en que al llegar a la caja el cliente y proceder a efectuar el
            // pago correspondiente a sus compras, se le invita a sacar
            // una bolita al azar de una caja virtual y dependiendo del
            // color de la bolita obtendrá un descuento aplicable al total
            // de su cuenta.
            // Realizar el programa con las siguientes características:
            //  El cliente debe sacar una bolita de la caja (totalmente al azar).
            //  El sistema debe mostrarle al cliente la
            // bolita e indicarle el porcentaje del
            // descuento obtenido.
            //  EL sistema le solicita a la cajera teclear el
            // importe de la cuenta total del cliente.
            //  El sistema debe aplicar el descuento
            // correspondiente a la cuenta del cliente e indicar cuál es la cantidad a pagar.

            double importeCuenta;
            int descuento = 0;
            double totalPagar;

            // Se optiene el color de la bolita al azar
            Console.WriteLine("Escogiendo la bolita al azar");
            Random random = new Random();
            int colorBolita = random.Next(5);
            

            switch (colorBolita)
            {
                case 0:
                    Console.WriteLine("El color es Negro con descuento del 10%");
                    descuento = 10;
                    break;
                case 1:
                    Console.WriteLine("El color es Verde con descuento del 25%");
                    descuento = 25;
                    break;
                case 2:
                    Console.WriteLine("El color es Amarillo con descuento del 50%");
                    descuento = 50;
                    break;
                case 3:
                    Console.WriteLine("El color es Azul con descuento del 75%");
                    descuento = 75;
                    break;
                case 4:
                   Console.WriteLine("El color es Rojo con descuento del 100%");
                   descuento = 100;
                    break;
            }

            Console.WriteLine("Ingrese el importe de la cuenta total del cliente:");
            importeCuenta = Convert.ToDouble(Console.ReadLine());
            totalPagar = importeCuenta - (importeCuenta * descuento / 100);
            Console.WriteLine("El total a pagar es: " + totalPagar);

        }
    }
}