function sort(names) {
    names.sort((a, b) => a.localeCompare(b));
    let result = [];
    for (let i = 0; i < names.length; i++) {
        result.push(`${i + 1}.${names[i]}`);
    }
    return result.join('\n');
}

function sortWithMap(names) {
    let result = names
        .slice(0)
        .sort((a, b) => a.localeCompare(b))
        .map((name, index) => {
            let result = `${index + 1}.${name}`
            return result;
        });
        return result.join('\n');
}

console.log(sortWithMap(["John", "Bob", "Christina", "Ema"]));
console.log(sortWithMap(["Ab", "cd", "bc"]));