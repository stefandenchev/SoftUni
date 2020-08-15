import java.util.Scanner;

public class fitnessCard {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        double cashAvailable = Double.parseDouble(s.nextLine());
        char sex = s.nextLine().charAt(0);
        int age = Integer.parseInt(s.nextLine());
        String sport = s.nextLine();
        double price = 0;

        switch (sex) {
            case 'm':
                switch (sport) {
                    case "Gym":
                        price = 42;
                        break;
                    case "Boxing":
                        price = 41;
                        break;
                    case "Yoga":
                        price = 45;
                        break;
                    case "Zumba":
                        price = 34;
                        break;
                    case "Dances":
                        price = 51;
                        break;
                    case "Pilates":
                        price = 39;
                        break;
                }
                break;
            case 'f':
                switch (sport) {
                    case "Gym":
                        price = 35;
                        break;
                    case "Boxing":
                        price = 37;
                        break;
                    case "Yoga":
                        price = 42;
                        break;
                    case "Zumba":
                        price = 31;
                        break;
                    case "Dances":
                        price = 53;
                        break;
                    case "Pilates":
                        price = 37;
                        break;
                }
               break;
        }

        if (age <= 19) {
            price = 0.8 * price;
        }
        if (cashAvailable >= price) {
            System.out.printf("You purchased a 1 month pass for %s.", sport);
        } else {
            System.out.printf("You don't have enough money! You need $%.2f more.", price - cashAvailable);
        }
    }
}
