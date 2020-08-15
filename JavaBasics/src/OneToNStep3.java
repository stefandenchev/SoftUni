import java.util.Scanner;

public class OneToNStep3 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int n = Integer.parseInt(s.nextLine());

        for (int i = 1; i <= n; i = i+3){
            System.out.println(i);
        }
    }
}
