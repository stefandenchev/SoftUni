function shop(fruit, weight, price) {
    let money = (price * weight / 1000).toFixed(2);
    let kgs = (weight/1000).toFixed(2);
    console.log(`I need $${money} to buy ${kgs} kilograms ${fruit}.`);
}

shop('orange', 2500, 1.80)