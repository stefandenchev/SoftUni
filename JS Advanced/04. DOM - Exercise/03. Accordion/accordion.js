function toggle() {
    const button = document.getElementsByClassName("button")[0];
    const extra = document.getElementById('extra');
    if (extra.style.display === "none") {
        extra.style.display = "block";
        button.textContent = 'Less';
    } else {
        extra.style.display = "none";
        button.textContent = 'More';
    }
}