function townsToJson(towns) {
    let result = [];
    const elements = towns[0].split('|');
    const town = elements[1].trim();
    const latitude = elements[2].trim();
    const longitude = elements[3].trim();
    for (let i = 1; i < towns.length; i++) {
        const obj = {};
        const split = towns[i].split('|');
            obj[town] = split[1].trim();
            obj[latitude] = Number(Number(split[2].trim()).toFixed(2));
            obj[longitude] = Number(Number(split[3].trim()).toFixed(2));
            result.push(obj);
    }
    return JSON.stringify(result);
}

console.log(townsToJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));