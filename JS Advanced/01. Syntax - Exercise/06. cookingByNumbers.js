function numbersCook(start, op1, op2, op3, op4, op5) {
    let operations = [op1, op2, op3, op4, op5];
    let num = parseInt(start);

    for (let i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case "chop":
                num /= 2;
                break;

            case "dice":
                num = Math.sqrt(num);
                break;
            case "spice":
                num++;
                break;

            case "bake":
                num *= 3;
                break;

            case "fillet":
                num = num * 0.8;
                break;
        }
        console.log(num);

    }
}

numbersCook('9', 'dice', 'spice', 'chop', 'bake', 'fillet')