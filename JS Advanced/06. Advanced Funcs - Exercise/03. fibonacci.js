function getFibonator() {
    let a = 0;
    let b = 1;

    function getNext() {
        c = a + b;
        a = b;
        b = c;
        return c;
    }

    return getNext;
}

function getFibonator() {
    let [x, y, z] = [1, 1, 1];

    return function getNext() {
        [z, x, y] = [x, y, x + y];
        return z;
    };
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13


// 0 1 1 2 3 5 8 13 21