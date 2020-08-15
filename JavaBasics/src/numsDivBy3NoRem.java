public class numsDivBy3NoRem {
    public static void main(String[] args) {

        int n = 3;
        while (n % 3 == 0 && n < 100) {
            System.out.println(n);
            n += 3;
        }
    }
}
