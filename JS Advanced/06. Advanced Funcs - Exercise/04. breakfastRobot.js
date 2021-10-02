function breakfast(input) {
    const ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }
    const [command, food, quantity] = input.split(' ');

    if (command == 'restock') {
        ingredients[food] += Number(quantity);
    }

    return ingredients;
}

console.log(breakfast('restock flavour 50'));
console.log(breakfast('prepare lemonade 4'));
console.log(breakfast('restock carbohydrate 10'));
console.log(breakfast('restock flavour 10'));
console.log(breakfast('prepare apple 1'));
console.log(breakfast('restock fat 10'));
console.log(breakfast('prepare burger 1'));
console.log(breakfast('report'));
