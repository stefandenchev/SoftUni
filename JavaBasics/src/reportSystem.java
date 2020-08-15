import java.util.Scanner;

public class reportSystem {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int moneyNeeded = Integer.parseInt(s.nextLine());
        double sum = 0;

        double cash = 0;
        double card = 0;

        int counter = 1;
        int cashCount = 0;
        int cardCount = 0;


        while (moneyNeeded > sum) {

            String command = s.nextLine();

            if (command.equals("End")) {
                System.out.println("Failed to collect required money for charity.");
                break;
            }

            int transaction = Integer.parseInt(command);

            if (counter % 2 == 1) {
                if (transaction > 100) {
                    System.out.println("Error in transaction!");
                } else {
                    sum += transaction;
                    System.out.println("Product sold!");
                    cash += transaction;
                    cashCount++;
                }
            }
            if (counter % 2 == 0) {
                if (transaction < 10) {
                    System.out.println("Error in transaction!");
                } else {
                    sum += transaction;
                    System.out.println("Product sold!");
                    card += transaction;
                    cardCount++;
                }
            }
            if (moneyNeeded <= sum) {
                System.out.printf("Average CS: %.2f%n", cash / cashCount);
                System.out.printf("Average CC: %.2f", card / cardCount);
                break;
            }
            counter++;

        }
    }
}

