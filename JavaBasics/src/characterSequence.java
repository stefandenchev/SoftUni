import java.util.Scanner;

public class characterSequence {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String word = s.nextLine();

        for (int i = 0; i < word.length(); i++){
            System.out.println(word.charAt(i));
        }

    }
}
