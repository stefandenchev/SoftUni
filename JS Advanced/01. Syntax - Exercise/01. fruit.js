function shop(fruit, weight, price) {
    let kgs = weight / 1000;
    let money = price * kgs;
    console.log(`I need $${money.toFixed(2)} to buy ${kgs.toFixed(2)} kilograms ${fruit}.`);
}

shop('orange', 2500, 1.80)
