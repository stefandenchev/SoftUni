import java.util.Scanner;

public class sumNumbersWhile {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int sum = 0;
        String input = s.nextLine();

        while (!input.equals("Stop")) {
            sum = sum + Integer.parseInt(input) ;
            input = s.nextLine();
        }
        System.out.println(sum);
    }
}
