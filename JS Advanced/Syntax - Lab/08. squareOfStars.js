function printStars(num = 5) {
    let array = []
    for (let i = 0; i < num; i++) {
        for (let y = 0; y < num; y++) {
            array.push('*');
        }
        console.log(array.join(' '));
        array = []
    }
}

printStars(5);