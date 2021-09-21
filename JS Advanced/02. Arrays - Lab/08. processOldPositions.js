function solve(myArray) {
    let result = myArray
    .filter((v, i) => i % 2 == 1)
    .map(x => x * 2)
    .reverse();
    return result;
}

console.log(solve([3, 0, 10, 4, 7, 3]));