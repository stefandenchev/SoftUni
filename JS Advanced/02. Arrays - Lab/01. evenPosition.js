function even(myArray) {
    let result = '';
    for (let i = 0; i < myArray.length; i+=2) {
        result += myArray[i] + ' ';
    }

    return result;
}

let testArr = ['20', '30', '40', '50', '60'];
console.log(even(testArr));