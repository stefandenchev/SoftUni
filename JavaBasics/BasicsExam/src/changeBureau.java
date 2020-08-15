import java.util.Scanner;

public class changeBureau {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int bitCoin = Integer.parseInt(s.nextLine());
        double yuan = Double.parseDouble(s.nextLine());
        double commission = Double.parseDouble(s.nextLine());

        double euroBitCoin = 1.0 * bitCoin * 1168 / 1.95;
        double euroYuan = yuan * 0.15 * 1.76 / 1.95;

        double total = (euroBitCoin + euroYuan) * (1 - commission / 100);

        System.out.printf("%.2f", total);
    }
}
