import java.util.Scanner;

public class divideWithoutRemainder {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int n = Integer.parseInt(s.nextLine());
        int divByTwo = 0;
        int divByThree = 0;
        int divByFour = 0;

        for (int i = 0; i < n; i++) {
            int num = Integer.parseInt(s.nextLine());
            if (num % 2 == 0) {
                divByTwo++;
            }
            if (num % 3 == 0) {
                divByThree++;
            }
            if (num % 4 == 0) {
                divByFour++;
            }
        }

        double two = 1.0 * divByTwo / n * 100;
        double three = 1.0 * divByThree /n * 100;
        double four = 1.0 * divByFour / n * 100;

        System.out.printf("%.2f%%%n", two);
        System.out.printf("%.2f%%%n", three);
        System.out.printf("%.2f%%", four);
    }
}
