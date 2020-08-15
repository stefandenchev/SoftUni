import java.util.Scanner;

public class dishwasher {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int bottles = Integer.parseInt(s.nextLine());
        int detergent = bottles * 750;
        int detergentNeeded = 0;
        String command = s.nextLine();
        int counter = 1;
        int dishesWashed = 0;
        int potsWashed = 0;

        while (!command.equals("End")) {
            int washed = Integer.parseInt(command);
            if (counter % 3 == 0) {
                detergentNeeded = washed * 15;
                potsWashed += washed;
            } else {
                detergentNeeded = washed * 5;
                dishesWashed += washed;
            }
            detergent -= detergentNeeded;
            if (detergent < 0) {
                System.out.printf("Not enough detergent, %d ml. more necessary!", Math.abs(detergent));
                break;
            }

            counter++;
            command = s.nextLine();
        }
        if (command.equals("End")) {
            System.out.printf("Detergent was enough!%n");
            System.out.printf("%d dishes and %d pots were washed.%n", dishesWashed, potsWashed);
            System.out.printf("Leftover detergent %d ml.", detergent);
        }
    }
}
