import java.util.Scanner;

public class numberPyramid {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int n = Integer.parseInt(s.nextLine());
        int counter = 1;
        boolean isBigger = false;

        for (int rows = 1; rows <= n; rows++) {
            for (int cols = 1; cols <= rows; cols++) {
                System.out.printf("%d ", counter);

                counter++;

                if (counter > n) {
                    isBigger = true;
                    break;
                }
            }
            if (isBigger) {
                break;
            }
            System.out.println("");
        }
    }
}
