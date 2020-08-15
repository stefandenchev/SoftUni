import java.util.Scanner;

public class sumPrimeNonPrime {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int primeSum = 0;
        int nonPrimeSum = 0;

        while (true) {
            String input = s.nextLine();
            if (input.equals("stop")) {
                break;
            }

            int number = Integer.parseInt(input);
            if (number < 0) {
                System.out.println("Number is negative.");
            } else {
                boolean isPrime = true;
                for (int i = 2; i < Math.sqrt(number); i++) {             // sqrt helps with optimization
                    if (number % i == 0) {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) {
                    primeSum += number;
                } else {
                    nonPrimeSum += number;
                }
            }
        }

        System.out.printf("Sum of all prime numbers is: %d%n", primeSum);
        System.out.printf("Sum of all non prime numbers is: %d", nonPrimeSum);


    }
}
