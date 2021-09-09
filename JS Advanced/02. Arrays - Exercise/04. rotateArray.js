function rotate(array, n){
    for (let i = 0; i < n; i++) {
        array.unshift(array[array.length - 1]);
        array.pop();
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