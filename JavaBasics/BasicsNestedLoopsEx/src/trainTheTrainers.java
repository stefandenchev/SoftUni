import java.util.Scanner;

public class trainTheTrainers {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int juryCount = Integer.parseInt(s.nextLine());

        double allAverageGrade = 0;
        int counter = 0;

        while (true) {
            String input = s.nextLine();

            if (input.equals("Finish")) {
                break;
            }

            counter++;

            String name = input;

            double averagePresGrade = 0;
            for (int i = 0; i < juryCount; i++) {
                double grade = Double.parseDouble(s.nextLine());
                    averagePresGrade += grade;

            }
            averagePresGrade /= juryCount;
            allAverageGrade += averagePresGrade;

            System.out.printf("%s - %.2f.%n", name,
                    averagePresGrade);
        }
        allAverageGrade /= counter;
        System.out.printf("Student's final assessment is %.2f.", allAverageGrade);
    }
}
