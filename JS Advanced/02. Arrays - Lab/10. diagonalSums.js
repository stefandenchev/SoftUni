function diagonalSums(myArray) {
    let left = 0;
    let right = 0;
    for (let i = 0; i < myArray.length; i++) {
        left += myArray[i][i];
        right += myArray[i][myArray.length - i - 1];
    }
    return left + " " + right;
}

console.log(diagonalSums([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]
));