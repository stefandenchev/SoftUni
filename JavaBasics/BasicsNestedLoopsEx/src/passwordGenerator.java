import java.util.Scanner;

public class passwordGenerator {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int n = Integer.parseInt(s.nextLine());
        int l = Integer.parseInt(s.nextLine());


        for (int d1 = 1; d1 < n; d1++) {
            for (int d2 = 1; d2 < n; d2++) {
                for (int d3 = 'a'; d3 < 'a' + l; d3++) {
                    for (int d4 = 'a'; d4 < 'a' + l; d4++) {
                        for (int d5 = Math.max(d1, d2) + 1; d5 <= n; d5++) {
                            System.out.printf("%d%d%c%c%d ", d1, d2, d3, d4, d5);
                        }
                    }
                }
            }
        }
    }
}
