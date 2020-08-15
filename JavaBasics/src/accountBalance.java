import java.util.Scanner;

public class accountBalance {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int amount = Integer.parseInt(s.nextLine());
        int currDeposit = 1;
        double sum = 0;

        while (currDeposit <= amount) {
            double income = Double.parseDouble(s.nextLine());
            if (income < 0) {
                System.out.println("Invalid operation!");
                break;
            }
            System.out.printf("Increase: %.2f%n", income);
            sum += income;
            currDeposit++;
        }
        System.out.printf("Total: %.2f", sum);
    }
}
