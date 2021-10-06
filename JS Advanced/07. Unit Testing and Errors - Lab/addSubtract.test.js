const { expect } = require('chai');
const createCalculator = require('./07. addSubtract');

describe('Summator', () => {
    let instance = null;

    beforeEach(() => {
        instance = createCalculator();
    });

    it('has all methods', () => {
        expect(instance).to.have.ownProperty('add');
        expect(instance).to.have.ownProperty('subtract');
        expect(instance).to.have.ownProperty('get');
    });

    it('adds a single number', () => {
        instance.add(1);
        expect(instance.get()).to.equal(1);
    });

    it('adds multiple numbers', () => {
        instance.add(1);
        instance.add(2);
        expect(instance.get()).to.equal(3);
    });

    it('subtracts a single number', () => {
        instance.add(-1);
        expect(instance.get()).to.equal(-1);
    });

    it('subtracts multiple numbers', () => {
        instance.add(-1);
        instance.add(-2);
        expect(instance.get()).to.equal(-3);
    });

    it('adds and subtracts', () => {
        instance.add(1);
        instance.subtract(2);
        expect(instance.get()).to.equal(-1);
    });

    it('works with numbers as strings', () => {
        instance.add('1');
        instance.add('2');
        instance.subtract('4');
        expect(instance.get()).to.equal(-1);
    });

    it('starts empty', () => {
        expect(instance.get()).to.equal(0);
    });
})

