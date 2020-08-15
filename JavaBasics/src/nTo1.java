import java.util.Scanner;

public class nTo1 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int n = Integer.parseInt(s.nextLine());

        for (int i = n; i >= 1; i--){
            System.out.println(i);
        }
    }
}
