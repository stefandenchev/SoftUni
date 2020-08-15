import java.util.Scanner;

public class cruiseShip {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String cruiseType = s.nextLine();
        String roomType = s.nextLine();
        int nights = Integer.parseInt(s.nextLine());
        double price = 0;

        switch (cruiseType) {
            case "Mediterranean":
                switch (roomType) {
                    case "standard cabin":
                        price = nights * 27.5;
                        break;
                    case "cabin with balcony":
                        price = nights * 30.2;
                        break;
                    case "apartment":
                        price = nights * 40.5;
                        break;
                }
                break;
            case "Adriatic":
                switch (roomType) {
                    case "standard cabin":
                        price = nights * 22.99;
                        break;
                    case "cabin with balcony":
                        price = nights * 25.0;
                        break;
                    case "apartment":
                        price = nights * 34.99;
                        break;
                }
                break;
            case "Aegean":
                switch (roomType) {
                    case "standard cabin":
                        price = nights * 23.0;
                        break;
                    case "cabin with balcony":
                        price = nights * 26.6;
                        break;
                    case "apartment":
                        price = nights * 39.8;
                        break;
                }
                break;

        }
        price = price * 4;
        if (nights > 7) {
            price = price * .75;
        }
        System.out.printf("Annie's holiday in the %s sea costs %.2f lv.", cruiseType, price);
    }
}