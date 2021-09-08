function printSequence(n, k) {
  let result = [1];

  for (let i = 0; i < n; i++) {
    let currElement = result
      .slice(k * -1)
      .reduce((a, b) => a + b);

    result[i] = currElement;
  }

  console.log(result.join(" "));
}

printSequence(6, 3);
printSequence(8, 2);
