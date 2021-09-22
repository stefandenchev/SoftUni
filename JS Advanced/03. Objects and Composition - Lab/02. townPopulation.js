function calculate(input) {
    let towns = {};
    for (let data of input) {
        let tokens = data.split(' <-> ');
        let name = tokens[0];
        let pop = Number(tokens[1]);

        if (towns[name]) {
            pop += towns[name];
        }
        towns[name] = pop;
    }

    for (const [name, pop] of Object.entries(towns)) {
        console.log(`${name} : ${pop}`);
    }
}

calculate(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);