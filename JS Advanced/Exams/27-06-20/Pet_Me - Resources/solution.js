function solve() {
    let nameDiv = document.querySelectorAll('input')[0];
    let ageDiv = document.querySelectorAll('input')[1];
    let kindDiv = document.querySelectorAll('input')[2];
    let ownerDiv = document.querySelectorAll('input')[3];

    let adoptionList = document.querySelector('#adoption > ul');
    let adoptedList = document.querySelector('#adopted > ul');

    let addBtn = document.querySelector('button');
    addBtn.addEventListener('click', addAnimal);

    function addAnimal(e) {
        e.preventDefault();
        let name = nameDiv.value;
        let age = ageDiv.value;
        let kind = kindDiv.value;
        let owner = ownerDiv.value;

        if (name && age && kind && owner && !isNaN(age)) {
            let petLi = document.createElement('li');
            let petPara = document.createElement('p');
            petLi.appendChild(petPara);

            let petName = document.createElement('strong');
            petName.textContent = name;
            petPara.appendChild(petName);
            var text1 = document.createTextNode(" is a ");
            petPara.appendChild(text1);

            let petAge = document.createElement('strong');
            petAge.textContent = age;
            petPara.appendChild(petAge);
            var text2 = document.createTextNode(" year old ");
            petPara.appendChild(text2);

            let petKind = document.createElement('strong');
            petKind.textContent = kind;
            petPara.appendChild(petKind);

            let petOwner = document.createElement('span');
            petOwner.textContent = `Owner: ${owner}`;
            petLi.appendChild(petOwner);

            adoptionList.appendChild(petLi);

            contactBtn = document.createElement('button');
            contactBtn.textContent = 'Contact with owner';
            petLi.appendChild(contactBtn);

            contactBtn.addEventListener('click', contact);
            nameDiv.value = '';
            ageDiv.value = '';
            kindDiv.value = '';
            ownerDiv.value = '';

            function contact(e) {

                contactBtn.textContent = 'Yes! I take it!'
                let newInput = document.createElement('input');
                newInput.placeholder = 'Enter your names';
                let adoptDiv = document.createElement('div');
                adoptDiv.appendChild(newInput);
                adoptDiv.appendChild(contactBtn);
                petLi.appendChild(adoptDiv);
                contactBtn.removeEventListener('click', contact);
                contactBtn.addEventListener('click', confirm);

                function confirm(e) {
                    let newOwnerName = newInput.value;
                    petLi.removeChild(adoptDiv);

                    petOwner.textContent = `New Owner: ${newOwnerName}`;
                    if (newOwnerName) {
                        adoptionList.removeChild(petLi);
                        adoptedList.appendChild(petLi);
                        petLi.appendChild(contactBtn);
                        e.target.textContent = 'Checked'
                        contactBtn.removeEventListener('click', confirm);
                        contactBtn.addEventListener('click', remove);

                        function remove(e) {
                            adoptedList.removeChild(petLi);
                        }
                    }
                }
            }

        }
    }

}
