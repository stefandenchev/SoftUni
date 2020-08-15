import java.util.Scanner;

public class halfSumElement {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int n = Integer.parseInt(s.nextLine());
        int max = Integer.MIN_VALUE;
        int sum = 0;

        for (int i = 0; i < n; i++) {
            int num = Integer.parseInt(s.nextLine());
            sum += num;
            if (num > max) {
                max = num;
            }
        }
        int sumNoMax = sum - max;
        if (max == sumNoMax){
            System.out.println("Yes");
            System.out.printf("Sum = %d", sumNoMax);
        } else {
            System.out.println("No");
            System.out.printf("Diff = %d", Math.abs(max - sumNoMax));
        }
    }
}