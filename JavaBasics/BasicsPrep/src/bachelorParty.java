import java.util.Scanner;

public class bachelorParty {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int sumNeeded = Integer.parseInt(s.nextLine());
        int totalGuests = 0;
        int moneyCollected = 0;

        while (true) {
            String input = s.nextLine();
            if (input.equals("The restaurant is full")) {
                break;
            } else {
                int guestsInGroup = Integer.parseInt(input);
                totalGuests += guestsInGroup;
                if (guestsInGroup < 5) {
                    moneyCollected += guestsInGroup * 100;
                } else if (guestsInGroup >= 5) {
                    moneyCollected += guestsInGroup * 70;
                }
            }
        }
        int moneyDifference = Math.abs(sumNeeded - moneyCollected);
        if (moneyCollected >= sumNeeded) {
            System.out.printf("You have %d guests and %d leva left.", totalGuests, moneyDifference);
        } else {
            System.out.printf("You have %d guests and %d leva income, but no singer.", totalGuests, moneyCollected);
        }
    }
}