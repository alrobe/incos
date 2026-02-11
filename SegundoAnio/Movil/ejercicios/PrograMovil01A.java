public class PrograMovil01A {
    public static void main(String[] args) {
        int dado1 = 6;
        int dado2 = 6;
        int dado3 = 6;

        int cant6 = 0;

        if (dado1 == 6) {
            cant6++;
        }
        if (dado2 == 6) {
            cant6++;
        }
        if (dado3 == 6) {
            cant6++;
        }

        if (cant6 == 3) {
            System.out.println("Excelente");
        } else if (cant6 == 2){
            System.out.println("Muy bien");
        } else if (cant6 == 2){
            System.out.println("Regular");
        } else {
            System.out.println("Mal");
        }
    }
}