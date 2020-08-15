import java.util.Scanner;

public class multiplyTable {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String number = s.nextLine();

        char charPos1 = number.charAt(2);
        char charPos2 = number.charAt(1);
        char charPos3 = number.charAt(0);

        int pos1 = Integer.parseInt(String.valueOf(charPos3));
        int pos2 = Integer.parseInt(String.valueOf(charPos2));
        int pos3 = Integer.parseInt(String.valueOf(charPos1));

        for (int i = 1; i <= pos3; i++) {
            for (int j = 1; j <= pos2; j++) {
                for (int k = 1; k <= pos1; k++) {
                    System.out.printf("%d * %d * %d = %d;%n", i, j, k, i * j * k);
                }
            }
        }

    }
}
