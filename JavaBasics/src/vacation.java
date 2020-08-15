import java.util.Scanner;

public class vacation {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        double needMoney = Double.parseDouble(s.nextLine());
        double money = Double.parseDouble(s.nextLine());
        int days = 0;
        int countSpend = 0;

        while (money < needMoney) {
            days++;
            String action = s.nextLine();
            double price = Double.parseDouble(s.nextLine());

            if (action.equals("save")) {
                money += price;
                countSpend = 0;
            } else if (action.equals("spend")) {
                money -= price;
                if (money < 0) {
                    money = 0;
                }
                countSpend++;
            }
            if (countSpend == 5) {
                System.out.println("You can't save the money.");
                System.out.print(days);
                break;
            }
            if (money >= needMoney) {
                System.out.printf("You saved the money for %d days.", days);
            }
        }
    }
}
