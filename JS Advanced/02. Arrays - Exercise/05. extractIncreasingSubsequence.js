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
    let biggest = Number.MIN_SAFE_INTEGER;
    return array.reduce(function (result, currentValue) {
        if (currentValue >= biggest) {
            biggest = currentValue;
            result.push(currentValue);
        }
        return result;
    }, [])
}

function solveWithFilter(array) {
    let biggest = Number.MIN_SAFE_INTEGER;
    const result = array.filter((x) => {
        if (x >= biggest) {
            biggest = x;
            return true;
        }
        return false;
    })
    return result;
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