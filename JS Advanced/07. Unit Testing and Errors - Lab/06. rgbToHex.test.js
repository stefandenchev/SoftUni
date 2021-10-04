const { expect } = require('chai');
const { rgbToHexColor } = require('./06. rgbToHex');

describe('RGB Converter', () => {
    it('coverts white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal(`#FFFFFF`);
    });

    it('coverts black', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal(`#000000`);
    });
})