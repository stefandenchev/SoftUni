class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const item of products) {
            let [name, quantity, price] = item.split(' ');
            if (this.budgetMoney >= price) {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = Number(quantity);
                } else {
                    let currQuantity = this.stockProducts[name];
                    this.stockProducts[name] = Number(quantity) + Number(currQuantity);
                }
                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, productsNeeded, price) {

        if (!this.menu[meal]) {
            this.menu[meal] = { products: productsNeeded, price: price };
            let mealsCount = Object.keys(this.menu).length;
            if (mealsCount == 1) {
                console.log(`Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`);
            } else {
                console.log(`Great idea! Now with the ${meal} we have ${mealsCount} meals in the menu, other ideas?`);
            }
        } else {
            console.log(`The ${meal} is already in the our menu, try something different.`);
        }

    }

    showTheMenu() {
        return Object.entries(this.menu).forEach(([key, value]) => console.log(`${key} = $ ${value.price}`));
    }

    makeTheOrder(orderedMeal) {
        if (!this.menu[orderedMeal]) {
            `There is not ${orderedMeal} yet in our menu, do you want to order something else?`;
        }
    }
}

let test = new Restaurant(1000);
test.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
let res = test.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55);

