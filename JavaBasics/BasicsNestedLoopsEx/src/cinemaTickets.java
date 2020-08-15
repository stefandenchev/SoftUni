import java.util.Scanner;

public class cinemaTickets {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int studentCount = 0;
        int studentCountTotal = 0;
        int standardCount = 0;
        int standardCountTotal = 0;
        int kidCount = 0;
        int kidCountTotal = 0;
        int seatsTaken = 0;

        double count = 0;
        double totalCount = 0;

        boolean finished = false;

        while (true) {
            if (finished) {
                break;
            }
            String input = s.nextLine();
            if (input.equals("Finish")) {
                break;
            }
            int freeSpace = Integer.parseInt(s.nextLine());
            while (true) {
                seatsTaken++;
                String ticketType = s.nextLine();
                if (ticketType.equals("student")) {
                    studentCount++;
                } else if (ticketType.equals("standard")) {
                    standardCount++;
                } else if (ticketType.equals("kid")) {
                    kidCount++;
                }
                if (ticketType.equals("End") || ticketType.equals("Finish") || freeSpace == seatsTaken) {
                    count += 1.0 * studentCount + standardCount + kidCount;
                    totalCount += count;
                    System.out.printf("%s - %.2f%% full.%n", input, 100 * count / freeSpace);
                    count = 0;
                    studentCountTotal += studentCount;
                    standardCountTotal += standardCount;
                    kidCountTotal += kidCount;
                    studentCount = 0;
                    standardCount = 0;
                    kidCount = 0;
                    seatsTaken = 0;
                    if (ticketType.equals("Finish")) {
                        finished = true;
                    }
                    break;
                }

            }

        }
        System.out.printf("Total tickets: %.0f%n", totalCount);
        System.out.printf("%.2f%% student tickets.%n", 100 * studentCountTotal / totalCount);
        System.out.printf("%.2f%% standard tickets.%n", 100 * standardCountTotal / totalCount);
        System.out.printf("%.2f%% kids tickets.%n", 100 * kidCountTotal / totalCount);

    }
}
