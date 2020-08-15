import java.util.Scanner;

public class bus {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int passengers = Integer.parseInt(s.nextLine());
        int stops = Integer.parseInt(s.nextLine());

        for (int i = 1; i <= stops; i++) {
            int out = Integer.parseInt(s.nextLine());
            int in = Integer.parseInt(s.nextLine());
            passengers = passengers - out + in;
            if (i % 2 == 1){
                passengers += 2;
            } else {
                passengers -= 2;
            }
        }
        System.out.printf("The final number of passengers is : %d", passengers);
    }
}
