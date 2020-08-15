import java.util.Scanner;

public class sushiTime {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String sushiType = s.nextLine();
        String restaurant = s.nextLine();
        int amount = Integer.parseInt(s.nextLine());
        char forHome = s.nextLine().charAt(0);
        double price = 0;
        boolean invalid = false;

        switch (restaurant) {
            case "Sushi Zone":
                switch (sushiType) {
                    case "sashimi":
                        price = amount * 4.99;
                        break;
                    case "maki":
                        price = amount * 5.29;
                        break;
                    case "uramaki":
                        price = amount * 5.99;
                        break;
                    case "temaki":
                        price = amount * 4.29;
                        break;
                }
                break;
            case "Sushi Time":
                switch (sushiType) {
                    case "sashimi":
                        price = amount * 5.49;
                        break;
                    case "maki":
                        price = amount * 4.69;
                        break;
                    case "uramaki":
                        price = amount * 4.49;
                        break;
                    case "temaki":
                        price = amount * 5.19;
                        break;
                }
                break;
            case "Sushi Bar":
                switch (sushiType) {
                    case "sashimi":
                        price = amount * 5.25;
                        break;
                    case "maki":
                        price = amount * 5.55;
                        break;
                    case "uramaki":
                        price = amount * 6.25;
                        break;
                    case "temaki":
                        price = amount * 4.75;
                        break;
                }
                break;
            case "Asian Pub":
                switch (sushiType) {
                    case "sashimi":
                        price = amount * 4.5;
                        break;
                    case "maki":
                        price = amount * 4.8;
                        break;
                    case "uramaki":
                        price = amount * 5.5;
                        break;
                    case "temaki":
                        price = amount * 5.5;
                        break;
                }
                break;
            default:
                System.out.printf("%s is invalid restaurant!", restaurant);
                invalid = true;
                break;
        }
        if (forHome == 'Y') {
            price *= 1.2;
        }
        if (!invalid) {
            System.out.printf("Total price: %.0f lv.", Math.ceil(price));
        }
    }
}