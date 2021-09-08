function biggestElement(myArray) {
    let biggest = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < myArray.length; i++) {
        for (let j = 0; j < myArray[i].length; j++) {
            if (myArray[i][j] > biggest) {
                biggest = myArray[i][j];
            }
        }
    }
    return biggest;
}

console.log(biggestElement([[20, 50, 10],
    [8, 33, 145]]
   ));

   console.log(biggestElement([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   ));