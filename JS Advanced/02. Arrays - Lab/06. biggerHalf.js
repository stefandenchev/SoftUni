function biggerHalf(myArray) {
    return myArray
        .sort((a, b) => a - b)
        .slice(myArray.length / 2);
}

console.log(biggerHalf([4, 7, 2, 5]));