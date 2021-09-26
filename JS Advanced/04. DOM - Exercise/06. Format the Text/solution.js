function solve() {
    const text = document.getElementById('input').value;
    const splitted = text.split('.').filter((el) => el != '');
    let output = document.getElementById('output');

    for (let i = 0; i < splitted.length; i += 3) {
        let arr = [];
        for (let j = 0; j < 3; j++) {
            if (splitted[i + j]) {
                arr.push(splitted[i + j]);
            }
        }

        let paragraph = arr.join('. ') + '.';

        output.innerHTML += `<p>${paragraph}</p>`;
    }
}