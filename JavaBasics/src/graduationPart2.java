import java.util.Scanner;

public class graduationPart2 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        String student = s.nextLine();
        int currentGrade = 1;
        double sum = 0;
        int rip = 0;

        while (currentGrade <= 12) {
            double mark = Double.parseDouble(s.nextLine());
            if (mark < 4) {
                rip++;
                if (rip == 2) {
                    System.out.printf("%s has been excluded at %d grade", student, currentGrade);
                    break;
                }
                continue;
            }
            sum += mark;
            currentGrade++;
        }
        if (rip < 2) {
            double average = sum / 12;
            System.out.printf("%s graduated. Average grade: %.2f", student, average);
        }
    }
}