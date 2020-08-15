import java.util.Scanner;

public class IsItValid {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int number = Integer.parseInt(s.nextLine());

        boolean isValid = (number > 10) && (number % 2 == 0);

        if (!isValid) {
            System.out.println("invalid");
        } else {
            System.out.println("valid");
        }
    }
}
