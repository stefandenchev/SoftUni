import java.util.Scanner;

public class equalSumsEvenOddPosition {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int start = Integer.parseInt(s.nextLine());
        int end = Integer.parseInt(s.nextLine());

        for (int i = start; i <= end; i++) {
            int evenDigitSum = 0;
            int oddDigitSum = 0;

            boolean isEvenPosition = true;
            int currentNumber = i;

            while (currentNumber > 0) {
                int lastDigit = currentNumber % 10;

                if (isEvenPosition) {
                    evenDigitSum += lastDigit;

                    isEvenPosition = false;
                } else {
                    oddDigitSum += lastDigit;
                    isEvenPosition = true;
                }
                currentNumber /= 10;
            }
            if (evenDigitSum == oddDigitSum) {
                System.out.print(i + " ");
            }

        }
    }
}
