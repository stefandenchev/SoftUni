import java.util.Scanner;
import java.util.function.DoubleFunction;

public class cruiseGames {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String name = s.nextLine();
        int gamesPlayed = Integer.parseInt(s.nextLine());

        int volleyCount = 0;
        int tennisCount = 0;
        int badCount = 0;

        double volleyPoints = 0;
        double tennisPoints = 0;
        double badPoints = 0;

        for (int i = 0; i < gamesPlayed; i++) {
            String game = s.nextLine();
            double points = Double.parseDouble(s.nextLine());
            switch (game) {
                case "volleyball":
                    volleyCount++;
                    points = points * 1.07;
                    volleyPoints += points;
                    break;
                case "tennis":
                    tennisCount++;
                    points = points * 1.05;
                    tennisPoints += points;
                    break;
                case "badminton":
                    badCount++;
                    points = points * 1.02;
                    badPoints += points;
                    break;
            }
        }
        double totalPoints = Math.floor(volleyPoints + tennisPoints + badPoints);
        double volleyAvg = Math.floor(volleyPoints / volleyCount);
        double tennisAvg = Math.floor(tennisPoints / tennisCount);
        double badAvg = Math.floor(badPoints / badCount);

        if (volleyAvg >= 75 && tennisAvg >= 75 && badAvg >= 75) {
            System.out.printf("Congratulations, %s! You won the cruise games with %.0f points.", name, totalPoints);
        } else {
            System.out.printf("Sorry, %s, you lost. Your points are only %.0f.", name, totalPoints);
        }

    }
}
