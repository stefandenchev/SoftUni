function findEquals(arr) {

    let counter = 0;

    for (let i = 0; i < arr.length; i++) {
        let subArr = arr[i];
        for (let j = 0; j < subArr.length; j++) {
            let checker = subArr[j];
            if (i !== arr.length - 1) {
                if (checker === subArr[j + 1] || checker === arr[i + 1][j]) {
                    counter++;
                }
            }
            else {
                if (checker === subArr[j + 1]) {
                    counter++;
                }
            }
        }

    }

    return counter;
}

console.log(findEquals([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
));

