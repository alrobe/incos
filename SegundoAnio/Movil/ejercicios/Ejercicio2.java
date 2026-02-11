public class Ejercicio2 {
    public static void main(String[] args) {
        // int dado1 = 6;
        // int dado2 = 6;
        // int dado3 = 6;

        // int cant6 = 0;

        // if (dado1 == 6) {
        //     cant6++;
        // }
        // if (dado2 == 6) {
        //     cant6++;
        // }
        // if (dado3 == 6) {
        //     cant6++;
        // }

        // if (cant6 == 3) {
        //     System.out.println("Excelente");
        // } else if (cant6 == 2){
        //     System.out.println("Muy bien");
        // } else if (cant6 == 2){
        //     System.out.println("Regular");
        // } else {
        //     System.out.println("Mal");
        // }

        int fila = 4;
        int columna = 4;
        for (int i = 1; i<=fila; i++){
            for (int j = 1; j<=columna;j++){
                System.out.print(i*j);
                if (! (j==columna)){
                    System.out.print("-");
                }
                // System.out.print("-");

            }
            System.out.println("");
        }
    }
}