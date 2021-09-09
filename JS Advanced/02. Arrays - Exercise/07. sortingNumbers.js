function sort(array) {
    let originalLength = array.length;
    array.sort((a, b) => a-b);
    const result = [];

    for (let i = 0; i < originalLength / 2; i++) {
        result.push(array.shift());
        result.push(array.pop());    
    }
    return result;
}

console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));