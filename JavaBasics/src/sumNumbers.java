import java.util.Scanner;

public class sumNumbers {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int sum = 0;
        int n = Integer.parseInt(s.nextLine());

        for (int i = 0; i < n; i++){
            int currN = Integer.parseInt(s.nextLine());
            sum = sum + currN;
        }
        System.out.println(sum);
    }
}
