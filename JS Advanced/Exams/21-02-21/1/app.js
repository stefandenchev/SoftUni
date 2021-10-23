function solve() {
    let authorField = document.getElementById('creator');
    let titleField = document.getElementById('title');
    let categoryField = document.getElementById('category');
    let contentField = document.getElementById('content');

    let postsSection = document.getElementsByTagName('section')[1];
    let archiveSection = document.getElementsByTagName('section')[3];

    let createBtn = document.getElementsByClassName('btn create')[0];
    createBtn.addEventListener('click', createPost);

    function createPost(e) {
        e.preventDefault();
        let author = authorField.value;
        let title = titleField.value;
        let category = categoryField.value;
        let content = contentField.value;

        if (author, title, category, content) {
            // create article body
            let article = document.createElement('article');

            // create title body
            let titleHead = document.createElement('h1');
            titleHead.textContent = title;

            // create category paragraph and add its title
            let categoryPara = document.createElement('p');
            categoryPara.textContent = 'Category: ';
            let categoryParaName = document.createElement('strong');
            categoryParaName.textContent = category;
            categoryPara.appendChild(categoryParaName);

            // create creator paragraph and add its title
            let creatorPara = document.createElement('p');
            creatorPara.textContent = 'Creator: ';
            let creatorParaName = document.createElement('strong');
            creatorParaName.textContent = author;
            creatorPara.appendChild(creatorParaName);

            // create content paragraph
            let contentPara = document.createElement('p');
            contentPara.textContent = content;

            // create div for the two buttons and add them
            let buttonsDiv = document.createElement('div');
            buttonsDiv.classList.add('buttons');

            let btnDelete = document.createElement('button');
            btnDelete.classList.add('btn', 'delete');
            btnDelete.textContent = 'Delete';

            let btnArchive = document.createElement('button');
            btnArchive.classList.add('btn', 'archive');
            btnArchive.textContent = 'Archive';

            buttonsDiv.appendChild(btnDelete);
            buttonsDiv.appendChild(btnArchive);

            // append all elements to the article and then it to the posts sections, clear input values
            article.appendChild(titleHead);
            article.appendChild(categoryPara);
            article.appendChild(creatorPara);
            article.appendChild(contentPara);
            article.appendChild(buttonsDiv);
            postsSection.appendChild(article);

            authorField.value = '';
            titleField.value = '';
            categoryField.value = '';
            contentField.value = '';

            btnDelete.addEventListener('click', deletePost);
            btnArchive.addEventListener('click', archivePost);
        }
    }

    function deletePost(e) {
        e.target.parentElement.parentElement.remove();
    }

    function archivePost(e) {
        e.target.parentElement.parentElement.remove();
        let title = e.target.parentElement.parentElement.firstChild.textContent;
        let archiveList = document.getElementsByTagName('ol')[0];

        let titleLi = document.createElement('li');
        titleLi.textContent = title;
        archiveList.appendChild(titleLi);

        [...archiveList.children]
            .sort((a, b) => a.innerText > b.innerText ? 1 : -1)
            .forEach(node => archiveList.appendChild(node));
    }

}


