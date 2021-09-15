function solveToUpper(sentence) {
    let resultSentence = sentence.replace(/[^a-zA-Z ]/g, " ");
    resultSentence = resultSentence.split(' ');
    resultSentence = resultSentence.filter(n => n);

    let result = [];

    for (let i = 0; i < resultSentence.length; i++) {
        result.push(resultSentence[i].toUpperCase()); 
    }

    return result.join(', ');
}

console.log(solveToUpper('Functions in JS can be nested, i.e. hold other functions'));