function sumInRange(n, m) {
    let num1 = Number(n);
    let num2 = Number(m);
    let result = 0;
    for (let i = num1; i <= num2; i++) {
        result += i;      
    }
    console.log(result);
}

sumInRange('1', '5')
sumInRange('-8', '20')