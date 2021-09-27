function addItem() {
    let text = document.getElementById('newItemText');
    let item = document.createElement('li');
    item.textContent = text.value;

    document.getElementById('items').appendChild(item);
    text.value = '';
}