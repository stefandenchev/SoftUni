function juice(input) {
    let juiceMap = new Map();
    let bottlesMap = new Map();

    for (let i = 0; i < input.length; i++) {
        let [name, quantity] = input[i].split(' => ');
        quantity = Number(quantity);

        if (!juiceMap.has(name)) {
            juiceMap.set(name, 0);
        }

        let totalQuantity = juiceMap.get(name) + quantity;
        if (totalQuantity >= 1000) {
            if (!bottlesMap.has(name)) {
                bottlesMap.set(name, 0);
            }

            let newBottles = Math.trunc(totalQuantity / 1000);
            let totalBottles = bottlesMap.get(name) + newBottles;
            bottlesMap.set(name, totalBottles);
        }

        juiceMap.set(name, totalQuantity % 1000);
    }

    bottlesMap.forEach((val, key) => console.log(`${key} => ${val}`));

    // return [...bottlesMap]
    //     .map(([key, value]) => `${key} => ${value}`)
    //     .join(`\n`);
}

console.log(juice(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
));

console.log(juice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
));