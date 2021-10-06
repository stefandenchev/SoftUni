window.addEventListener('load', solution);

function solution() {
    let fullNameInput = document.getElementById('fname');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone');
    let addressInput = document.getElementById('address');
    let postalCodeInput = document.getElementById('code');

    let infoPreviewSection = document.getElementById('infoPreview');

    let submitButton = document.getElementById('submitBTN');
    submitButton.addEventListener('click', submit);

    let editButton = document.getElementById('editBTN');
    editButton.addEventListener('click', edit);
    let editClicked = false;

    let continueButton = document.getElementById('continueBTN');
    continueButton.addEventListener('click', complete);


    function submit(e) {
        let name = fullNameInput.value;
        let email = emailInput.value;
        let phone = phoneNumberInput.value;
        let address = addressInput.value;
        let code = postalCodeInput.value;

        let nameLi = document.createElement('li');
        nameLi.textContent = `Full Name: ${name}`;

        let emailLi = document.createElement('li');
        emailLi.textContent = `Email: ${email}`;

        let phoneLi = document.createElement('li');
        phoneLi.textContent = `Phone Number: ${phone}`;

        let addressLi = document.createElement('li');
        addressLi.textContent = `Address: ${address}`;

        let codeLi = document.createElement('li');
        codeLi.textContent = `Postal Code: ${code}`;

        if (name != '' && email != '') {
            infoPreviewSection.appendChild(nameLi);
            infoPreviewSection.appendChild(emailLi);
            infoPreviewSection.appendChild(phoneLi);
            infoPreviewSection.appendChild(addressLi);
            infoPreviewSection.appendChild(codeLi);

            fullNameInput.value = '';
            emailInput.value = '';
            phoneNumberInput.value = '';
            addressInput.value = '';
            postalCodeInput.value = '';

            submitButton.disabled = true;
            editButton.disabled = false;
            continueButton.disabled = false;

            editClicked = true;
        }
    }

    function edit() {
        let userInfoListItems = document.querySelectorAll('#infoPreview > li');

        let name = userInfoListItems[0].textContent.split(': ')[1];
        let email = userInfoListItems[1].textContent.split(': ')[1];
        let phone = userInfoListItems[2].textContent.split(': ')[1];
        let address = userInfoListItems[3].textContent.split(': ')[1];
        let code = userInfoListItems[4].textContent.split(': ')[1];

        fullNameInput.value = name;
        emailInput.value = email;
        phoneNumberInput.value = phone;
        addressInput.value = address;
        postalCodeInput.value = code;

        document.getElementById('infoPreview').innerHTML = "";

        submitButton.disabled = false;
        editButton.disabled = true;
        continueButton.disabled = true;
    }

    function complete() {
        let mainDiv = document.getElementById('block');
        mainDiv.innerHTML = "";

        let successMessage = document.createElement('h3');
        successMessage.textContent = 'Thank you for your reservation!';
        mainDiv.appendChild(successMessage);
    }
}