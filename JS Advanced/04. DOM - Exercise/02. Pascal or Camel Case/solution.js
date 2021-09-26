function solve() {
    let text = document.getElementById('text').value;
    let currCase = document.getElementById('naming-convention').value;
    let resultContainer = document.getElementById('result');

    let splitted = text.split(' ');
    let result = '';

    if (currCase == 'Camel Case') {
        result += splitted[0][0].toLowerCase()
            + splitted[0].slice(1, splitted[0].length).toLowerCase();

        for (let i = 1; i < splitted.length; i++) {
            result += splitted[i][0].toUpperCase() +
                splitted[i].slice(1, splitted[i].length).toLowerCase();
        }

        resultContainer.textContent = result;

    }
    else if (currCase == 'Pascal Case') {
        for (let i = 0; i < splitted.length; i++) {
            result += splitted[i][0].toUpperCase() +
                splitted[i].slice(1, splitted[i].length).toLowerCase();
        }

        resultContainer.textContent = result;
    }
    else {
        resultContainer.textContent = 'Error!';
    }

}