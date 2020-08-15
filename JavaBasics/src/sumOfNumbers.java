import java.util.Scanner;

public class sumOfNumbers {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int begin = Integer.parseInt(s.nextLine());
        int end = Integer.parseInt(s.nextLine());
        int magicN = Integer.parseInt(s.nextLine());
        int counter = 0;
        boolean found = false;

        for (int i = begin; i <= end; i++) {
            for (int j = begin; j <= end; j++) {
                counter++;
                if (i + j == magicN) {
                    System.out.printf("Combination N:%d (%d + %d = %d)%n", counter, i, j, magicN);
                    found = true;
                    break;
                }
            }
            if (found){
                break;
            }
        }
        if (!found) {
            System.out.printf("%d combinations - neither equals %d", counter, magicN);
        }
    }
}