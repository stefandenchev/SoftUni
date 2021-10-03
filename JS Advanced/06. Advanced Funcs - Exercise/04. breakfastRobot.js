function work(input) {
    const ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    const foods = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    }

    function restock(food, quantity) {
        ingredients[food] += Number(quantity);
        return 'Success';
    }

    function prepare(food, quantity) {
        const remainingIngredients = {};

        for (const element in foods[food]) {
            const remaining = ingredients[element] - foods[food][element] * Number(quantity);
            if (remaining < 0) {
                return `Error: not enough ${element} in stock`
            } else {
                remainingIngredients[element] = remaining;
            }
        }

        Object.assign(ingredients, remainingIngredients);
        return 'Success';
    }

    function report() {
        return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
    }

    function control(input) {
        const [command, item, quantity] = input.split(' ');
        if (command == 'restock') {
            return restock(item, quantity);
        } else if (command == 'prepare') {
            return prepare(item, quantity);
        } else if (command == 'report') {
            return report();
        }
    }

    return control;
}

let breakfast = work();
console.log(breakfast('restock flavour 50'));
console.log(breakfast('prepare lemonade 4'));
console.log(breakfast('restock carbohydrate 10'));
console.log(breakfast('restock flavour 10'));
console.log(breakfast('prepare apple 1'));
console.log(breakfast('restock fat 10'));
console.log(breakfast('prepare burger 1'));
console.log(breakfast('report'));
