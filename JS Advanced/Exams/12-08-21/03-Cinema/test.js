const { expect } = require('chai');
const cinema = require('./cinema.js');

describe('Cinema Tests', () => {
    describe('Tests for Show Movies functionality', () => {
        it('returns correct message if there are no movies/empty array', () => {
            expect(cinema.showMovies([])).to.equal(`There are currently no movies to show.`);
        });
        it('returns movies in correct format if there are 1 movie in the input array', () => {
            expect(cinema.showMovies(['John Wick'])).to.equal('John Wick');
        });
        it('returns movies in correct format if there are 2 or more in the input array', () => {
            expect(cinema.showMovies(['John Wick', 'Return of the king'])).to.equal('John Wick, Return of the king');
        });
    });

    describe('Tests for Ticket Price functionality', () => {
        it('returns correct message if the movie projection is a premiere', () => {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
        });
        it('returns correct message if the movie projection is normal', () => {
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
        });
        it('returns correct message if the movie projection is discounted', () => {
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
        });

        it('returns correct message if the movie projection does not exist', () => {
            expect(() => cinema.ticketPrice('Stormlight')).to.throw('Invalid projection type.');
        });

        it('returns correct message if the movie projection is an empty string', () => {
            expect(() => cinema.ticketPrice('')).to.throw('Invalid projection type.');
        });
    });

    describe('Tests for Swap Seats functionality', () => {
        it('returns success message if input is valid', () => {
            expect(cinema.swapSeatsInHall(5, 10)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 20)).to.equal('Successful change of seats in the hall.');0
        });

        it('returns error message if input is valid', () => {
            expect(cinema.swapSeatsInHall(1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(22.5, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(22, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-1, 2)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(0, 5)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(5, 5)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(23, 24)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall('null', null)).to.equal('Unsuccessful change of seats in the hall.');
        });
    })
});