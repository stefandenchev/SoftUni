const { expect } = require('chai');
const { mathEnforcer } = require('./04. mathEnforcer');

describe('Math Enforcer', () => {
    describe('addFive', () => {
        it('returns undefined if input is not a number', () => {
            expect(mathEnforcer.addFive('epic')).to.equal(undefined);
        });

        it('returns correct result when input is a number', () => {
            expect(mathEnforcer.addFive(18)).to.equal(23);
            expect(mathEnforcer.addFive(-18)).to.equal(-13);
            expect(mathEnforcer.addFive(18.1)).to.be.closeTo(23.1, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('returns undefined if input is not a number', () => {
            expect(mathEnforcer.subtractTen('epic')).to.equal(undefined);
        });

        it('returns correct result when input is a number', () => {
            expect(mathEnforcer.subtractTen(23)).to.equal(13);
            expect(mathEnforcer.subtractTen(-23)).to.equal(-33);
            expect(mathEnforcer.subtractTen(23.1)).to.be.closeTo(13.1, 0.01);
        });
    });


    describe('sum', () => {
        it('returns undefined if one of the inputs is not a number', () => {
            expect(mathEnforcer.sum('epic', 1)).to.equal(undefined);
            expect(mathEnforcer.sum(1, 'epic')).to.equal(undefined);
        });

        it('returns correct result when both inputs are numbers', () => {
            expect(mathEnforcer.sum(10, 13)).to.equal(23);
            expect(mathEnforcer.sum(10.1, 13.1)).to.be.closeTo(23.2, 0.01);
        });
    });
});