import java.util.Scanner;

public class lengthTraining {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

//        String a = "A123456";
        int b = 123456;
//        a.charAt(0);
//        System.out.println(a.length());
//        System.out.println(a.charAt(0));
        int sum = 0;
        String aAsSting = b + " ";
        for (int i = 0; i < aAsSting.length(); i++) {
            // System.out.println(aAsSting.charAt(i));
            char currentChar = aAsSting.charAt(i);
            int currentNumber = Character.getNumericValue(currentChar);
            sum += currentNumber;
        }

//        for (int i = 0; i < a.length(); i++) {
//            System.out.println(a.charAt(i));
//        }
//        System.out.println(b % 100); // Get last 2 digits
        while (b > 0) {
            System.out.println(b % 10);
            b = b / 10;
        }
    }
}
