function sortCatalogue(input) {
    let catalogue = {};
    for (const data of input) {
        let [product, price] = data.split(' : ');

        const index = product[0];
        if (!catalogue[index]) {
            catalogue[index] = {};
        }

        catalogue[index][product] = Number(price);
    }

    JSON.stringify(catalogue);
    const ordered = Object.keys(catalogue).sort().reduce(
        (obj, key) => {
            obj[key] = catalogue[key];
            return obj;
        },
        {}
    );

    for (const key in ordered) {
        console.log(key)
        console.log(`  ${ordered}`);
    }
}


console.log(sortCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
));