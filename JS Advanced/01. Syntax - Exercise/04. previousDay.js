function previousDay(year, month, day) {
    let dateString = year + '-' + month + '-' + day;
    let event = new Date(dateString);
    event.setDate(day - 1);
    return event.getFullYear() + '-' + (Number(event.getMonth()) + 1) + '-' + event.getDate();
}

console.log(previousDay(2016, 10, 1));