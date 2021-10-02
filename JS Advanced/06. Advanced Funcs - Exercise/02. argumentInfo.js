function solve(...input) {

    let count = {};

    for (const item of input) {
        console.log(`${typeof (item)}: ${item}`);
        if (!count[typeof (item)]) {
            count[typeof (item)] = 1;
        } else {
            count[typeof (item)]++;
        }
    }

    let result = Object.entries(count);
    result.sort((a, b) => b[1] - a[1]);

    for (const [key, value] of result) {
        if (value > 0) {
            console.log(`${key} = ${value}`);
        }
    }
}

solve({ name: 'bob' }, 3.333, 9.999);