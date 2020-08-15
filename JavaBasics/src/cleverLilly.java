import java.util.Scanner;

public class cleverLilly {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int years = Integer.parseInt(s.nextLine());
        double price = Double.parseDouble(s.nextLine());
        int toyPrice = Integer.parseInt(s.nextLine());
        int toy = 0;
        int budget = 0;

        for (int i = 1; i <= years; i++) {
            if (i % 2 == 1){
                toy++;
            } else {
                budget = budget + (10*(i/2));
                budget = budget - 1;
            }
        }
        int toyTotal = toy * toyPrice;
        budget = budget + toyTotal;
        if (budget >= price) {
            double rem = budget - price;
            System.out.printf("Yes! %.2f", rem);
        } else {
            double rem = price - budget;
            System.out.printf("No! %.2f", rem);
        }
    }
}
