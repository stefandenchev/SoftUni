function carCompany(input) {
    let cars = new Map();
    for (const car of input) {
        let [brand, model, amount] = car.split(' | ');
        amount = Number(amount);

        if (cars.has(brand)) {
            let carBrand = cars.get(brand);
            if (carBrand.has(model)) {
                let carModel = carBrand.get(model);
                carModel += amount;
                carBrand.set(model, carModel);
            } else {
                carBrand.set(model, amount);
            }
        } else {
            let modelMap = new Map();
            modelMap.set(model, amount);
            cars.set(brand, modelMap);
        }
    }

    for (const key of cars.keys()) {
        console.log(key);
        let brand = cars.get(key);
        for (const [model, count] of brand) {
            console.log(`###${model} -> ${count}`);
        }
    }
}

carCompany(['Audi | Q7 | 1000',
            'Audi | Q6 | 100',
            'BMW | X5 | 1000',
            'BMW | X6 | 100',
            'Citroen | C4 | 123',
            'Volga | GAZ-24 | 1000000',
            'Lada | Niva | 1000000',
            'Lada | Jigula | 1000000',
            'Citroen | C4 | 22',
            'Citroen | C5 | 10']
);