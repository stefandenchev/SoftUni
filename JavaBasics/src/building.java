import java.util.Scanner;

public class building {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int endFloor = Integer.parseInt(s.nextLine());
        int rooms = Integer.parseInt(s.nextLine());

        for (int i = endFloor; i >= 1; i--) {
            for (int j = 0; j < rooms; j++) {
                if (i == endFloor) {
                    System.out.printf("L%d%d ", i, j);
                }
                else if (i % 2 == 0) {
                    System.out.printf("O%d%d ", i, j);
                } else {
                    System.out.printf("A%d%d ", i, j);
                }
            }
            System.out.println("");
        }

    }
}
