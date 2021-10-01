function solution(start) {

    return function add(n) {
        return start + n;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
