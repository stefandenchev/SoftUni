function solve() {
    const [name, hall, ticketPrice] = document.querySelectorAll('#container input');
    const onScreenBtn = document.querySelector('#container button');
    const movieSection = document.querySelector('#movies ul');
    const archiveSection = document.querySelector('#archive ul');
    const clearBtn = archiveSection.parentElement.querySelector('button');

    onScreenBtn.addEventListener('click', addMovie);
    clearBtn.addEventListener('click', clearAll);

    function addMovie(e) {
        e.preventDefault();
        if (name.value != '' && hall.value != '' && ticketPrice.value != '' && !isNaN(Number(ticketPrice.value))) {
            const movie = document.createElement('li');

            movie.innerHTML =
                `<span>${name.value}</span>
             <strong>Hall: ${hall.value}</strong>
             <div>
                <strong>${Number(ticketPrice.value).toFixed(2)}</strong>
                <input placeholder="Tickets Sold">
                <button onclick='addToArchive'>Archive</button>
            </div>`;

            movieSection.appendChild(movie);

            const button = movie.querySelector('div button');
            button.addEventListener('click', addToArchive);

            name.value = '';
            hall.value = '';
            ticketPrice.value = '';

            // const movieName = document.createElement('span');
            // movieName.textContent = name.value;

            // const movieHall = document.createElement('strong');
            // movieHall.textContent = hall.value;

            // const priceSection = document.createElement('div');
            // const moviePrice = document.createElement('strong');
            // moviePrice.textContent = ticket.value;

            // const priceInput = document.createElement('input');
            // const archiveButton = document.createElement('button');

            // priceSection.appendChild(priceInput);
            // priceSection.appendChild(archiveButton);

            // movie.appendChild(movieName);
            // movie.appendChild(movieHall);
            // movie.appendChild(priceSection);

            // movies.appendChild(movie);
        }
    }

    function addToArchive(e) {
        const inputValue = e.target.parentElement.querySelector('input');
        const price = e.target.parentElement.querySelector('strong');
        const movieName = e.target.parentElement.parentElement.querySelector('span');

        if (inputValue.value != '' && !isNaN(inputValue.value)) {
            const income = Number(inputValue.value) * Number(price.textContent);

            const li = document.createElement('li');
            li.innerHTML = `<span>${movieName.textContent}</span>
                            <strong>Total amount: ${income.toFixed(2)}</strong>
                            <button>Delete</button>`;

            const button = li.querySelector('button');
            button.addEventListener('click', deleteEntry);
            archiveSection.appendChild(li);
        }

        e.target.parentElement.parentElement.remove();
    }

    function deleteEntry(e) {
        e.target.parentElement.remove();
    }

    function clearAll(e) {
        archiveSection.innerHTML = '';
    }

    return addMovie;
}