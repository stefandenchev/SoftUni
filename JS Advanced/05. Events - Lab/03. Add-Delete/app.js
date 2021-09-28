function addItem() {
    let text = document.getElementById('newItemText');
    let item = document.createElement('li');
    item.textContent = text.value;

    const button = document.createElement('a');
    button.href = '#';
    button.textContent = '[Delete]';
    button.addEventListener('click', removeElement);

    item.appendChild(button);

    document.getElementById('items').appendChild(item);
    text.value = '';

    function removeElement(ev) {
        ev.target.parentNode.remove();
    }
}