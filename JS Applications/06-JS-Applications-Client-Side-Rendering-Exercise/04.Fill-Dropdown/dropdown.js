import { html, render } from './node_modules/lit-html/lit-html.js';

const selectTemplate = (items) => html `
<select id="menu">
    ${items.map(i => html`<option value=${i._id}>${i.text}</option>`)}
</select>`

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const root = document.querySelector('div');
document.querySelector('form').addEventListener('submit', addItem);
getData();

// getData
async function getData() {
    const res = await fetch(url);
    const data = await res.json();

    update(Object.values(data));
}

// update
function update(items) {
    const result = selectTemplate(items);
    render(result, root);
}

// add
async function addItem(e) {
    e.preventDefault();
    const text = document.getElementById('itemText').value;

    const item = {
        text
    };

    const res = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    });

    if (res.ok) {
        document.getElementById('itemText').value = '';
        getData();
    }
}