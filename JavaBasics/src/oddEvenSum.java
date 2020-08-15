import java.util.Scanner;

public class oddEvenSum {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int n = Integer.parseInt(s.nextLine());
        int sumOdd = 0;
        int sumEven = 0;

        for (int i = 0; i < n; i++) {
            int number = Integer.parseInt(s.nextLine());
            if (i % 2 == 1){
                sumOdd += number;
            } else {
                sumEven += number;
            }
        }

        if (sumOdd == sumEven){
            System.out.println("Yes");
            System.out.printf("Sum = %d",sumEven);
        } else {
            System.out.println("No");
            System.out.printf("Diff = %d", Math.abs(sumEven-sumOdd));
        }
    }
}
