import java.util.Scanner;

public class PersonalTitle {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        double age = Double.parseDouble(s.nextLine());
        char sex = s.nextLine().charAt(0);

        if (sex == 'f') {
            if (age < 16) {
                System.out.println("Miss");
            } else {
                System.out.println("Ms.");
            }
        } else {
            if (age < 16) {
                System.out.println("Master");
            } else {
                System.out.println("Mr.");
            }
        }
    }
}
