import java.util.Scanner;

public class specialNumber {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int n = Integer.parseInt(s.nextLine());

        for (int i = 1111; i <= 9999; i++) {
            int number = i;
            boolean isSpecial = true;
            while (number > 0) {
                int lastDigit = number % 10;

                if (lastDigit == 0 || n % lastDigit != 0) {
                    isSpecial = false;
                    break;
                }
                number /= 10;
            }
            if (isSpecial) {
                System.out.printf("%d ", i);
            }
        }

    }
}
