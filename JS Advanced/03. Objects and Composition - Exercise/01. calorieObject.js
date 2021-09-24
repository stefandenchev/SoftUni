function construction(properties) {
    let result = {};
    for (let i = 0; i < properties.length; i++) {
        if (i % 2 == 0) {
            result[properties[i]] = properties[i];
        }
        else {
            result[properties[i - 1]] = Number(properties[i]);
        }
    }
    return result;
}

console.log(construction(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']))