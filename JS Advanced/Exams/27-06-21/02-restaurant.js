class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = Number(budgetMoney);
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
            this.menu[meal] = {
                products: {},
                price: price
            };

            productsNeeded.forEach((el) => {
                let [name, quantity] = el.split(' ');
                quantity = Number(quantity);
                this.menu[meal].products[name] = quantity;
            })

            let mealsCount = Object.keys(this.menu).length;
            if (mealsCount == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            } else {
                return `Great idea! Now with the ${meal} we have ${mealsCount} meals in the menu, other ideas?`;
            }
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }

    }

    showTheMenu() {
        if (Object.keys(this.menu).length == 0) {
            return "Our menu is not ready yet, please come later...";
        } else {
            let result = [];

            for (const meal in this.menu) {
                result.push(`${meal} - $ ${this.menu[meal].price}`);
            }
            return result.join('\n');
            // return Object.entries(this.menu).forEach(([key, value]) => console.log(`${key} = $ ${value.price}`));
        }
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        } else {
            let productsNeeded = {};
            for (const product in this.menu[meal].products) {
                if (!this.stockProducts[product] || this.stockProducts[product] < this.menu[meal].products[product]) {
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                } else {
                    productsNeeded[product] = this.menu[meal].products[product];
                }
            }

            for (const prodNeeded in productsNeeded) {
                this.stockProducts[prodNeeded] -= productsNeeded[prodNeeded];

            }
        }
        this.budgetMoney += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`
    }
}


let test = new Restaurant(1000);
test.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
test.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
let res = test.makeTheOrder('frozenYogurt');

