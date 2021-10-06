const { expect } = require('chai');
const sum = require('./04. sumOfNumbers');

describe('Sum Checker', () => {
    it('it sums correctly with one number', () => {
        expect(sum([1])).to.equal(1);
    });

    it('it sums correctly with multiple numbers', () => {
        expect(sum([1, 2, 3])).to.equal(6);
    });
})