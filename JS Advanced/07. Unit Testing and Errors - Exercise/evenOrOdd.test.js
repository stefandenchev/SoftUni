const { expect } = require('chai');
const { isOddOrEven } = require('./02. evenOrOdd');

describe('Odd or Even', () => {
    it('returns undefined if input is not a string', () => {
        expect(isOddOrEven(1)).to.equal(undefined);
    });

    it('returns even if input length is even', () => {
        expect(isOddOrEven('Adolin')).to.equal('even');
    });

    it('returns odd if input length is odd', () => {
        expect(isOddOrEven('Kaladin')).to.equal('odd');
    });
});