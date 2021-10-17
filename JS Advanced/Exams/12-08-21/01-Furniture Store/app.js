window.addEventListener('load', solve);

function solve() {
    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', add);

    let modelInput = document.getElementById('model');
    let yearInput = document.getElementById('year');
    let descriptionInput = document.getElementById('description');
    let priceInput = document.getElementById('price');

    let totalPrice = document.querySelector(".total-price");

    function add(e) {
        e.preventDefault();

        let model = modelInput.value;
        let year = Number(yearInput.value);
        let description = descriptionInput.value;
        let price = Number(priceInput.value);

        if (model && year && description && price && year > 0 && price > 0) {
            let itemTr = document.createElement('tr');

            let modelTd = document.createElement('td');
            modelTd.textContent = model;

            let priceTd = document.createElement('td');
            priceTd.textContent = price.toFixed(2);

            let yearTd = document.createElement('td');
            yearTd.textContent = `Year: ${year}`;

            let descriptionTd = document.createElement('td');
            descriptionTd.colSpan = 3;
            descriptionTd.textContent = `Description: ${description}`;

            let buttonsTd = document.createElement('td');

            let infoBtn = document.createElement('button');
            infoBtn.classList.add('moreBtn');
            infoBtn.textContent = 'More Info';

            let buyBtn = document.createElement('button');
            buyBtn.classList.add('buyBtn');
            buyBtn.textContent = 'Buy it';

            buttonsTd.appendChild(infoBtn);
            buttonsTd.appendChild(buyBtn);

            itemTr.appendChild(modelTd);
            itemTr.appendChild(priceTd);

            itemTr.appendChild(buttonsTd);

            let furnitureList = document.getElementById('furniture-list');
            furnitureList.appendChild(itemTr);

            let hideTr = document.createElement('tr');
            hideTr.classList.add('hide');
            hideTr.appendChild(yearTd);
            hideTr.appendChild(descriptionTd);

            furnitureList.appendChild(hideTr);

            infoBtn.addEventListener('click', toggleInfo);
            buyBtn.addEventListener('click', buy);

            modelInput.value = '';
            yearInput.value = '';
            descriptionInput.value = '';
            priceInput.value = '';
        }
    }

    function toggleInfo(e) {
        const moreInfo = e.target.parentElement.parentElement.nextElementSibling;
        if (e.target.textContent == "More Info") {
            e.target.textContent = "Less Info";
            moreInfo.style.display = "contents";
        } else {
            e.target.textContent = "More Info";
            moreInfo.style.display = "none";
        }
    }

    function buy(e) {
        let item = e.target.parentElement.parentElement;
        let list = document.getElementById('furniture-list');

        const price = Number(item.querySelectorAll("td")[1].textContent);
        totalPrice.textContent = (Number(totalPrice.textContent) + price).toFixed(2);

        list.removeChild(item);
    }

}
