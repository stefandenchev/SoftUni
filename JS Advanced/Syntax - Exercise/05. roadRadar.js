function radar(speed, area) {
    let rem = 0;
    let allowed = 0;
    switch (area) {
        case "residential":
            allowed = 20;
            if (speed > allowed) {
                rem = speed - allowed;
            }
            break;

        case "city":
            allowed = 50;
            if (speed > allowed) {
                rem = speed - allowed;
            }
            break;

        case "interstate":
            allowed = 90;
            if (speed > allowed) {
                rem = speed - allowed;
            }
            break;

        case "motorway":
            allowed = 130;
            if (speed > allowed) {
                rem = speed - allowed;
            }
            break;
    }

    if (rem == 0) {
        return `Driving ${speed} km/h in a ${allowed} zone`
    } else if (rem <= 20) {
        return `The speed is ${rem} km/h faster than the allowed speed of ${allowed} - speeding`
    } else if (rem <= 40) {
        return `The speed is ${rem} km/h faster than the allowed speed of ${allowed} - excessive speeding`
    } else {
        return `The speed is ${rem} km/h faster than the allowed speed of ${allowed} - reckless driving`
    }

}

console.log(radar(40, 'city'));
console.log(radar(21, 'residential'));
console.log(radar(120, 'interstate'));
console.log(radar(200, 'motorway'));