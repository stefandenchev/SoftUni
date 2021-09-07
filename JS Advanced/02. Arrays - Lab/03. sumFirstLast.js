function sum(myArray) {
    return parseInt(myArray[0]) + parseInt(myArray[myArray.length - 1]);
}

console.log(sum(['20', '30', '40']));
console.log(sum(['5', '10']));