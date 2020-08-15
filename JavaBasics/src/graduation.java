import java.util.Scanner;

public class graduation {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        String student = s.nextLine();
        int currentGrade = 1;
        double sum = 0;

        while (currentGrade <= 12) {
            double mark = Double.parseDouble(s.nextLine());
            if (mark < 4) {
                continue;
            }
            sum += mark;
            currentGrade++;
        }
        double average = sum / 12;
        System.out.printf("%s graduated. Average grade: %.2f", student, average);
    }
}
