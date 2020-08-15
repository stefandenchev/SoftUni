import java.util.Scanner;

public class SmallShop {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        String product = s.nextLine();
        String city = s.nextLine();
        double amount = Double.parseDouble(s.nextLine());
        double price = 0;

        switch (city) {
            case "Sofia":
                if (product.equalsIgnoreCase("coffee")) {
                    price = amount * 0.5;
                } else if (product.equalsIgnoreCase("water")) {
                    price = amount * 0.8;
                } else if (product.equalsIgnoreCase("beer")) {
                    price = amount * 1.2;
                } else if (product.equalsIgnoreCase("sweets")) {
                    price = amount * 1.45;
                } else if (product.equalsIgnoreCase("peanuts")) {
                    price = amount * 1.6;
                }
                break;
            case "Plovdiv":
                if (product.equalsIgnoreCase("coffee")) {
                    price = amount * 0.4;
                } else if (product.equalsIgnoreCase("water")) {
                    price = amount * 0.7;
                } else if (product.equalsIgnoreCase("beer")) {
                    price = amount * 1.15;
                } else if (product.equalsIgnoreCase("sweets")) {
                    price = amount * 1.30;
                } else if (product.equalsIgnoreCase("peanuts")) {
                    price = amount * 1.50;
                }
                break;
            case "Varna":
                if (product.equalsIgnoreCase("coffee")) {
                    price = amount * 0.45;
                } else if (product.equalsIgnoreCase("water")) {
                    price = amount * 0.7;
                } else if (product.equalsIgnoreCase("beer")) {
                    price = amount * 1.10;
                } else if (product.equalsIgnoreCase("sweets")) {
                    price = amount * 1.35;
                } else if (product.equalsIgnoreCase("peanuts")) {
                    price = amount * 1.55;
                }
                break;
        }
        System.out.printf("%.2f", price);
    }
}