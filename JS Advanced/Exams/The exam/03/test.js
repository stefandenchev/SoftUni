const { expect } = require('chai');
const library = require('./library');

describe('Tests For Library', () => {
    describe('CalcPriceOfBook', () => {
        it('Book should cost 10 if publish year is 1980 or earlier', () => {
            expect(library.calcPriceOfBook('Words of Radiance', 1980)).to.equal(`Price of Words of Radiance is 10.00`);
            expect(library.calcPriceOfBook('Words of Radiance', 1979)).to.equal(`Price of Words of Radiance is 10.00`);
        });
        it('Book should cost 20 if publish year is 1981 or after', () => {
            expect(library.calcPriceOfBook('Words of Radiance', 1981)).to.equal(`Price of Words of Radiance is 20.00`);
            expect(library.calcPriceOfBook('Words of Radiance', 2014)).to.equal(`Price of Words of Radiance is 20.00`);
        });
        it('Error should be thrown if there is invalid input', () => {
            expect(() => library.calcPriceOfBook( 1, 1981)).to.throw(`Invalid input`);
            expect(() => library.calcPriceOfBook('Words of Radiance', '2014')).to.throw(`Invalid input`);
        });
    });

    describe('FindBook', () => {
        it('Error should be thrown if there are no books available', () => {
            expect(() => library.findBook([], 'Way Of Kings')).to.throw("No books currently available");
        });
        it('Correct message should be returned if the book is present in the input array', () => {
            expect(library.findBook(['Way Of Kings', 'Oathbringer'], 'Way Of Kings')).to.equal("We found the book you want.");
        });
        it('Correct message should be returned if the book is NOT present in the input array', () => {
            expect(library.findBook(['Way Of Kings', 'Oathbringer'], 'Rhythm Of War')).to.equal("The book you are looking for is not here!");
        });
    });

    describe('ArrangeTheBooks', () => {
        it('Error should be thrown if there is invalid input', () => {
            expect(() => library.arrangeTheBooks(-1)).to.throw(`Invalid input`);
            expect(() => library.arrangeTheBooks('1')).to.throw(`Invalid input`);
            expect(() => library.arrangeTheBooks([])).to.throw(`Invalid input`);
            expect(() => library.arrangeTheBooks({})).to.throw(`Invalid input`);
            expect(() => library.arrangeTheBooks(false)).to.throw(`Invalid input`);
        });

        it('Success message should be returned if there is enough space for all books', () => {
            expect(library.arrangeTheBooks(39)).to.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(40)).to.equal("Great job, the books are arranged.");
        });

        it('Fail message should be returned if there is enough space for all books', () => {
            expect(library.arrangeTheBooks(41)).to.equal("Insufficient space, more shelves need to be purchased.");
        });
    });
});

