import java.util.Scanner;

public class minNumber {
    public static void main(String[] args) {


        Scanner s = new Scanner(System.in);
        int nums = Integer.parseInt(s.nextLine());
        int minNum = Integer.MAX_VALUE;
        int counter = 1;

        while (counter <= nums) {
            int num = Integer.parseInt(s.nextLine());
            counter++;
            if (num < minNum) {
                minNum = num;
            }
        }
        System.out.println(minNum);
    }
}
