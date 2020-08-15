import java.util.Scanner;

public class histogram {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        int n = Integer.parseInt(s.nextLine());
        int gr1 = 0;
        int gr2 = 0;
        int gr3 = 0;
        int gr4 = 0;
        int gr5 = 0;

        for (int i = 0; i < n; i++) {
            int num = Integer.parseInt(s.nextLine());
            if (num < 200) {
                gr1++;
            }
            else if (num >= 200 && num <= 399){
                gr2++;
            }
            else if (num >= 400 && num <= 599){
                gr3++;
            }
            else if (num >= 600 && num <= 799){
                gr4++;
            }
            else {
                gr5++;
            }
        }

        double one = 1.0 * gr1 / n * 100;
        double two = 1.0 * gr2 /n * 100;
        double three = 1.0 * gr3 / n * 100;
        double four = 1.0 * gr4 / n * 100;
        double five = 1.0 * gr5 / n * 100;

        System.out.printf("%.2f%%%n", one);
        System.out.printf("%.2f%%%n", two);
        System.out.printf("%.2f%%%n", three);
        System.out.printf("%.2f%%%n", four);
        System.out.printf("%.2f%%", five);

    }
}
