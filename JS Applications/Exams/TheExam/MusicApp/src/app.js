import { page, render } from './lib.js';
import { logout } from './api/api.js';
import { getUserData } from './util.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { searchPage } from './views/search.js';

const root = document.getElementById('main-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/catalog', catalogPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/search', searchPage);

updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;

    next();
}

function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}

export function updateNav() {
    const userData = getUserData();

    if (userData) {
        showElement('.user');
        hideElement('.guest');
    } else {
        showElement('.guest');
        hideElement('.user');
    }
}

function showElement(className) {
    const elements = document.querySelectorAll(className);

    for (let i = 0; i < elements.length; i++) {
        elements[i].style.display = 'inline';
    }
}

function hideElement(className) {
    const elements = document.querySelectorAll(className);

    for (let i = 0; i < elements.length; i++) {
        elements[i].style.display = 'none';
    }
}