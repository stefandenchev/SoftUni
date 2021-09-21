function rotate(array, n) {
    let rotations = n % array.length;
    for (let i = 0; i < rotations; i++) {
        array.unshift(array.pop());
    }

    return array.join(' ');
}

console.log(rotate(['1',
    '2',
    '3',
    '4'],
    2
));

console.log(rotate(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15
));