import java.util.Scanner;

public class combinations {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int magicNumber = Integer.parseInt(s.nextLine());
        int counter = 0;

        for (int i = 0; i <= magicNumber; i++) {
            for (int j = 0; j <= magicNumber; j++) {
                for (int k = 0; k <= magicNumber; k++) {
                    if (i + j + k == magicNumber) {
                        counter++;
                    }
                }
            }
        }
        System.out.println(counter);
    }
}
