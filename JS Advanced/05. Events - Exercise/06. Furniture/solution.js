function solve1() {
    const table = document.querySelector('table.table tbody');
    const [input, output] = Array.from(document.querySelectorAll('textarea'));
    const [generateBtn, buyBtn] = Array.from(document.querySelectorAll('button'));

    generateBtn.addEventListener('click', generate);
    buyBtn.addEventListener('click', buy);

    function generate(e) {
        const data = JSON.parse(input.value);

        for (const item of data) {
            const row = document.createElement('tr');

            const imageCell = document.createElement('td');
            const nameCell = document.createElement('td');
            const priceCell = document.createElement('td');
            const decFactorCell = document.createElement('td');
            const checkCell = document.createElement('td');

            const img = document.createElement('img');
            img.src = item.img;
            imageCell.appendChild(img);

            const nameP = document.createElement('p');
            nameP.textContent = item.name;
            nameCell.appendChild(nameP);

            const priceP = document.createElement('p');
            priceP.textContent = item.price;
            priceCell.appendChild(priceP);

            const decP = document.createElement('p');
            decP.textContent = item.decFactor;
            decFactorCell.appendChild(decP);

            const check = document.createElement('input');
            check.type = 'checkbox';
            checkCell.appendChild(check);

            row.appendChild(imageCell);
            row.appendChild(nameCell);
            row.appendChild(priceCell);
            row.appendChild(decFactorCell);
            row.appendChild(checkCell);

            table.appendChild(row);
        }
    }

    function buy(e) {
        const furniture = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
            .map(box => box.parentElement.parentElement)
            .map(r => ({
                name: r.children[1].textContent,
                price: Number(r.children[2].textContent),
                decFactor: Number(r.children[3].textContent)
            }));

        const names = [];
        let total = 0;
        let decFactor = 0;

        for (const item of furniture) {
            names.push(item.name);
            total += item.price;
            decFactor += item.decFactor;
        }

        const result = `Bought furniture: ${names.join(', ')}
Total price: ${total.toFixed(2)}
Average decoration factor: ${decFactor / furniture.length}`;

        output.value = result;
    }
}

/////////////////////////////////////////////////

function solve() {
    const table = document.querySelector('table.table tbody');
    const [input, output] = Array.from(document.querySelectorAll('textarea'));
    const [generateBtn, buyBtn] = Array.from(document.querySelectorAll('button'));

    generateBtn.addEventListener('click', generate);
    buyBtn.addEventListener('click', buy);

    function generate(e) {
        const data = JSON.parse(input.value);

        for (const item of data) {
            const row = document.createElement('tr');

            row.appendChild(createCell('img', { src: item.img }));
            row.appendChild(createCell('p', {}, item.name));
            row.appendChild(createCell('p', {}, item.price));
            row.appendChild(createCell('p', {}, item.decFactor));
            row.appendChild(createCell('input', { type: 'checkbox' }));

            table.appendChild(row);
        }
    }

    function createCell(nestedTag, props, content) {
        const cell = document.createElement('td');
        const nested = document.createElement(nestedTag);

        for (let prop in props) {
            nested[prop] = props[prop];
        }

        if (content) {
            nested.textContent = content;
        }

        cell.appendChild(nested);
        return cell;
    }

    function buy(e) {
        const furniture = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
            .map(box => box.parentElement.parentElement)
            .map(r => ({
                name: r.children[1].textContent,
                price: Number(r.children[2].textContent),
                decFactor: Number(r.children[3].textContent)
            }))
            .reduce((acc, curr, i, a) => {
                acc.names.push(curr.name);
                acc.total += curr.price;
                acc.decFactor += curr.decFactor / a.length;
                return acc;
            }, { names: [], total: 0, decFactor: 0 })

        const result = `Bought furniture: ${furniture.names.join(', ')}
Total price: ${furniture.total.toFixed(2)}
Average decoration factor: ${furniture.decFactor}`;

        output.value = result;
    }
}