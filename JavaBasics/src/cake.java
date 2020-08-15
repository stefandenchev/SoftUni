import java.util.Scanner;

public class cake {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int width = Integer.parseInt(s.nextLine());
        int length = Integer.parseInt(s.nextLine());
        int pieces = width * length;
        String command = s.nextLine();

        while (!command.equals("STOP")) {
            int piecesTaken = Integer.parseInt(command);
            pieces -= piecesTaken;
            if (pieces <= 0) {
                System.out.printf("No more cake left! You need %d pieces more.", Math.abs(pieces));
                break;
            }
            command = s.nextLine();
        }

        if (command.equals("STOP")) {
            System.out.printf("%d pieces are left.", pieces);
        }
    }
}
