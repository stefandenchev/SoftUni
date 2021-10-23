window.addEventListener('load', solve);

function solve() {
    let genreInput = document.getElementById('genre');
    let nameInput = document.getElementById('name');
    let authorInput = document.getElementById('author');
    let dateInput = document.getElementById('date');

    let hitsContainer = document.getElementsByClassName('all-hits-container')[0];
    let savesContainer = document.getElementsByClassName('saved-container')[0];

    let likesCounter = document.querySelector('#total-likes > div > p');
    let likes = likesCounter.textContent.split(': ')[1];

    let addBtn = document.getElementById('add-btn');
    addBtn.addEventListener('click', addSong);

    function addSong(e) {
        e.preventDefault();

        let genre = genreInput.value;
        let name = nameInput.value;
        let author = authorInput.value;
        let date = dateInput.value;

        if (genre, name, author, date) {
            // song div
            let songDiv = document.createElement('div');
            songDiv.classList.add('hits-info');

            // image
            let image = document.createElement('img');
            image.src = './static/img/img.png';

            // genre
            let genreHead = document.createElement('h2');
            genreHead.textContent = `Genre: ${genre}`;

            // name
            let nameHead = document.createElement('h2');
            nameHead.textContent = `Name: ${name}`;

            // author
            let authorHead = document.createElement('h2');
            authorHead.textContent = `Author: ${author}`;

            // date
            let dateHead = document.createElement('h3');
            dateHead.textContent = `Date: ${date}`;

            // buttons
            let saveBtn = document.createElement('button');
            saveBtn.classList.add('save-btn');
            saveBtn.textContent = 'Save song';
            saveBtn.addEventListener('click', saveSong);

            let likeBtn = document.createElement('button');
            likeBtn.classList.add('like-btn');
            likeBtn.textContent = 'Like song';
            likeBtn.addEventListener('click', likeSong);

            let deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete-btn');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deleteSong);

            // append everything to the main div and then to the container
            songDiv.appendChild(image);
            songDiv.appendChild(genreHead);
            songDiv.appendChild(nameHead);
            songDiv.appendChild(authorHead);
            songDiv.appendChild(dateHead);
            songDiv.appendChild(saveBtn);
            songDiv.appendChild(likeBtn);
            songDiv.appendChild(deleteBtn);

            hitsContainer.appendChild(songDiv);

            // clear fields
            genreInput.value = '';
            nameInput.value = '';
            authorInput.value = '';
            dateInput.value = '';
        }
    }

    function likeSong(e) {
        e.target.disabled = true;
        let currLikes = parseInt(likesCounter.textContent.split(': ')[1]);
        currLikes++;
        likesCounter.textContent = `Total Likes: ${currLikes}`;
    }

    function saveSong(e) {
        let songDiv = e.target.parentElement;

        let firstBtn = e.target;
        let secondBtn = e.target.nextSibling;

        songDiv.removeChild(firstBtn);
        songDiv.removeChild(secondBtn);

        savesContainer.appendChild(songDiv);
    }

    function deleteSong(e) {
        e.target.parentElement.remove();
    }
}