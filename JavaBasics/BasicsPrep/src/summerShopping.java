import java.util.Scanner;

public class summerShopping {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int budget = Integer.parseInt(s.nextLine());
        double towel = Double.parseDouble(s.nextLine());
        int discount = Integer.parseInt(s.nextLine());

        double umbrella = towel * 2 / 3;
        double flipFlops = umbrella * 0.75;
        double bag = (flipFlops + towel) / 3;

        double totalPrice = towel + umbrella + flipFlops + bag;
        double discountPercent = discount * 1.0 / 100;
        double finalPrice = totalPrice - totalPrice * discountPercent;

        double diff = Math.abs(finalPrice - budget);

        if (finalPrice > budget) {
            System.out.printf("Annie's sum is %.2f lv. She needs %.2f lv. more.", finalPrice, diff);
        } else {
            System.out.printf("Annie's sum is %.2f lv. She has %.2f lv. left.", finalPrice, diff);
        }
    }
}
