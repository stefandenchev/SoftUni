const { expect } = require('chai');
const { lookupChar } = require('./03. charLookup');

describe('Character Lookup', () => {
    it('returns undefined if one of the inputs is not in the correct type', () => {
        expect(lookupChar(1, 1)).to.equal(undefined);
        expect(lookupChar('Stormblessed', '1')).to.equal(undefined);
        expect(lookupChar('1', 1.2)).to.equal(undefined);
    });

    it('returns Incorrect index if both types are correct but index is out of range', () => {
        expect(lookupChar('Stormblessed', 23)).to.equal('Incorrect index');
        expect(lookupChar('Stormblessed', -1)).to.equal('Incorrect index');
    });

    it('returns the right character when input is correct', () => {
        expect(lookupChar('Stormblessed', 9)).to.equal('s');
    });
});