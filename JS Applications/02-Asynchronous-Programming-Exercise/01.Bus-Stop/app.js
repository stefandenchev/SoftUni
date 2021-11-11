async function getInfo() {

    let stopId = document.getElementById('stopId').value;
    let timeTable = document.getElementById('buses');

    let resultField = document.getElementById('stopName');

    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`

    try {
        timeTable.replaceChildren();
        const res = await fetch(url);

        if (res.status != 200) {
            throw new Error('Stop ID not found!')
        }

        const data = await res.json();

        resultField.textContent = data.name;

        Object.entries(data.buses).forEach(b => {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${b[0]} arrived in ${b[1]} minutes`;

            timeTable.appendChild(liElement);
        })
    } catch (error) {
        resultField.textContent = 'Error';
    }
}