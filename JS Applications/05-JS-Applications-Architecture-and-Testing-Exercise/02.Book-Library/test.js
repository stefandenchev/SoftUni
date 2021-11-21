const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
        "author": "J.K.Rowling",
        "title": "Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
        "author": "Svetlin Nakov",
        "title": "C# Fundamentals"
    }
};

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    };
}

describe('Tests', async function() {
    this.timeout(5000);

    let page, browser;

    before(async() => {
        browser = await chromium.launch();
    });

    after(async() => {
        browser = await browser.close();
    });

    beforeEach(async() => {
        page = await browser.newPage();
    });

    afterEach(async() => {
        await page.close();
    });

    it('loads and displays all books', async() => {
        await page.route('**/jsonstore/collections/books*', (route) => {
            route.fulfill(json(mockData));
        });
        await page.goto('http://localhost:5500');
        await page.click('text=Load All Books');
        await page.waitForSelector('text=Harry Potter');

        const rows = await page.$$eval('tr', (rows) => rows.map(r => r.textContent.trim()));

        expect(rows[1]).to.contain('Harry Potter');
        expect(rows[1]).to.contain('Rowling');
        expect(rows[2]).to.contain('C# Fundamentals');
        expect(rows[2]).to.contain('Nakov');
    });

    it('can create book', async() => {
        await page.goto('http://localhost:5500');

        await page.fill('form#createForm >> input[name=title]', 'Title');
        await page.fill('form#createForm >> input[name=author]', 'Author');

        const [request] = await Promise.all([
            page.waitForRequest(request => request.method() == 'POST'),
            page.click('form#createForm >> text=Submit')
        ]);

        const data = JSON.parse(request.postData());
        expect(data.title).to.equal('Title');
        expect(data.author).to.equal('Author');
    });

    it('edit book', async() => {
        await page.goto('http://localhost:5500');
        await Promise.all([
            page.click('text=LOAD ALL BOOKS'),
            page.click('.editBtn'),
        ]);

        const visible = await page.isVisible('#editForm');
        expect(visible).to.be.true;

        await page.fill('#editForm input[name="title"]', 'Edited');
        await page.click('text=Save');
        await page.click('text=LOAD ALL BOOKS');
        const content = await page.textContent('table tbody');
        expect(content).to.contain('Edited');
    });

    it('delete book', async() => {
        await page.goto('http://localhost:5500');
        await Promise.all([
            page.click('text=LOAD ALL BOOKS'),
            page.click('.deleteBtn'),
            page.on('dialog', dialog => dialog.accept())
        ]);

        await page.click('text=LOAD ALL BOOKS');
        const content = await page.textContent('table tbody');
        expect(content).not.to.contain('J.K.Rowling');
    });
});