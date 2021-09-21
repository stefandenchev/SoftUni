function play(turns) {

    function findWinner(field) {
        if (
            // Check rows
            field[0][0] == field[0][1] && field[0][0] == field[0][2] && field[0][0] != false ||
            field[1][0] == field[1][1] && field[1][0] == field[1][2] && field[1][0] != false ||
            field[2][0] == field[2][1] && field[2][0] == field[2][2] && field[2][0] != false ||

            // Check columns
            field[0][0] == field[1][0] && field[0][0] == field[2][0] && field[0][0] != false ||
            field[0][1] == field[1][1] && field[0][1] == field[2][1] && field[0][1] != false ||
            field[0][2] == field[1][2] && field[0][2] == field[2][2] && field[0][2] != false ||

            // Check diagonals
            field[0][0] == field[1][1] && field[0][0] == field[2][2] && field[0][0] != false ||
            field[0][2] == field[1][1] && field[0][2] == field[2][0] && field[0][2] != false
        ) {
            return true;
        }
    }

    function printResult(field) {
        field.forEach(x => {
            console.log(x.join('\t'))
        });
    }

    let gameWon = false;
    let field = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let currentPlayer = 'X';

    for (let i = 0; i < turns.length; i++) {
        const [x, y] = turns[i].split(" ");

        if (field[x][y]) {
            console.log("This place is already taken. Please choose another!");
        }
        else {
            field[x][y] = currentPlayer;
            if (findWinner(field, [x, y])) {
                gameWon = true;
                console.log(`Player ${currentPlayer} wins!`);
                printResult(field);
                return;
            }
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }

    if (!gameWon) {
        console.log("The game ended! Nobody wins :(");
    }

    printResult(field);
}

play(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);