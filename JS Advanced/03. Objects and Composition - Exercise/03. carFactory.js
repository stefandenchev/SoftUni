function factory(order) {
    const car = {};
    car.model = order.model;
    if (order.power <= 90) {
        car.engine = {
            power: 90,
            volume:1800,
        }
    } else if (order.power > 90 && order.power <= 120) {
        car.engine = {
            power: 120,
            volume: 2400,
        }
    } else if (order.power > 120) {
        car.engine = {
            power: 200,
            volume: 3500,
        }
    }
    car.carriage = {
        type: order.carriage,
        color: order.color
    }

    let size = order.wheelsize;
    if (size % 2 == 0) {
        size--;
    }

    car.wheels = [size, size, size, size];

    return car;
}

console.log(factory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));