import java.util.Scanner;

public class Moving {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int width = Integer.parseInt(s.nextLine());
        int length = Integer.parseInt(s.nextLine());
        int height = Integer.parseInt(s.nextLine());
        int freeSpace = width * length * height;

        while (true) {
            String input = s.nextLine();
            if (input.equalsIgnoreCase("Done")) {
                System.out.printf("%d Cubic meters left.", freeSpace);
                break;
            }
            int boxes = Integer.parseInt(input);
            freeSpace -= boxes;
            if (freeSpace < 0) {
                System.out.printf("No more free space! You need %d Cubic meters more.", Math.abs(freeSpace));
                break;
            }
        }
    }
}
