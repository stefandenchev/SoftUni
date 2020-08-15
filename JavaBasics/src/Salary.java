import java.util.Scanner;

public class Salary {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int tabs = Integer.parseInt(s.nextLine());
        int salary = Integer.parseInt(s.nextLine());

        for (int tab = 1; tab <= tabs; tab++) {
            String  site = s.nextLine();
            switch (site) {
                case "Facebook":
                    salary -= 150;
                    break;
                case "Instagram":
                    salary -= 100;
                    break;
                case "Reddit":
                    salary -= 50;
                    break;
            }

            if (salary <= 0) {
                System.out.println("You have lost your salary.");
                break;
            }
        }
        if (salary > 0) {
            System.out.println(salary);
        }
    }
}