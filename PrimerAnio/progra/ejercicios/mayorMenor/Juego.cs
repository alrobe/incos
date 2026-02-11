namespace MayorMenor {
    class Juego {
        public Juego() {
        }

        public void Jugar() {
            Console.WriteLine("Ingrese los datos del jugador");
            string nombre = RegistrarNombreJugador();
            int dinero = RegistrarDineroJugador();
            System.Console.WriteLine("Ingrese los datos de la PC");
            int dineroPC = RegistrarDineroJugador();
            while (dinero > 0 && dineroPC > 0) {
                // EL jugador 1 (Nombre) dedide si quiere apostar al mayor(1) o menor(2)
                System.Console.WriteLine("Jugador 1: " + nombre);
                System.Console.WriteLine("Ingrese el numero 1 para apostar al menor o 2 para apostar al mayor");
                int apuestaJugador1 = int.Parse(System.Console.ReadLine());
                // EL jugador 1 (Nombre) decide cuanto dinero quiere apostar
                System.Console.WriteLine("Ingrese el dinero que desea apostar");
                int dineroApostadoJugador1 = int.Parse(System.Console.ReadLine());
                // Lanzar los dados
                int dado1 = new System.Random().Next(1, 6);
                int dado2 = new System.Random().Next(1, 6);
                int sumaDados = dado1 + dado2;
                Console.WriteLine("Dado 1: " + dado1);
                Console.WriteLine("Dado 2: " + dado2);
                Console.WriteLine("Suma de los dados: " + sumaDados);

                
                switch (apuestaJugador1) {
                    case 1:
                        if (sumaDados < 7) {
                            dinero += dineroApostadoJugador1;
                            dineroPC -= dineroApostadoJugador1;
                        } else {
                            dinero -= dineroApostadoJugador1;
                            dineroPC += dineroApostadoJugador1;
                        }
                        break;
                    case 2:
                        if (sumaDados > 7) {
                            dinero += dineroApostadoJugador1;
                            dineroPC -= dineroApostadoJugador1;
                        } else {
                            dinero -= dineroApostadoJugador1;
                            dineroPC += dineroApostadoJugador1;
                        }
                        break;
                    default:
                        System.Console.WriteLine("Opcion no valida");
                        break;
                }

                MostrarInfo(nombre, dinero);
                MostrarInfo("PC", dineroPC);
            }
        }

        public string RegistrarNombreJugador() {
            System.Console.WriteLine("Ingrese el nombre");
            string nombreJugador1 = System.Console.ReadLine();
            return nombreJugador1;
        }

        public int RegistrarDineroJugador() {
            System.Console.WriteLine("Ingrese el dinero disponible");
            int dineroJugador1 = int.Parse(System.Console.ReadLine());
            return dineroJugador1;
        }

        public void MostrarInfo(string nombre, int dinero) {
            System.Console.WriteLine("Nombre: " + nombre);
            System.Console.WriteLine("Dinero: " + dinero);
            System.Console.WriteLine("-------------------------------");
        }
    }            
}