import java.util.Scanner;

public class catWalking {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int minutesDaily = Integer.parseInt(s.nextLine());
        int walksDaily = Integer.parseInt(s.nextLine());
        int caloriesDaily = Integer.parseInt(s.nextLine());

        int caloriesBurned = minutesDaily * walksDaily * 5;

        if (caloriesBurned >= caloriesDaily * 0.5) {
            System.out.printf("Yes, the walk for your cat is enough. Burned calories per day: %d.", caloriesBurned);
        } else {
            System.out.printf("No, the walk for your cat is not enough. Burned calories per day: %d.", caloriesBurned);
        }

    }
}
