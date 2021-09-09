function print(array, n) {
    let result = array.filter((elem, i) => i % step === 0);
/*     let result = [];
    for (let i = 0; i < array.length; i += n) {
        result.push(array[i]);
    } */
    return result;
}

console.log(print(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));

console.log(print(['dsa',
'asd', 
'test', 
'tset'], 
2
));

console.log(print(['1', 
'2',
'3', 
'4', 
'5'], 
6
));