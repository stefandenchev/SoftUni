function tickets(tickets, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let result = [];

    for (const entry of tickets) {
        let [destination, price, status] = entry.split('|');
        result.push(new Ticket(destination, Number(price), status));
    }

    if (criteria == 'destination') {
        result.sort((a, b) => {
            return a.destination.localeCompare(b.destination);
        })
    } else if (criteria == 'status') {
        result.sort((a, b) => {
            return a.status.localeCompare(b.status);
        })
    } else {
        result.sort((a, b) => {
            return a.price - b.price;
        })
    }

    return result;
}

console.log(tickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));