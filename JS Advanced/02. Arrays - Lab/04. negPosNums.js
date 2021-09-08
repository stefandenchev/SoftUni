function solve(myArray) {
    let resultArr = [];
    for (let num of myArray) {
        if (num < 0) {
            resultArr.unshift(num);
        } else {
            resultArr.push(num);
        }
    }
    return resultArr.join('\n');
}

console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));