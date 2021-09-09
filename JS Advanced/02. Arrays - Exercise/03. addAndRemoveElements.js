function solve(commands) {
    let result = [];
    for (let i = 1; i <= commands.length; i++) {
        if (commands[i - 1] === "add") {
            result.push(i);
        } else {
            result.pop();
        }
    }

    return result.length != 0 ? result.join('\n') : "Empty";
}

console.log(solve(['add',
    'add',
    'remove',
    'add',
    'add']
));

console.log(solve(['remove',
    'remove',
    'remove']
));