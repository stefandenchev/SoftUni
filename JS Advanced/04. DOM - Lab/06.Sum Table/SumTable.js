function sumTable() {
    let result = 0;
    let rows = document.querySelectorAll('table tr');
    for (let i = 1; i < rows.length - 1; i++) {
        result += Number(rows[i].lastElementChild.textContent);
    }

    let sum = document.getElementById('sum');
    sum.textContent = result;
}