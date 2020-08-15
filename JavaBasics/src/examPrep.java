import java.util.Scanner;

public class examPrep {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int threshold = Integer.parseInt(s.nextLine());
        int failedTimes = 0;
        int tasksDone = 0;
        double sumGrades = 0;
        String lastTask = "";
        boolean hasFailed = true;

        while (failedTimes < threshold) {
            String problemName = s.nextLine();
            if (problemName.equals("Enough")) {
                hasFailed = false;
                break;
            }
            int grade = Integer.parseInt(s.nextLine());
            if (grade <= 4) {
                failedTimes++;
            }
            sumGrades += grade;
            tasksDone++;
            lastTask = problemName;
        }
        if (hasFailed) {
            System.out.printf("You need a break, %d poor grades.", threshold);
        } else {
            System.out.printf("Average score: %.2f%n", sumGrades / tasksDone);
            System.out.printf("Number of problems: %d%n", tasksDone);
            System.out.printf("Last problem: %s", lastTask);
        }

    }
}
