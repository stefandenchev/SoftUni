import java.util.Scanner;

public class leftAndRightSum {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int sum1 = 0;
        int sum2 = 0;
        int n = Integer.parseInt(s.nextLine());

        for (int i = 0; i < n; i++) {
            int currN = Integer.parseInt(s.nextLine());
            sum1 = sum1 + currN;
        }
        for (int i = 0; i < n; i++) {
            int currN = Integer.parseInt(s.nextLine());
            sum2 = sum2 + currN;
        }
        if (sum1 == sum2) {
            System.out.printf("Yes, sum = %d", sum1);
        } else {
            System.out.printf("No, diff = %d", Math.abs(sum1 - sum2));
        }
    }
}