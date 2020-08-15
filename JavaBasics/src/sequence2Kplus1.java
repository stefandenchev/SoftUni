import java.util.Scanner;

public class sequence2Kplus1 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int number = Integer.parseInt(s.nextLine());
        int counter = 1;
        while (counter <= number) {
            System.out.println(counter);
            counter = 2 * counter + 1;
        }
    }
}
