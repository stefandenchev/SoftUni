import java.util.Scanner;

public class walking {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int stepsGoal = 10000;
        String command = s.nextLine();

        while (!command.equals("Going home")) {
            int steps = Integer.parseInt(command);
            stepsGoal -= steps;
            if (stepsGoal <= 0) {
                System.out.println("Goal reached! Good job!");
                break;
            }
            command = s.nextLine();
        }
        if (command.equals("Going home")) {
            command = s.nextLine();
            int steps = Integer.parseInt(command);
            stepsGoal -= steps;
            if (stepsGoal <= 0) {
                System.out.println("Goal reached! Good job!");
            } else if (stepsGoal > 0) {
                System.out.printf("%d more steps to reach goal.", stepsGoal);
            }
        }

    }
}
