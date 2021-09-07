function printSequence(n, k) {
    let myArray = [1];
    for (let i = 1; i < n; i++) {
        let num = 0;
        for (let j = k; j >= 0; j--) {
            num += myArray[j];
        }
        myArray.push(num);
    }
    return myArray;
}

console.log(printSequence(6, 3));
console.log(printSequence(8, 2));