namespace MayorMenor {
    class Program {
        static int color = 0;

        static int columnaIncio = 5;
        static int columnaFin = 98;
        static int filaInicio = 32;
        static int filaFin = 39;
        static int columnaMedio = 51;

        static void Main(string[] args) {
            bool flag = true;
            while (flag) {
                ImprimirArtPantallaBienvenida();
                Jugar();
                Console.Clear();
                Console.WriteLine("Desea jugar de nuevo? (S/N)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToUpper() != "S") {
                    flag = false;
                }
            }
        }        

        static void Jugar() {
            // Print Helo World
            Console.Clear();
            imprimirArtMesa();
            
            ImprimirDado1(1);
            ImprimirDado2(6);

            ImprimirAlMedio("Ingrese los datos de jugador", 4);
            ImprimirInicio("Nombre:", 5);
            string nombre = Console.ReadLine();

            ImprimirInicio("Dinero: ", 6);
            int dinero = int.Parse(Console.ReadLine());

            BorrarAreaOpciones();
            ImprimirInformacionJugador(nombre, dinero);

            ImprimirAlMedio("Ingrese los datos de la PC", 4);
            ImprimirInicio("Dinero: ", 5);
            int dineroPC = int.Parse(Console.ReadLine());

            BorrarAreaOpciones();
            ImprimirInformacionJugador(nombre, dinero);
            ImprimirInformacionPC(dineroPC);

            while (dinero > 0 && dineroPC > 0) {
                // EL jugador 1 (Nombre) dedide si quiere apostar al mayor(1) o menor(2)
                BorrarAreaApuesta();

                int apuestaJugador1 = OptenerOpcionApuesta();
                ImprimirOpcionSeleccionada(apuestaJugador1);

                int dineroApostadoJugador1 = OptenerDineroAApostar(dinero);
                ImprimirDineroApostado(dineroApostadoJugador1);
                
                int sumaDados = LanzarDados();
                bool ganador = false;

                switch (apuestaJugador1) {
                    case 1:
                        if (sumaDados < 7) {
                            ganador = true;
                            dinero += dineroApostadoJugador1;
                            dineroPC -= dineroApostadoJugador1;
                        } else {
                            dinero -= dineroApostadoJugador1;
                            dineroPC += dineroApostadoJugador1;
                        }
                        break;
                    case 2:
                        if (sumaDados > 7) {
                            ganador = true;
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

                RefrescarInformacionJugadores(nombre, dinero, dineroPC);
                ImprimirResultado(ganador, sumaDados);
            }
        }    
        static void ImprimirInformacionJugador(string nombre, int dinero) {
            ImprimirInicio(nombre + ": " + dinero);
        }

        static void ImprimirInformacionPC(int dinero) {
            ImprimirFin("PC: " + dinero);
        }

        static void ImprimirEn(string mensaje, int columna, int fila) {
            Console.SetCursorPosition(columna, fila);
            Console.Write(mensaje);
        }

        static void ImprimirInicio(string mensaje, int fila=0) {
            ImprimirEn(mensaje, columnaIncio, filaInicio+fila);
        }

        static void ImprimirAlMedio(string mensaje, int fila=0) {
            int columnaMensajeInicio = columnaMedio - (mensaje.Length/2);
            ImprimirEn(mensaje, columnaMensajeInicio, filaInicio+fila);
        }

        static void ImprimirFin(string mensaje, int fila=0) {
            int columnaMensajeInicio = columnaFin - mensaje.Length;
            ImprimirEn(mensaje, columnaMensajeInicio, filaInicio+fila);
        }

        static void ImprimirArtPantallaBienvenida() {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            int alto = Console.WindowHeight;
            int ancho = Console.WindowWidth;
            bool flag = true;

            imprimirMensajeBienvenida();
            while (flag) {
                for (int i = 0; i < ancho; i++) {
                    imprimirCaracter(i, 0);
                    if (Console.KeyAvailable) {
                        flag = false;
                        break;
                    }
                }

                for (int i = 0; i < alto; i++) {
                    imprimirCaracter(ancho - 1, i);
                    if (Console.KeyAvailable) {
                        flag = false;
                        break;
                    }
                }

                for (int i = ancho - 1; i >= 0; i--) {
                    imprimirCaracter(i, alto - 1);
                    if (Console.KeyAvailable) {
                        flag = false;
                        break;
                    }
                }

                for (int i = alto - 1; i >= 0; i--) {
                    imprimirCaracter(0, i);
                    if (Console.KeyAvailable) {
                        flag = false;
                        break;
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void imprimirMensajeBienvenida() {
            string mensaje = "Bienvenido al juego de Mayor y Menor";
            int row = Console.WindowHeight / 2;
            int col = (Console.WindowWidth - mensaje.Length) / 2;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(mensaje);

            mensaje = "Presione cualquier tecla para empezar";
            row = (Console.WindowHeight / 2 ) + 1;
            col = (Console.WindowWidth - mensaje.Length) / 2;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(mensaje);

            mensaje = "By: Robles Alfredo, Luna Bladimir, Zuleta carlos";
            row = (Console.WindowHeight / 2 ) + 5;
            col = (Console.WindowWidth - mensaje.Length) / 2;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(mensaje);
        }

        static void imprimirCaracter(int row, int col) {
            switch (color) {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    color = 1;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    color = 2;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    color = 0;
                    break;
            }
            Console.SetCursorPosition(row, col);
            Console.Write("$");
            Thread.Sleep(10);
        }

        

        static void ImprimirDado1(int numeroDado) {
            int fila = 9;
            int columna = 60;
            ImprimirDado(numeroDado, columna, fila);

        }

        static void ImprimirDado2(int numeroDado) {
            int fila = 15;
            int columna = 75;
            ImprimirDado(numeroDado, columna, fila);
        }

        static int LanzarDados() {
            int cantidadRotaciones = 10;
            Random random = new Random();

            int dado1 = random.Next(1, 6);
            ImprimirDado1(dado1);
            int dado2 = random.Next(1, 6);
            ImprimirDado2(dado2);

            

            for (int i=0; i<cantidadRotaciones; i++) {
                dado1 = random.Next(1, 6);
                ImprimirDado1(dado1);
                dado2 = random.Next(1, 6);
                ImprimirDado2(dado2);
                Thread.Sleep(100);
            }

            int sumaDados = dado1 + dado2;
            return sumaDados;
        }


        static int OptenerOpcionApuesta() {
            int fila = 4;
            string mensaje = "Seleccione una opcion";
            while (true) {
                BorrarAreaOpciones();
                ImprimirAlMedio(mensaje, fila);
                ImprimirAlMedio("Menor(1) o Mayor(2)", fila + 1);
                Console.SetCursorPosition(columnaMedio, filaInicio + 6);
                int opcionApuesta = int.Parse(Console.ReadLine());
                if (opcionApuesta == 1 || opcionApuesta == 2) {
                    return opcionApuesta;
                }
                mensaje = "Seleccione una opcion valida";
            }
            
        }

        static int OptenerDineroAApostar(int limiteDinero) {
            int fila = 4;
            string mensaje = "Cuanto desea apostar";
            while (true) {
                BorrarAreaOpciones();
                ImprimirAlMedio(mensaje, fila);
                Console.SetCursorPosition(columnaMedio, filaInicio + 6);
                int dineroApostar = int.Parse(Console.ReadLine());
                if (dineroApostar > 0 && dineroApostar <= limiteDinero) {
                    return dineroApostar;
                }
                mensaje = "Ingrese un monto mayor a 0 o menor a su dinero";
            }
        }

        static void ImprimirOpcionSeleccionada(int opcion) {
            switch (opcion) {
                case 1:
                    ImprimirInicio("Opcion: Menor", 1);
                    break;
                case 2:
                    ImprimirInicio("Opcion: Mayor", 1);
                    break;
                default:
                    ImprimirInicio("Opcion:", 1);
                    break;
            }
        }

        static void ImprimirDineroApostado(int dinero) {
            ImprimirInicio("Apuesta: " + dinero, 2);
        }

        static void ImprimirResultado(bool ganador, int sumaDados) {
            BorrarAreaOpciones();
            ImprimirAlMedio("Resultado: " + sumaDados, 4);
            if (ganador) {
                ImprimirAlMedio("GANASTE!!!!!!", 5);
            } else {
                ImprimirAlMedio("PERDISTE!!!!!", 5);
            }
            
            ImprimirAlMedio("Preciona Cualquier tecla para continuar", 6);
            while (true) {
                if (Console.KeyAvailable) {
                    break;
                }
            }
            Console.ReadLine();
        }

        static void BorrarAreaInfoJugador() {
            int espaciosBorrar = columnaFin - columnaIncio;
            Console.SetCursorPosition(columnaIncio, filaInicio);
            Console.Write(new string(' ', espaciosBorrar));
        }

        static void BorrarAreaApuesta() {
            int espaciosBorrar = columnaFin - columnaIncio;
            Console.SetCursorPosition(columnaIncio, filaInicio + 1);
            Console.Write(new string(' ', espaciosBorrar));
            Console.SetCursorPosition(columnaIncio, filaInicio + 2);
            Console.Write(new string(' ', espaciosBorrar));
        }

        static void BorrarAreaOpciones() {
            int espaciosBorrar = columnaFin - columnaIncio;
            for (int i=filaInicio+4; i<filaFin; i++) {
                Console.SetCursorPosition(columnaIncio, i);
                Console.Write(new string(' ', espaciosBorrar));
            }
        }

        static void RefrescarInformacionJugadores(string nombreJugador, int dineroJugador, int dineroPC) {
            BorrarAreaInfoJugador();
            ImprimirInformacionJugador(nombreJugador, dineroJugador);
            ImprimirInformacionPC(dineroPC);
        }

        static void imprimirArtMesa() {
            Console.WriteLine("                                                            ===================================================================================================");
            Console.WriteLine("                                                          .'.' 222222                                  777777                                888888        .'.'");
            Console.WriteLine("                                                        .'.'      2                                      77                                88  88        .'.'||");
            Console.WriteLine("                                                      .'.' 222222                                      77                                888888        .'.'  ||");
            Console.WriteLine("                                                    .'.' 2                                           77                                88  88        .'.'    ||");
            Console.WriteLine("                                                  .'.' 222222                                      77                                888888        .'.'      ||");
            Console.WriteLine("                                                .'.'                                                                                             .'.'        ||");
            Console.WriteLine("                                              .'.' 333333                                                                        999999        .'.'          ||");
            Console.WriteLine("                                            .'.'     33                                                                        99  99        .'.'            ||");
            Console.WriteLine("                                          .'.' 333333                                                                        999999        .'.'              ||");
            Console.WriteLine("                                        .'.'     33                                                                            99        .'.'                ||");
            Console.WriteLine("                                      .'.' 333333                                                                        999999        .'.'                 |__|");
            Console.WriteLine("                                    .'.'                                                                                             .'.");
            Console.WriteLine("                                  .'.' 44  44                                                                      1111   000000   .'.'");
            Console.WriteLine("                                .'.' 44  44                                                                        11   00  00   .'.'");
            Console.WriteLine("                              .'.' 444444                                                                        11   00  00   .'.'");
            Console.WriteLine("                            .'.'     44                                                                        11   00  00   .'.'");
            Console.WriteLine("                          .'.'     44                                                                      111111 000000   .'.'");
            Console.WriteLine("                        .'.'                                                                                             .'.");
            Console.WriteLine("                      .'.' 555555                                                                      1111   1111     .'.'");
            Console.WriteLine("                    .'.' 55                                                                            11     11     .'.'");
            Console.WriteLine("                  .'.' 555555                                                                        11     11     .'.'");
            Console.WriteLine("                .'.'     55                                                                        11     11     .'.'");
            Console.WriteLine("              .'.' 555555                                                                      111111 111111   .'.'");
            Console.WriteLine("            .'.'                                                                                             .'.");
            Console.WriteLine("          .'.' 666666                                                                      1111   222222   .'.'");
            Console.WriteLine("        .'.' 66                                                                            11        2   .'.'");
            Console.WriteLine("      .'.' 666666                                                                        11   222222   .'.'");
            Console.WriteLine("    .'.' 66  66                                                                        11   2        .'.'");
            Console.WriteLine("  .'.' 666666                                                                      111111 222222   .'.'");
            Console.WriteLine("  ===================================================================================================");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine("  ||                                                                                               ||");
            Console.WriteLine(" |__|                                                                                             |__|");

        }

        static void ImprimirDado(int numeroDado, int columna, int fila) {
            switch (numeroDado) {
                case 1:
                    Console.SetCursorPosition(columna, fila);
                    Console.WriteLine("   .+-------+");
                    Console.SetCursorPosition(columna, fila + 1);
                    Console.WriteLine(" .'       .'|");
                    Console.SetCursorPosition(columna, fila + 2);
                    Console.WriteLine("+-------+'  |");
                    Console.SetCursorPosition(columna, fila + 3);
                    Console.WriteLine("|       |   |");
                    Console.SetCursorPosition(columna, fila + 4);
                    Console.WriteLine("|   o   |   +");
                    Console.SetCursorPosition(columna, fila + 5);
                    Console.WriteLine("|       | .'");
                    Console.SetCursorPosition(columna, fila + 6);
                    Console.WriteLine("+-------+");
                    break;
                case 2:
                    Console.SetCursorPosition(columna, fila);
                    Console.WriteLine("   .+-------+");
                    Console.SetCursorPosition(columna, fila + 1);
                    Console.WriteLine(" .'       .'|");
                    Console.SetCursorPosition(columna, fila + 2);
                    Console.WriteLine("+-------+'  |");
                    Console.SetCursorPosition(columna, fila + 3);
                    Console.WriteLine("| o     |   |");
                    Console.SetCursorPosition(columna, fila + 4);
                    Console.WriteLine("|       |   +");
                    Console.SetCursorPosition(columna, fila + 5);
                    Console.WriteLine("|     o | .'");
                    Console.SetCursorPosition(columna, fila + 6);
                    Console.WriteLine("+-------+");
                    break;
                case 3:
                    Console.SetCursorPosition(columna, fila);
                    Console.WriteLine("   .+-------+");
                    Console.SetCursorPosition(columna, fila + 1);
                    Console.WriteLine(" .'       .'|");
                    Console.SetCursorPosition(columna, fila + 2);
                    Console.WriteLine("+-------+'  |");
                    Console.SetCursorPosition(columna, fila + 3);
                    Console.WriteLine("| o     |   |");
                    Console.SetCursorPosition(columna, fila + 4);
                    Console.WriteLine("|   o   |   +");
                    Console.SetCursorPosition(columna, fila + 5);
                    Console.WriteLine("|     o | .'");
                    Console.SetCursorPosition(columna, fila + 6);
                    Console.WriteLine("+-------+");
                    break;
                case 4:
                    Console.SetCursorPosition(columna, fila);
                    Console.WriteLine("   .+-------+");
                    Console.SetCursorPosition(columna, fila + 1);
                    Console.WriteLine(" .'       .'|");
                    Console.SetCursorPosition(columna, fila + 2);
                    Console.WriteLine("+-------+'  |");
                    Console.SetCursorPosition(columna, fila + 3);
                    Console.WriteLine("| o   o |   |");
                    Console.SetCursorPosition(columna, fila + 4);
                    Console.WriteLine("|       |   +");
                    Console.SetCursorPosition(columna, fila + 5);
                    Console.WriteLine("| o   o | .'");
                    Console.SetCursorPosition(columna, fila + 6);
                    Console.WriteLine("+-------+");
                    break;
                case 5:
                    Console.SetCursorPosition(columna, fila);
                    Console.WriteLine("   .+-------+");
                    Console.SetCursorPosition(columna, fila + 1);
                    Console.WriteLine(" .'       .'|");
                    Console.SetCursorPosition(columna, fila + 2);
                    Console.WriteLine("+-------+'  |");
                    Console.SetCursorPosition(columna, fila + 3);
                    Console.WriteLine("| o   o |   |");
                    Console.SetCursorPosition(columna, fila + 4);
                    Console.WriteLine("|   o   |   +");
                    Console.SetCursorPosition(columna, fila + 5);
                    Console.WriteLine("| o   o | .'");
                    Console.SetCursorPosition(columna, fila + 6);
                    Console.WriteLine("+-------+");
                    break;
                case 6:
                    Console.SetCursorPosition(columna, fila);
                    Console.WriteLine("   .+-------+");
                    Console.SetCursorPosition(columna, fila + 1);
                    Console.WriteLine(" .'       .'|");
                    Console.SetCursorPosition(columna, fila + 2);
                    Console.WriteLine("+-------+'  |");
                    Console.SetCursorPosition(columna, fila + 3);
                    Console.WriteLine("| o   o |   |");
                    Console.SetCursorPosition(columna, fila + 4);
                    Console.WriteLine("| o   o |   +");
                    Console.SetCursorPosition(columna, fila + 5);
                    Console.WriteLine("| o   o | .'");
                    Console.SetCursorPosition(columna, fila + 6);
                    Console.WriteLine("+-------+");
                    break;
            }
        }
    }
}
