function validate() {
    userRegex = /^[A-Za-z0-9]{3,20}$/;
    passRegex = /^\w{5,15}$/;
    emailRegex = /^.*@.*\..*$/;

    let submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', validateFormHandler);
    let isCompanyCheckbox = document.getElementById('company');
    isCompanyCheckbox.addEventListener('change', companyHandler);

    function validateFormHandler(e) {
        e.preventDefault();

        let userNameField = document.getElementById('username');
        let userNameIsValid = userRegex.test(userNameField.value);
        setBorder(userNameField, userNameIsValid);

        let emailField = document.getElementById('email');
        let emailIsValid = emailRegex.test(emailField.value);
        setBorder(emailField, emailIsValid);

        let passwordField = document.getElementById('password');
        let confPasswordField = document.getElementById('confirm-password');

        let passworkIsValid = passRegex.test(passwordField.value);
        let passwordsAreOk = passworkIsValid && passwordField.value === confPasswordField.value;

        setBorder(passwordField, passwordsAreOk);
        setBorder(confPasswordField, passwordsAreOk);

        let companyNumberIsValid = false;
        let isCompanyCheckbox = document.getElementById('company');
        if (isCompanyCheckbox.checked) {
            let companyNumberInput = document.getElementById('companyNumber');
            if (companyNumberInput.value.trim() !== '' && !isNaN(Number(companyNumberInput.value))) {
                let companyNumber = Number(companyNumberInput.value);
                if (companyNumber >= 1000 && companyNumber <= 9999) {
                    companyNumberIsValid = true;
                }
            }

            setBorder(companyNumberInput, companyNumberIsValid);
        }

        let validDiv = document.getElementById('valid');
        let mainInputsAreValid = userNameIsValid && emailIsValid && passwordsAreOk;
        let companyInfoIsValid = !isCompanyCheckbox.checked || (isCompanyCheckbox.checked && companyNumberIsValid);
        let showValid = mainInputsAreValid && companyInfoIsValid;

        validDiv.style.display = showValid ? 'block' : 'none';
    };

    function companyHandler(e) {
        let companyInfo = document.getElementById('companyInfo');
        companyInfo.style.display = e.target.checked ? 'block' : 'none';
    }

    function setBorder(element, isValid) {
        if (isValid) {
            element.style.setProperty('border', 'none');
        } else {
            element.style.setProperty('border', '2px solid red');
        }
    }
}