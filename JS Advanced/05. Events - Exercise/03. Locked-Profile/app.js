function lockedProfile() {
    Array.from(document.querySelectorAll('.profile button'))
        .forEach(b => b.addEventListener('click', onToggle));

    function onToggle(e) {
        const profile = e.target.parentElement;
        const isActive = profile.querySelector('input[type="radio"][value="unlock"]').checked;

        if (isActive) {
            const infoDiv = profile.querySelector('div');

            /* const infoDiv = Array.from(e.target.parentElement.querySelectorAll('div'))
                .find(d => d.id.includes('HiddenFields')); */

            if (e.target.textContent == 'Show more') {
                infoDiv.style.display = 'block';
                e.target.textContent = 'Hide it';
            } else {
                infoDiv.style.display = '';
                e.target.textContent = 'Show more';
            }
        }

    }
}

function lockedProfile() {
    document.getElementById('main').addEventListener('click', onToggle);

    function onToggle(e) {
        if (e.target.tagName = 'BUTTON') {
            const profile = e.target.parentElement;
            const isActive = profile.querySelector('input[type="radio"][value="unlock"]').checked;

            if (isActive) {
                const infoDiv = profile.querySelector('div');

                /* const infoDiv = Array.from(e.target.parentElement.querySelectorAll('div'))
                    .find(d => d.id.includes('HiddenFields')); */

                if (e.target.textContent == 'Show more') {
                    infoDiv.style.display = 'block';
                    e.target.textContent = 'Hide it';
                } else {
                    infoDiv.style.display = '';
                    e.target.textContent = 'Show more';
                }
            }
        }

    }
}