import java.util.Scanner;

public class oldBooks {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        String book = s.nextLine();
        int bookCount = Integer.parseInt(s.nextLine());
        int booksChecked = 0;

        while (bookCount > 0) {
            String title = s.nextLine();
            if (title.equalsIgnoreCase(book)) {
                System.out.printf("You checked %d books and found it.", booksChecked);
                break;
            } else {
                bookCount--;
                booksChecked++;
            }
        }
        if (bookCount == 0) {
            System.out.println("The book you search is not here!");
            System.out.printf("You checked %d books.", booksChecked);
        }
    }
}
