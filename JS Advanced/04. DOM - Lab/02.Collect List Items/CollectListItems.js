function extractText() {
    const items = document.getElementById('items').children;
    // const items = document.querySelectorAll('#items li');

    let result = [...Array.from(items)].map(e => e.textContent).join('\n');

    document.getElementById('result').textContent = result;
}