function createDeck(cards) {

    /*  let result = [];
        for (const card of cards) {
            const face = card.slice(0, -1);
            const suit = card.slice(-1);
            try {
                result.push(createCard(face, suit));
            } catch (error) {
                console.log('Invalid card: ' + card);
                return;
            }
        } console.log(result.join(' '));  */
        

    try {
        console.log(cards.map(card => {
            const face = card.slice(0, -1);
            const suit = card.slice(-1);
            try {
                return createCard(face, suit);
            } catch (error) {
                throw new Error('Invalid card: ' + card);
            }
        }).join(' '));
    } catch (err) {
        console.log(err.message);
    }

    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
        }

        if (!Object.keys(suits).includes(suit)) {
            throw new Error('Invalid suit: ' + face);
        }

        if (!faces.includes(face)) {
            throw new Error('Invalid face ' + suit);
        }

        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        }
    }
}