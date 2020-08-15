import java.util.Scanner;

public class trekkingMania {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int groups = Integer.parseInt(s.nextLine());
        int peopleTotal = 0;

        double first = 0;
        double second = 0;
        double third = 0;
        double fourth = 0;
        double fifth = 0;

        for (int i = 0; i < groups; i++) {
            int peopleInGroup = Integer.parseInt(s.nextLine());
            peopleTotal += peopleInGroup;
            if (peopleInGroup <= 5) {
                first += peopleInGroup;
            } else if (peopleInGroup >= 6 && peopleInGroup <= 12) {
                second += peopleInGroup;
            } else if (peopleInGroup >= 13 && peopleInGroup <= 25) {
                third += peopleInGroup;
            } else if (peopleInGroup >= 26 && peopleInGroup <= 40) {
                fourth += peopleInGroup;
            } else if (peopleInGroup >= 41) {
                fifth += peopleInGroup;
            }

        }
        System.out.printf("%.2f%%%n", first * 100 / peopleTotal);
        System.out.printf("%.2f%%%n", second * 100 / peopleTotal);
        System.out.printf("%.2f%%%n", third * 100 / peopleTotal);
        System.out.printf("%.2f%%%n", fourth * 100 / peopleTotal);
        System.out.printf("%.2f%%", fifth * 100 / peopleTotal);


    }
}
