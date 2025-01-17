import { html } from '../lib.js';
import { getUserData } from '../util.js';

const homeTemplate = () => html`
<section id="welcomePage">
    <div id="welcome-message">
        <h1>Welcome to</h1>
        <h1>My Music Application!</h1>
    </div>

    <div class="music-img">
        <img src="./images/musicIcons.webp">
    </div>
</section>`;

export function homePage(ctx) {
    if (getUserData()) {
        ctx.page.redirect('/catalog');
    } else {
        ctx.render(homeTemplate());
    }
}