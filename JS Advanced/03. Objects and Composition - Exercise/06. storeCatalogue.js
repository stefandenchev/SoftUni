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

    const ordered = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));

    for (const key of ordered) {
        let products = Object.entries(catalogue[key])
            .sort((a, b) => a[0].localeCompare(b[0]));
        console.log(key);
        products.forEach((el) => {
            console.log(`  ${el[0]}: ${el[1]}`);
        })
    }
}


sortCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);