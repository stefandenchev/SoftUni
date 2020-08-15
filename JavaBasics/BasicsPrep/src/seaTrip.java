import java.util.Scanner;

public class seaTrip {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        double foodMoney = Double.parseDouble(s.nextLine());
        double souvenirMoney = Double.parseDouble(s.nextLine());
        double hotelMoney = Double.parseDouble(s.nextLine());

        double fuelNeed = 420.0 / 100 * 7;
        double fuelPrice = fuelNeed * 1.85;

        double foodMoneyTotal = foodMoney * 3;
        double souvenirMoneyTotal = souvenirMoney * 3;

        double hotel1 = hotelMoney * 0.9;
        double hotel2 = hotelMoney * 0.85;
        double hotel3 = hotelMoney * 0.8;
        double hotelTotal = hotel1 + hotel2 + hotel3;

        double totalMoney = fuelPrice + foodMoneyTotal + souvenirMoneyTotal + hotelTotal;

        System.out.printf("Money needed: %.2f", totalMoney);


    }
}
