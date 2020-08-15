import java.util.Scanner;

public class bakingCompetition {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int people = Integer.parseInt(s.nextLine());
        String type = "";

        int cookies = 0;
        int totalCookies = 0;
        int cakes = 0;
        int totalCakes = 0;
        int waffles = 0;
        int totalWaffles = 0;


        for (int i = 0; i < people; i++) {
            String name = s.nextLine();
            while (true) {
                type = s.nextLine();
                if (type.equals("Stop baking!")) {
                    System.out.printf("%s baked %d cookies, %d cakes and %d waffles.%n", name, cookies, cakes, waffles);
                    totalCookies += cookies;
                    totalCakes += cakes;
                    totalWaffles += waffles;
                    cookies = 0;
                    cakes = 0;
                    waffles = 0;
                    break;
                } else {
                    int amount = Integer.parseInt(s.nextLine());
                    switch (type) {
                        case "cookies":
                            cookies += amount;
                            break;
                        case "cakes":
                            cakes += amount;
                            break;
                        case "waffles":
                            waffles += amount;
                            break;
                    }
                }
            }
        }
        int total = totalCookies + totalCakes + totalWaffles;

        double cookiesMoney = 1.0 * totalCookies * 1.5;
        double cakesMoney = 1.0 * totalCakes * 7.8;
        double wafflesMoney = 1.0 * totalWaffles * 2.3;
        double totalMoney = cookiesMoney + cakesMoney + wafflesMoney;

        System.out.printf("All bakery sold: %d%n", total);
        System.out.printf("Total sum for charity: %.2f lv.", totalMoney);


    }
}
