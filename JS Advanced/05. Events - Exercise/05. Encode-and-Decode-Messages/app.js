function encodeAndDecodeMessages() {
    const encodeBtn = document.querySelectorAll('button')[0];
    const decodeBtn = document.querySelectorAll('button')[1];
    let initialMessage = document.querySelectorAll('textarea')[0];
    let receivedMessage = document.querySelectorAll('textarea')[1];

    encodeBtn.addEventListener('click', encode);
    decodeBtn.addEventListener('click', decode);

    let encodedMsg = '';
    let decodedMsg = '';

    function encode(e) {
        for (let letter of initialMessage.value) {
            encodedMsg += nextChar(letter);
        }
        receivedMessage.value = encodedMsg;
        initialMessage.value = '';
        encodedMsg = '';
    }

    function decode(e) {
        for (let letter of receivedMessage.value) {
            decodedMsg += prevChar(letter);
        }
        initialMessage.value = decodedMsg;
        receivedMessage.value = '';
        decodedMsg = '';
    }

    function nextChar(c) {
        return String.fromCharCode(c.charCodeAt() + 1);
    }

    function prevChar(c) {
        return String.fromCharCode(c.charCodeAt() - 1);
    }
}


function encodeAndDecodeMessagesEpic() {
    const [encodeField, decodeField] = document.querySelectorAll("textarea")

    const transform = (str, type) =>
        str
            .split("")
            .map(x =>
                String.fromCharCode(
                    type === "encode"
                        ? x.charCodeAt(0) + 1
                        : x.charCodeAt(0) - 1
                )
            )
            .join("");

    document.addEventListener("click", e => {
        if (e.target.tagName === "BUTTON") {
            if (e.target.textContent.includes("Encode")) {
                decodeField.value = transform(encodeField.value, "encode");
                encodeField.value = ""
            } else {
                decodeField.value = transform(decodeField.value, "decode");
            }
        }
    })
}

// Selecting DOM elements
const element = document.getElementById('content');
document.querySelector('#content');
document.querySelectorAll('ul li');

// Get/Set content
element.textContent;
element.value;

// Traversing DOM
element.parentElement;
element.children;

// Create element
const para = document.createElement('p');

// Adding to DOM
element.appendChild(para);

// Removing from DOM
para.remove();

// Events
element.addEventListener('click', e => {
    console.log(e.target);
});