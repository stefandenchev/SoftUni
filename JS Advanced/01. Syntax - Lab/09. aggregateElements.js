function aggregateElements(array) {
    let sum = 0;
    let sum2 = 0;
    let concat = '';

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        sum += Number(element);
        sum2 += Number(1 / element);
        concat += element.toString();
    }

    console.log(sum);
    console.log(sum2);
    console.log(concat);
}

aggregateElements([1, 2, 3]);