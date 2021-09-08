function printSmallestTwo(myArray) {
    myArray.sort(function (a, b) { return a - b });
    myArray.splice(2);
    return myArray.join(' ');
}

console.log(printSmallestTwo([3, 0, 10, 4, 7, 3]));
