import java.util.Scanner;

public class SkiTrip {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int days = Integer.parseInt(s.nextLine());
        String room = s.nextLine();
        int nights = days - 1;
        double price = 0;
        String mark = s.nextLine();

        switch (room) {
            case "room for one person":
                price = nights * 18;
                break;
            case "apartment":
                price = nights * 25;
                if (nights < 10) {
                    price = price * 0.7;
                } else if (nights >= 10 && nights <= 15) {
                    price = price * 0.65;
                } else if (nights > 15){
                    price = price * 0.5;
                }
                break;
            case "president apartment":
                price = nights * 35;
                if (nights < 10) {
                    price = price * 0.9;
                } else if (nights >= 10 && nights <= 15) {
                    price = price * 0.85;
                } else if (nights > 15){
                    price = price * 0.8;
                }
                break;
        }
        if (mark.equalsIgnoreCase("positive")){
            price = price + 0.25 * price;
        } else {
            price = price * 0.9;
        }

        System.out.printf("%.2f", price);

    }
}
