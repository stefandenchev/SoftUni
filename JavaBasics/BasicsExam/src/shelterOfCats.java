import java.util.Scanner;

public class shelterOfCats {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int foodBought = 1000 * Integer.parseInt(s.nextLine());
        int totalEaten = 0;

        while (true) {
            String input = s.nextLine();
            if (input.equals("Adopted")) {
                break;
            } else {
                int eaten = Integer.parseInt(input);
                totalEaten += eaten;
            }
        }
        if (foodBought >= totalEaten) {
            System.out.printf("Food is enough! Leftovers: %d grams.", foodBought - totalEaten);
        } else {
            System.out.printf("Food is not enough. You need %d grams more.", totalEaten - foodBought);
        }
    }
}
