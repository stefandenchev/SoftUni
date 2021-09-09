function sort(array) {
    array.sort(function (a, b) {
        return a.length - b.length || a.localeCompare(b)
    });

    return array.join('\n');
}

console.log(sort(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
));

console.log('---------------')

console.log(sort(['test',
    'Deny',
    'omen',
    'Default']
));