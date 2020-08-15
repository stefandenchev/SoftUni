import java.util.Scanner;

public class numberSequence {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int n = Integer.parseInt(s.nextLine());
        int max = Integer.MIN_VALUE;
        int min = Integer.MAX_VALUE;

        for (int i = 0; i < n; i++) {
            int currN = Integer.parseInt(s.nextLine());
            if (currN > max) {
                max = currN;
            }
            if (currN < min) {
                min = currN;
            }
        }
        System.out.printf("Max number: %d%n", max);
        System.out.printf("Min number: %d", min);


    }
}
