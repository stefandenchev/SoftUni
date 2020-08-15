import java.util.Scanner;

public class spaceship {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        double width = Double.parseDouble(s.nextLine());
        double length = Double.parseDouble(s.nextLine());
        double height = Double.parseDouble(s.nextLine());
        double averageAstroHeight = Double.parseDouble(s.nextLine());

        double area = width * length * height;
        double roomSize = (averageAstroHeight + 0.4) * 2 * 2;
        double available = Math.floor(area / roomSize);

        if (available >= 3 && available <= 10) {
            System.out.printf("The spacecraft holds %.0f astronauts.", available);
        } else if (available < 3) {
            System.out.println("The spacecraft is too small.");
        } else {
            System.out.println("The spacecraft is too big.");
        }
    }
}
