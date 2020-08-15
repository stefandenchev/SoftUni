import java.util.Scanner;

public class travelling {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String destination = s.nextLine();

        while (!destination.equals("End")) {
            double budget = Double.parseDouble(s.nextLine());
            while (budget > 0) {
                double deposit = Double.parseDouble(s.nextLine());
                budget -= deposit;
            }
            System.out.printf("Going to %s!%n", destination);
            destination = s.nextLine();
        }

    }
}
