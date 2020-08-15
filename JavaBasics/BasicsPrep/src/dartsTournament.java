import java.util.Scanner;

public class dartsTournament {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int beginPoints = Integer.parseInt(s.nextLine());
        int points = 0;
        int totalPoints = 0;
        int moves = 0;
        boolean hitBullseye = false;

        while(beginPoints > 0){
            if (hitBullseye){
                System.out.printf("Congratulations! You won the game with a bullseye in %d moves!", moves);
                break;
            }
            String area = s.nextLine();
            if (area.equals("bullseye")){
                hitBullseye = true;
                moves++;
                continue;
            }

            points = Integer.parseInt(s.nextLine());
            moves++;
            if (area.equals("double ring")){
                points *= 2;
                totalPoints += points;
            }
            if (area.equals("triple ring")){
                points *= 3;
                totalPoints += points;
            }
            if (area.equals("number section")){
                points *= 1;
                totalPoints += points;
            }
            if (beginPoints == totalPoints){
                System.out.printf("Congratulations! You won the game in %d moves!", moves);
                break;
            }
            if (beginPoints < totalPoints){
                System.out.printf("Sorry, you lost. Score difference: %d.", Math.abs(totalPoints - beginPoints));
                break;
            }
        }
    }
}
