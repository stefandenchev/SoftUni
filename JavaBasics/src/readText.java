import java.util.Scanner;

public class readText {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String input = s.nextLine();

        while (!input.equalsIgnoreCase("stop")) {
            input = s.nextLine();
        }
    }
}
