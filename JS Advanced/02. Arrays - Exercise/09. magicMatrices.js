function checkMagic(matrix) {
    let sum = 0;
    let currentSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            currentSum += matrix[i][j];
        }
        if (i == 0) {
            sum = currentSum;
        }
        if (sum != currentSum) {
            return false;
        }      
    }
    return true;
}

console.log(checkMagic([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   ));