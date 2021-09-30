function addItem() {
    const inputText = document.getElementById('newItemText');
    const inputValue = document.getElementById('newItemValue');

    console.log(inputText, inputValue);

    const option = document.createElement('option');
    option.value = inputValue.value;
    option.textContent = inputText.value;

    const menu = document.getElementById('menu');
    menu.appendChild(option);

    inputText.value = '';
    inputValue.value = '';
}