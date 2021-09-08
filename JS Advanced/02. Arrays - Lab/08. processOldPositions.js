function solve(myArray) {
    let result = [];
    for (let i = 1; i <= myArray.length; i+=2) {
        result.push(myArray[i] * 2);        
    }
    result.reverse();
    return result;
}

console.log(solve([3, 0, 10, 4, 7, 3]));