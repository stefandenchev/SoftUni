const { expect } = require('chai');
const testNumbers = require('./testNumbers');

describe('Test Numbers', () => {
    describe('Sum Numbers', () => {
        it('returns undefined if one of the inputs is not a number', () => {
            expect(testNumbers.sumNumbers(1, '1')).to.equal(undefined);
            expect(testNumbers.sumNumbers('1', 1.2)).to.equal(undefined);
            expect(testNumbers.sumNumbers({}, 1.2)).to.equal(undefined);
            expect(testNumbers.sumNumbers('1', false)).to.equal(undefined);
        });

        it('returns correct result if both inputs are numbers', () => {
            expect(testNumbers.sumNumbers(2, 2)).to.equal('4.00');
            expect(testNumbers.sumNumbers(23.1, 1.2)).to.equal('24.30');
        });
    });

    describe('Number Checker', () => {
        it('throws error if the input is not a number', () => {
            expect(() => testNumbers.numberChecker({})).to.throw('The input is not a number!');
            expect(() => testNumbers.numberChecker({ 'name': 'Kaladin' })).to.throw('The input is not a number!');

        });

        it('returns even if the number is even', () => {
            expect(testNumbers.numberChecker(2)).to.equal('The number is even!');
            expect(testNumbers.numberChecker('2')).to.equal('The number is even!');
        });

        it('returns odd if the number is odd', () => {
            expect(testNumbers.numberChecker(3)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker('3')).to.equal('The number is odd!');
        });
    });

    describe('Average Sum Array', () => {
        it('returns correct result with whole numbers', () => {
            expect(testNumbers.averageSumArray([1, 2, 3])).to.equal(2);
        });

        it('returns correct result with floating point numbers', () => {
            expect(testNumbers.averageSumArray([1.1, 2.2, 3.3])).to.be.closeTo(2.2, 0.01);
        });

    });
});