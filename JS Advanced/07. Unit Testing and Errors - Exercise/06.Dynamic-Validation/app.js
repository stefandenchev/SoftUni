function validate() {
    const inputField = document.getElementById('email');
    const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

    inputField.addEventListener('change', () => {
        if (!regex.test(inputField.value)) {
            inputField.classList.add('error');
        } else {
            inputField.classList.remove('error');
        }
    });
}