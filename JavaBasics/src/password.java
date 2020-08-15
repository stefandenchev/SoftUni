import java.util.Scanner;

public class password {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String userName = s.nextLine();
        String password = s.nextLine();
        String input = s.nextLine();

        while (!input.equalsIgnoreCase(password)) {
            input = s.nextLine();
        }
        System.out.printf("Welcome %s!", userName);
    }
}
