function solve(array) {
    let result = [];
    for (let i = 0; i < array.length; i++) {
        if (array[i] >= result[result.length-1] || result.length === 0) {
            result.push(array[i]);
        }
    }

    return result;
}

function solveWithReduce(array) {
    return array.reduce(function (result, currentValue) {
        if (currentValue >= result[result.length-1] || result.length === 0) {
            result.push(currentValue);
        }
        return result;
    }, [])
}

console.log(solveWithReduce([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));