function checkMagic(matrix) {
    let rowSums = [];
    let colSums = [];

    for (let i = 0; i < matrix.length; i++) {
        let row = matrix[i];
        let sum = row.reduce((result, current) => (result + current), 0)
        rowSums.push(sum);
    }

    for (let i = 0; i < matrix.length; i++) {
        let newRow = [];
        for (let j = 0; j < matrix.length; j++) {
            newRow.push(matrix[j][i]);
        }

        let sum = newRow.reduce((result, current) => (result + current), 0)
        colSums.push(sum);
    }
    return rowSums.concat(colSums).every((el, i, arr) => el === arr[0]);
}

console.log(checkMagic(
    [
        [4, 5, 6],
        [6, 5, 4],
        [5, 5, 5]
    ]
));