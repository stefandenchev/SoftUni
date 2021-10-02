function process(input) {
    let result = [];

    const object = {
        add: word => result.push(word),
        remove: word => (result = result.filter(x => x !== word)),
        print: () => console.log(result.join(','))
    }

    input.forEach(element => {
        const [command, word] = element.split(' ');
        object[command](word);
    });
}

process(['add hello', 'add again', 'remove hello', 'add again', 'print']);