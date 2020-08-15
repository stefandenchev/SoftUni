import java.util.Scanner;

public class maxNumber {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int nums = Integer.parseInt(s.nextLine());
        int maxNum = Integer.MIN_VALUE;
        int counter = 1;

        while (counter <= nums) {
            int num = Integer.parseInt(s.nextLine());
            counter++;
            if (num > maxNum) {
                maxNum = num;
            }
        }
        System.out.println(maxNum);
    }
}
