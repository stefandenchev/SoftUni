import java.util.Scanner;

public class savings {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        double income = Double.parseDouble(s.nextLine());
        int months = Integer.parseInt(s.nextLine());
        double need = Double.parseDouble(s.nextLine());

        double otherSavings = 0.3 * income;
        double incomeSavedPerMonth = income - (need + otherSavings);
        double percentSavedMoney = incomeSavedPerMonth / income * 100;
        double saved = months * incomeSavedPerMonth;


        System.out.printf("She can save %.2f%%%n", percentSavedMoney);
        System.out.printf("%.2f", saved);
    }
}
